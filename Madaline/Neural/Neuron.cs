using System;
using static Madaline.Settings;
using static Madaline.Utils;

namespace Madaline.Neural
{
    class Neuron
    {
        public float[] Inputs { get; private set; }
        public float[] Weights { get; private set; }
        public Func<float, float> ActivationFunction { get; private set; }
        public float AdderOutput
        {
            get
            {
                var result = 0f;
                for (int i = 0; i < Inputs.Length; i++)
                {
                    result += Inputs[i] * Weights[i];
                }
                return result;
            }
        }

        #region constructors
        public Neuron(int inputSize, Func<float, float> activationFunction)
        {
            Inputs = new float[inputSize];
            for (int i = 0; i < inputSize; i++)
            {
                Inputs[i] = RandomFloat(ValueMin, ValueMax);
            }
            Weights = new float[inputSize];
            for (int i = 0; i < inputSize; i++)
            {
                Weights[i] = RandomFloat(WeightMin, WeightMax);
            }
            ActivationFunction = activationFunction;
        }

        public Neuron(float[] inputs, Func<float, float> activationFunction)
        {
            Inputs = (float[])inputs.Clone();
            ActivationFunction = activationFunction;
        }
        #endregion constructors
    }
}
