using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using MathNet;
using MathNet.Numerics;

namespace _NETSynthesizerSkeleton
{
    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise
    }

    public partial class Skeleton : Form
    {
        private float frequency;

        private int Direction;

        private bool SampleCeilingShort;

        private bool SampleCeilingInt;

        private bool aKeyIsDown;

        private MemoryStream MemoryStream;

        private BinaryWriter HexadecimalWrite;

        private IEnumerable<WaveSelection> oscillators;

        private Random random;

        private WavetableSynthesizer wavetableSynthesizer;

        /* Get set events can be set up so that whenever one of these changes, it updates everything else. */

        public Skeleton()
        {
            this.MemoryStream = new MemoryStream();
            this.HexadecimalWrite = new BinaryWriter(this.MemoryStream);
            this.oscillators = this.Controls.OfType<WaveSelection>();
            this.wavetableSynthesizer = new WavetableSynthesizer(ref this.oscillators);

            InitializeComponent();
        }

        private void ApplySettings()
        {
            this.SampleCeilingShort = ((CheckBox)this.Controls["SwitchShort"]).Checked;
            this.SampleCeilingInt = ((CheckBox)this.Controls["SwitchInt"]).Checked;

            if (this.SampleCeilingShort == true && this.SampleCeilingInt == false)
            {
                this.Direction = 0;
            }

            else if (this.SampleCeilingShort == false && this.SampleCeilingInt == true)
            {
                this.Direction = 1;
            }

            else
            {
                this.Direction = 999;
            }
        }

        private void FindKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    this.frequency = 65.4f;      /// C2
                    break;
                case Keys.S:
                    this.frequency = 138.59f;    /// C3
                    break;
                case Keys.D:
                    this.frequency = 261.62f;    /// C4
                    break;
                case Keys.F:
                    this.frequency = 523.25f;    /// C5
                    break;
                case Keys.G:
                    this.frequency = 1046.5f;    /// C6
                    break;
                case Keys.H:
                    this.frequency = 2093f;      /// C7
                    break;
                case Keys.J:
                    this.frequency = 4186.01f;   /// C8
                    break;
                default:
                    return;
            }
        }

        private void GenerateOutput(KeyEventArgs e)
        {
            this.ApplySettings();

            this.FindKey(e);

            this.MemoryStream = new MemoryStream();

            /***/

            byte[] truncate16to8 = new byte[this.wavetableSynthesizer.SampleRate * this.wavetableSynthesizer.ShortByteLimit]; /// * 2 AKA max byte per short (16/2 = 8).
            byte[] truncate32to8 = new byte[this.wavetableSynthesizer.SampleRate * this.wavetableSynthesizer.IntByteLimit];   /// * 4 AKA max byte per int (32/4 = 8).

            switch (this.Direction)
            {
                case 999:
                    return;
                case 0:
                    this.wavetableSynthesizer.MakeOutput(this.frequency);
                    this.PlotWaveTable();
                    Buffer.BlockCopy(this.wavetableSynthesizer.Output, 0, truncate16to8, 0, this.wavetableSynthesizer.Output.Length * this.wavetableSynthesizer.ShortByteLimit); /// Using the written array in memory, generate a translation in bytes at the location starting from truncation array.
                    break;
                case 1:
                    this.wavetableSynthesizer.MakeOutput(this.frequency);
                    this.PlotWaveTable();
                    Buffer.BlockCopy(this.wavetableSynthesizer.Output, 0, truncate32to8, 0, this.wavetableSynthesizer.Output.Length * this.wavetableSynthesizer.IntByteLimit); /// Using the written array in memory, generate a translation in bytes at the location starting from truncation array.
                    break;
                default:
                    return;
            }

            /// <summary>
            /// Wav file format must be processed to output a sound. In this case, the canonical wave file format must be followed to identify "Chunks", or argument identifiers for the IO/Buffer stream.
            /// The references to this data seem to get overwirtten by the kernel, and don't stay in memory. As such it needs to be reinstantiated with every key press.
            /// </summary>
            this.HexadecimalWrite = new BinaryWriter(this.MemoryStream);

            switch (this.Direction)
            {
                case 999:
                    return;
                case 0:
                    this.WriteChunksHeader(ref truncate16to8); /// Using the byte translation, place in appropriate location for readable memory.

                    this.OutputToSpeakers();
                    break;
                case 1:
                    this.WriteChunksHeader(ref truncate32to8); /// Using the byte translation, place in appropriate location for readable memory.

                    this.OutputToSpeakers();
                    break;
                default:
                    return;
            }
        }

        private void WriteChunksHeader(ref byte[] truncatedData)
        {
            int BitsPerSample = 16;
            int sampleRate = 44100;
            char[] chunkID_RIFF = new[] { 'R', 'I', 'F', 'F' };
            char[] subchunk1ID_fmt_ = new[] { 'f', 'm', 't', ' ' };
            int subchunk1size = 16; /// value equal to the h general registers.
            int numberofchannels = 1;
            int subchunk2size = sampleRate * numberofchannels * BitsPerSample / 8;
            int chunksize = 4 + (8 + subchunk1size) + (8 + subchunk2size);
            char[] format_WAVE = new[] { 'W', 'A', 'V', 'E' };
            int audioformat = 1;
            int byterate = sampleRate * numberofchannels * BitsPerSample / 8;
            int blockalign = numberofchannels * BitsPerSample / 8; /// Divide by l general registers limit (Gets total number of bytes per sample at the nearest rounded integer)
            char[] subchunk2ID_data = new[] { 'd', 'a', 't', 'a' };

            this.HexadecimalWrite.Write(chunkID_RIFF);              /// 4
            this.HexadecimalWrite.Write(chunksize);                 /// 4
            this.HexadecimalWrite.Write(format_WAVE);               /// 4
            this.HexadecimalWrite.Write(subchunk1ID_fmt_);          /// 4
            this.HexadecimalWrite.Write(subchunk1size);             /// 4
            this.HexadecimalWrite.Write((short)audioformat);        /// 2
            this.HexadecimalWrite.Write((short)numberofchannels);   /// 2
            this.HexadecimalWrite.Write(sampleRate);                /// 4
            this.HexadecimalWrite.Write(byterate);                  /// 4
            this.HexadecimalWrite.Write((short)blockalign);         /// 2
            this.HexadecimalWrite.Write((short)BitsPerSample);      /// 2
            this.HexadecimalWrite.Write(subchunk2ID_data);          /// 4
            this.HexadecimalWrite.Write(subchunk2size);             /// 4
            this.HexadecimalWrite.Write(truncatedData);                  /// ~ Data
        }

        private void OutputToSpeakers()
        {
            this.MemoryStream.Position = 0;
            new SoundPlayer(this.MemoryStream).Play();
        }

        private void SwitchShort_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SwitchInt_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SynthesizerGUI_KeyDown(object sender, KeyEventArgs e)
        {
            this.GenerateOutput(e);
        }

        private void SynthesizerGUI_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BuildButton_Click(object sender, EventArgs e)
        {
            this.GeneratePWM();
            this.PlotCalculations();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            this.GeneratePWM();
            this.PlotCalculations();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.GeneratePWM();
            this.PlotCalculations();
        }

        private void SineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.GeneratePWM();
            this.PlotCalculations();

        }

        private void CarrierCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.GeneratePWM();
            this.PlotCalculations();

        }

        private void PWMCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.GeneratePWM();
            this.PlotCalculations();
        }

        static double freqSine = 60.0;
        static double freqCarrier = 33.0 * freqSine;
        static double sine2A;
        static double carrierA;

        static double simTimeCycles = 1.0;
        static double simTimeSeconds = simTimeCycles / freqSine;
        static int numSamples = 10000;
        static int samplesPerSecond = (int)(numSamples / simTimeSeconds);

        // Triangle carrier period in seconds
        static double carrierPeriodSeconds = 1.0 / freqCarrier;

        // Triangle carrier period in samples
        static int carrierPeriodSamples = (int)(carrierPeriodSeconds * samplesPerSecond);

        // Plot parameters
        static int plotCyclesFund = 1;
        static double plotTime = plotCyclesFund / freqSine;
        static int plotSamples = plotCyclesFund;

        public double[] sine = new double[numSamples];
        public double[] sine2 = new double[numSamples];
        public double[] carrier = new double[numSamples];
        public double[] t = new double[numSamples];
        public double[] pwm = new double[numSamples];

        public void GeneratePWM()
        {
            sine2A = trackBar1.Value * 0.1;
            carrierA = 1 + trackBar2.Value * 0.1;

            sine = Generate.Sinusoidal(numSamples, samplesPerSecond, freqSine, 1.0);
            sine2 = Generate.Sinusoidal(numSamples, samplesPerSecond, 2 * freqSine, sine2A);
            carrier = Generate.Triangle(numSamples, carrierPeriodSamples / 2, carrierPeriodSamples / 2, -carrierA, carrierA);

            ///Prepare chart
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisX.Maximum = plotTime;
            chart1.ChartAreas["ChartArea1"].AxisX.RoundAxisValues();
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Format = "F4";
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightBlue;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightBlue;

            ///Calculate PWM
            for (int i = 0; i < numSamples; i++)
            {
                sine[i] += sine2[i];
                t[i] = i / (double)samplesPerSecond;
                if (sine[i] > carrier[i])
                {
                    pwm[i] = 1.0;
                }
                else
                {
                    pwm[i] = 0;
                }
            }
        }

        public void PlotCalculations()
        {
            chart1.Series["Sine"].Points.Clear();
            chart1.Series["Carrier"].Points.Clear();
            chart1.Series["PWM"].Points.Clear();

            for (int i = 0; i < numSamples; i++)
            {
                if (SineCheckBox.Checked == true)
                {
                    chart1.Series["Sine"].Points.AddXY(t[i], sine[i]);
                }

                if (CarrierCheckBox.Checked == true)
                {
                    chart1.Series["Carrier"].Points.AddXY(t[i], carrier[i]);
                }

                if (PWMCheckBox.Checked == true)
                {
                    chart1.Series["PWM"].Points.AddXY(t[i], pwm[i]);
                }
            }
        }

        public void PlotWaveTable()
        {
            chart1.Series["Sine"].Points.Clear();
            chart1.Series["Carrier"].Points.Clear();
            chart1.Series["PWM"].Points.Clear();

            for (int i = 0; i < numSamples; i++)
            {
                if (SineCheckBox.Checked == true)
                {
                    chart1.Series["Sine"].Points.AddXY(t[i], this.wavetableSynthesizer.Output[i]);
                }

                if (CarrierCheckBox.Checked == true)
                {
                    chart1.Series["Carrier"].Points.AddXY(t[i], carrier[i]);
                }

                if (PWMCheckBox.Checked == true)
                {
                    chart1.Series["PWM"].Points.AddXY(t[i], pwm[i]);
                }
            }
        }
    }
}
