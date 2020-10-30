using System;

namespace Madaline.Neural
{
    class Layer
    {
        public Neuron[] Neurons { get; private set; }
        public float[] Outputs { get; }

        #region constructors
        public Layer(int layerSize, int inputSize, Func<float, float> activationFunction)
        {
            Neurons = new Neuron[layerSize];
            for (int i = 0; i < layerSize; i++)
            {
                Neurons[i] = new Neuron(inputSize, activationFunction);
            }
        }
        #endregion constructors
    }
}
