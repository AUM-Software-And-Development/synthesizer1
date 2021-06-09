using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _NETSynthesizerSkeleton
{
    public class WavetableSynthesizer
    {
        public List<int[]> Wavetables;

        private int[] output;

        private short BitsPerSample;

        private int sampleRate;

        private float frequency;

        private byte shortByteLimit = sizeof(short);

        private byte intByteLimit = sizeof(int);

        private char[] chunkID_RIFF;

        private char[] subchunk1ID_fmt_;

        private int subchunk1size;

        private int numberofchannels;

        private int subchunk2size;

        private int chunksize;

        private char[] format_WAVE;

        private int audioformat;

        private int byterate;

        private int blockalign;

        private int Direction;

        private char[] subchunk2ID_data;

        private bool SampleCeilingShort;

        private bool SampleCeilingInt;

        private bool aKeyIsDown;

        private IEnumerable<WaveSelection> oscillators;

        public WaveTableBuilder waveTables;

        public int[] Output
        {
            get
            {
                return this.output;
            }
        }

        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }
        }

        public byte ShortByteLimit
        {
            get
            {
                return this.shortByteLimit;
            }
        }

        public byte IntByteLimit
        {
            get
            {
                return this.intByteLimit;
            }
        }

        public WavetableSynthesizer(ref IEnumerable<WaveSelection> oscillators)
        {
            this.BitsPerSample = 16;
            this.sampleRate = 44100;
            this.frequency = 440;

            this.chunkID_RIFF = new[] { 'R', 'I', 'F', 'F' };

            this.subchunk1ID_fmt_ = new[] { 'f', 'm', 't', ' ' };
            this.subchunk1size = 16; /// value equal to the h general registers.

            this.numberofchannels = 1;

            this.subchunk2size = this.sampleRate * this.numberofchannels * this.BitsPerSample / 8;

            this.chunksize = 4 + (8 + this.subchunk1size) + (8 + this.subchunk2size);
            this.format_WAVE = new[] { 'W', 'A', 'V', 'E' }; ;

            this.audioformat = 1;

            /// Sample rate...
            this.byterate = this.sampleRate * this.numberofchannels * this.BitsPerSample / 8;
            this.blockalign = this.numberofchannels * this.BitsPerSample / 8; /// Divide by l general registers limit (Gets total number of bytes per sample at the nearest rounded integer)

            this.oscillators = oscillators;

            this.waveTables = new WaveTableBuilder();
            this.Wavetables = new List<int[]>();

            /// Bits per sample...

            this.subchunk2ID_data = new[] { 'd', 'a', 't', 'a' };
        }

        public void MakeOutput(float frequency)
        {
            this.frequency = frequency;
            this.Wavetables = new List<int[]>();
            this.output = new int[this.sampleRate];
            int oCount = this.oscillators.Count();
            this.oscillators = this.oscillators.OfType<WaveSelection>().Where(o => o.WaveSelectionSwitch_IsOn);

            foreach (WaveSelection o in this.oscillators) /// Buildwavetable
            {
                switch (o.WaveForm)
                {
                    case WaveForm.Saw:
                        this.Wavetables.Add(this.waveTables.BuildWavetables(this.sampleRate, this.frequency, 0));
                        break;
                    case WaveForm.Sine:
                        this.Wavetables.Add(this.waveTables.BuildWavetables(this.sampleRate, this.frequency, 1));
                        break;
                    case WaveForm.Square:
                        this.Wavetables.Add(this.waveTables.BuildWavetables(this.sampleRate, this.frequency, 2));
                        break;
                    case WaveForm.Triangle:
                        this.Wavetables.Add(this.waveTables.BuildWavetables(this.sampleRate, this.frequency, 3));
                        break;
                    case WaveForm.Noise:
                        this.Wavetables.Add(this.waveTables.BuildWavetables(this.sampleRate, this.frequency, 4));
                        break;
                    default:
                        return;
                }
            }

            foreach (int[] array in this.Wavetables)
            {
                for (int position = 0; position < this.sampleRate; position++)
                {
                    this.output[position] += Convert.ToInt16((short)(array[position] / oCount));
                }
            }
        }
    }
}