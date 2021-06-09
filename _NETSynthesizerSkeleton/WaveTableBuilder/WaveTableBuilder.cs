using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet;
using MathNet.Numerics;

namespace _NETSynthesizerSkeleton
{
    public class WaveTableBuilder
    {
        public int SampleRate;
        public float Frequency;
        private Random random;
        public int[] Wavetable;

        public WaveTableBuilder()
        {
            this.random = new Random();
        }

        public int[] BuildWavetables(int sampleRate, float frequency, int index)
        {
            this.Frequency = frequency;
            this.SampleRate = sampleRate;
            this.Wavetable = new int[sampleRate];
            int SamplesAllowedByWave = (int)(sampleRate / frequency);
            int ampereSteps = (int)((short.MaxValue * 2) / SamplesAllowedByWave);
            int positionOffset = 0;
            int position = 0;

            switch (index)
            {
                case 0:
                    this.BuildSawWT(SamplesAllowedByWave, ampereSteps, positionOffset, position, this.Wavetable);
                    break;
                case 1:
                    this.BuildSineWT(SamplesAllowedByWave, ampereSteps, positionOffset, position, this.Wavetable);
                    break;
                case 2:
                    this.BuildSquareWT(SamplesAllowedByWave, ampereSteps, positionOffset, position, this.Wavetable);
                    break;
                case 3:
                    this.BuildTriangleWT(SamplesAllowedByWave, ampereSteps, positionOffset, position, this.Wavetable);
                    break;
                case 4:
                    this.BuildNoiseWT(SamplesAllowedByWave, ampereSteps, positionOffset, position, this.Wavetable);
                    break;
                default:
                    return null;
            }
            return this.Wavetable;
        }

        private void BuildSawWT(int SamplesAllowedByWave, int ampereSteps, int positionOffset, int position, int[] iWave)
        {
            for (position = 0; position < this.SampleRate; position++)
            {
                positionOffset = -short.MaxValue;
                for (int p2 = 0; p2 < SamplesAllowedByWave; p2++)
                {
                    if (position >= this.SampleRate) { break; }
                    positionOffset += ampereSteps;
                    iWave[position++] = Convert.ToInt16(positionOffset);
                }
                position--;
            }
        }

        private void BuildSineWT(int SamplesAllowedByWave, int ampereSteps, int positionOffset, int position, int[] iWave)
        {
            for (position = 0; position < this.SampleRate; position++)
            {
                iWave[position] = Convert.ToInt16(short.MaxValue * Math.Sin(((Math.PI * 2 * this.Frequency) / this.SampleRate) * position));
            }
        }

        private void BuildSquareWT(int SamplesAllowedByWave, int ampereSteps, int positionOffset, int position, int[] iWave)
        {
            for (position = 0; position < this.SampleRate; position++)
            {
                iWave[position] = Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * this.Frequency) / this.SampleRate * position)));
            }
        }

        private void BuildTriangleWT(int SamplesAllowedByWave, int ampereSteps, int positionOffset, int position, int[] iWave)
        {
            positionOffset = -short.MaxValue;
            for (position = 0; position < this.SampleRate; position++)
            {
                if (Math.Abs(positionOffset + ampereSteps) > short.MaxValue)
                {
                    ampereSteps = (short)-ampereSteps;
                }
                positionOffset += ampereSteps;
                iWave[position] = Convert.ToInt16(positionOffset);
            }
        }

        private void BuildNoiseWT(int SamplesAllowedByWave, int ampereSteps, int positionOffset, int position, int[] iWave)
        {
            for (position = 0; position < this.SampleRate; position++)
            {
                iWave[position] = (short)this.random.Next(-short.MaxValue, short.MaxValue);
            }
        }

        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * Math libraries
         */
    }
}
