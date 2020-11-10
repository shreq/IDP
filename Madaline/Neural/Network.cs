namespace Madaline.Neural
{
    class Network
    {
        public TemplatePattern[] TemplatePatterns { get; }
        public Layer OutputLayer { get; }

        public Network(TemplatePattern[] templatePatterns)
        {
            TemplatePatterns = templatePatterns;
            OutputLayer = new Layer(templatePatterns);
        }

        public Neuron[] Run()
        {
            var result = new Neuron[TemplatePatterns.Length];

            for (int i = 0; i < TemplatePatterns.Length; i++)
            {
                OutputLayer.SetInputs(TemplatePatterns[i].Inputs);
                result[i] = OutputLayer.Neurons.Sorted()[^1];
            }

            return result;
        }
    }
}
