namespace Madaline.Neural
{
    class TemplatePattern
    {
        public float[] Inputs { get; }
        public string Identifier { get; }

        public TemplatePattern(float[] inputs, string identifier)
        {
            Inputs = inputs;
            Identifier = identifier;
        }     
    }
}
