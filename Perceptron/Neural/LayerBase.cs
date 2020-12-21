namespace Perceptron.Neural
{
    abstract class LayerBase
    {
        public Neuron[] Neurons { get; }
        public float[] Outputs
        {
            get
            {
                var outputs = new float[Neurons.Length];
                for (int i = 0; i < Neurons.Length; i++)
                {
                    outputs[i] = Neurons[i].Output;
                }
                return outputs;
            }
        }

        protected LayerBase(int layerSize, int inputsSize, bool biasEnabled)
        {
            Neurons = new Neuron[layerSize];
            for (int i = 0; i < layerSize; i++)
            {
                Neurons[i] = new Neuron(inputsSize, biasEnabled);
            }
        }

        public void SetInputs(float[] inputs)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Inputs = inputs;
            }
        }

        public abstract float[] GetErrors(float[] targetOutputs);

        public void Train(float[] errors, float trainingStep)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Train(errors[i], trainingStep);
            }
        }
    }
}
