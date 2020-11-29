using System;
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
                var countNonZero = 0;
                for (int i = 0; i < Inputs.Length; i++)
                {
                    if (Inputs[i] != 0f)
                    {
                        countNonZero++;
                    }
                }

                var sqrt = (float)Math.Sqrt(countNonZero);
                var result = 0f;
                for (int i = 0; i < Inputs.Length; i++)
                {
                            
                 result += Inputs[i]/sqrt * Weights[i];
                    
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
