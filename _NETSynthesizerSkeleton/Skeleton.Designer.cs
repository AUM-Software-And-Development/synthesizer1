
namespace _NETSynthesizerSkeleton
{
    partial class Skeleton
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SwitchShort = new System.Windows.Forms.CheckBox();
            this.SwitchInt = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BuildButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SineCheckBox = new System.Windows.Forms.CheckBox();
            this.CarrierCheckBox = new System.Windows.Forms.CheckBox();
            this.PWMCheckBox = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.waveSelection3 = new _NETSynthesizerSkeleton.WaveSelection();
            this.waveSelection2 = new _NETSynthesizerSkeleton.WaveSelection();
            this.waveSelection1 = new _NETSynthesizerSkeleton.WaveSelection();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // SwitchShort
            // 
            this.SwitchShort.AutoSize = true;
            this.SwitchShort.Location = new System.Drawing.Point(9, 630);
            this.SwitchShort.Name = "SwitchShort";
            this.SwitchShort.Size = new System.Drawing.Size(95, 17);
            this.SwitchShort.TabIndex = 3;
            this.SwitchShort.Text = "16 bit capacity";
            this.SwitchShort.UseVisualStyleBackColor = true;
            this.SwitchShort.CheckedChanged += new System.EventHandler(this.SwitchShort_CheckedChanged);
            // 
            // SwitchInt
            // 
            this.SwitchInt.AutoSize = true;
            this.SwitchInt.Checked = true;
            this.SwitchInt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SwitchInt.Location = new System.Drawing.Point(9, 660);
            this.SwitchInt.Name = "SwitchInt";
            this.SwitchInt.Size = new System.Drawing.Size(95, 17);
            this.SwitchInt.TabIndex = 4;
            this.SwitchInt.Text = "32 bit capacity";
            this.SwitchInt.UseVisualStyleBackColor = true;
            this.SwitchInt.CheckedChanged += new System.EventHandler(this.SwitchInt_CheckedChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(1000, 18);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Sine";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Carrier";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "PWM";
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(900, 600);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(1000, 800);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 9;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(1800, 800);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SineCheckBox
            // 
            this.SineCheckBox.AutoSize = true;
            this.SineCheckBox.Location = new System.Drawing.Point(1000, 690);
            this.SineCheckBox.Name = "SineCheckBox";
            this.SineCheckBox.Size = new System.Drawing.Size(47, 17);
            this.SineCheckBox.TabIndex = 11;
            this.SineCheckBox.Text = "Sine";
            this.SineCheckBox.UseVisualStyleBackColor = true;
            this.SineCheckBox.CheckedChanged += new System.EventHandler(this.SineCheckBox_CheckedChanged);
            // 
            // CarrierCheckBox
            // 
            this.CarrierCheckBox.AutoSize = true;
            this.CarrierCheckBox.Location = new System.Drawing.Point(1000, 630);
            this.CarrierCheckBox.Name = "CarrierCheckBox";
            this.CarrierCheckBox.Size = new System.Drawing.Size(56, 17);
            this.CarrierCheckBox.TabIndex = 12;
            this.CarrierCheckBox.Text = "Carrier";
            this.CarrierCheckBox.UseVisualStyleBackColor = true;
            this.CarrierCheckBox.CheckedChanged += new System.EventHandler(this.CarrierCheckBox_CheckedChanged);
            // 
            // PWMCheckBox
            // 
            this.PWMCheckBox.AutoSize = true;
            this.PWMCheckBox.Location = new System.Drawing.Point(1000, 660);
            this.PWMCheckBox.Name = "PWMCheckBox";
            this.PWMCheckBox.Size = new System.Drawing.Size(53, 17);
            this.PWMCheckBox.TabIndex = 13;
            this.PWMCheckBox.Text = "PWM";
            this.PWMCheckBox.UseVisualStyleBackColor = true;
            this.PWMCheckBox.CheckedChanged += new System.EventHandler(this.PWMCheckBox_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1200, 660);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(1100, 660);
            this.trackBar2.Maximum = 5;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 104);
            this.trackBar2.TabIndex = 15;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1200, 630);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Second Harmonic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1100, 630);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Carrier";
            // 
            // waveSelection3
            // 
            this.waveSelection3.Location = new System.Drawing.Point(600, 9);
            this.waveSelection3.Name = "waveSelection3";
            this.waveSelection3.Size = new System.Drawing.Size(360, 180);
            this.waveSelection3.TabIndex = 7;
            this.waveSelection3.TabStop = false;
            this.waveSelection3.Text = "waveSelection3";
            // 
            // waveSelection2
            // 
            this.waveSelection2.Location = new System.Drawing.Point(10, 270);
            this.waveSelection2.Name = "waveSelection2";
            this.waveSelection2.Size = new System.Drawing.Size(360, 180);
            this.waveSelection2.TabIndex = 6;
            this.waveSelection2.TabStop = false;
            this.waveSelection2.Text = "waveSelection2";
            // 
            // waveSelection1
            // 
            this.waveSelection1.Location = new System.Drawing.Point(10, 9);
            this.waveSelection1.Name = "waveSelection1";
            this.waveSelection1.Size = new System.Drawing.Size(360, 180);
            this.waveSelection1.TabIndex = 5;
            this.waveSelection1.TabStop = false;
            this.waveSelection1.Text = "waveSelection1";
            // 
            // Skeleton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 861);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.PWMCheckBox);
            this.Controls.Add(this.CarrierCheckBox);
            this.Controls.Add(this.SineCheckBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.waveSelection3);
            this.Controls.Add(this.waveSelection2);
            this.Controls.Add(this.waveSelection1);
            this.Controls.Add(this.SwitchInt);
            this.Controls.Add(this.SwitchShort);
            this.KeyPreview = true;
            this.Name = "Skeleton";
            this.Text = "SynthesizerGUI";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SynthesizerGUI_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SynthesizerGUI_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox SwitchShort;
        private System.Windows.Forms.CheckBox SwitchInt;
        private WaveSelection waveSelection1;
        private WaveSelection waveSelection2;
        private WaveSelection waveSelection3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox SineCheckBox;
        private System.Windows.Forms.CheckBox CarrierCheckBox;
        private System.Windows.Forms.CheckBox PWMCheckBox;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

