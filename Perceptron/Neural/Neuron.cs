using static Perceptron.Utils;

namespace Perceptron.Neural
{
    class Neuron
    {
        public float[] Inputs { get; set; }
        public float[] Weights { get; private set; }
        public bool BiasEnabled { get; }
        public float BiasWeight { get; private set; }
        public float Sum
        {
            get
            {
                var result = BiasWeight;
                for (int i = 0; i < Inputs.Length; i++)
                {
                    result += Inputs[i] * Weights[i];
                }
                return result;
            }
        }
        public float Output => SigmoidFunc(Sum);

        public Neuron(int inputsSize, bool biasEnabled)
        {
            Weights = new float[inputsSize];
            for (int i = 0; i < inputsSize; i++)
            {
                Weights[i] = RandomFloat(-.5f, .5f);
            }

            BiasEnabled = biasEnabled;

            if (biasEnabled)
            {
                BiasWeight = RandomFloat(-.5f, .5f);
            }
        }

        public void Train(float error, float trainingStep)
        {
            for (int i = 0; i < Weights.Length; i++)
            {
                Weights[i] += trainingStep * error * Inputs[i];
            }

            if (BiasEnabled)
            {
                BiasWeight += trainingStep * error;
            }
        }
    }
}
