namespace Madaline.Neural
{
    class Layer
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

        public Layer(TemplatePattern[] templatePatterns)
        {
            Neurons = new Neuron[templatePatterns.Length];

            for (int i = 0; i < templatePatterns.Length; i++)
            {
                Neurons[i] = new Neuron(templatePatterns[i]);
            }
        }

        public void SetInputs(float[] inputs)
        {
            for (int i = 0; i < Neurons.Length; i++)
            {
                Neurons[i].Inputs = (float[])inputs.Clone();
            }
        }
    }
}
