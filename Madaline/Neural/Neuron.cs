namespace Madaline.Neural
{
    class Neuron
    {
        public string Identifier { get; }
        public float[] Inputs { get; set; }
        public float[] Weights { get; }
        public float Output
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

        public Neuron(TemplatePattern templatePattern)
        {
            Weights = templatePattern.Inputs.Normalized();
            Identifier = templatePattern.Identifier;
        }
    }
}
