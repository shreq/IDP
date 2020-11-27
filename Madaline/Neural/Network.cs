using System;

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

        public Neuron[][] Run()
        {
            var result = new Neuron[TemplatePatterns.Length][];

            for (int i = 0; i < TemplatePatterns.Length; i++)
            {
                OutputLayer.SetInputs(TemplatePatterns[i].Inputs);
                result[i] = (Neuron[])OutputLayer.Neurons.Sorted().Clone();

                /**/
                Console.WriteLine($"Target: {TemplatePatterns[i].Identifier}\n" +
                    $"Network (output, corresponding identifier):");
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.WriteLine($"{result[i][j].Output}\t{result[i][j].Identifier}");
                }
                Console.WriteLine();
            }

            return result;
        }
    }
}
