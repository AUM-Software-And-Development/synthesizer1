using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace _NETSynthesizerSkeleton
{
    public class WaveSelection : GroupBox
    {
        /// <summary>
        /// Found in the general namespace of the skeleton.
        /// </summary>
        public WaveForm WaveForm
        {
            get;
            private set;
        }

        public WaveSelection()
        {
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(30, 36),
                Text = "Saw",
                BackColor = Color.Gray
            });

            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(120, 36),
                Text = "Sine"
            });

            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(210, 36),
                Text = "Square"
            });

            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(30, 72),
                Text = "Triangle"
            });

            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(120, 72),
                Text = "Noise"
            });

            foreach (Control control in this.Controls)
            {
                control.Size = new Size(90, 30);
                control.Font = new Font("Arial", 9.00f);
                control.Click += WaveType_ButtonClick;
            }

            this.WaveForm = (WaveForm)(WaveForm)Enum.Parse(typeof(WaveForm), "Saw"); ; /// Sets default waveform/button click status.

            this.Controls.Add(new CheckBox()
            {
                Name = "OscillatorSwitch",
                Location = new Point(300, 90),
                Size = new Size(30,30),
                Text = "On",
                Checked = true
            });
        }

        public bool WaveSelectionSwitch_IsOn => ((CheckBox)this.Controls["OscillatorSwitch"]).Checked;

        private void WaveType_ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text); /// Compares button text to known wave types (enumerated strings), and assigns WaveForm to an equaled type.
            /* MessageBox.Show($"The button is {this.WaveForm}"); /// Method for printing what's been clicked. Box should have an output location for what's changing and calculating */
            foreach (Button b in this.Controls.OfType<Button>())
            {
                b.UseVisualStyleBackColor = true;
            }
            button.BackColor = Color.Green;
        }
    }
}
