using System;
using static Delta.Settings;
using static Delta.Utils;

namespace Delta
{
    static class Program
    {
        static void Main()
        {
            //SinglePatternScenario();
            MultiPatternScenario();
        }

        static void SinglePatternScenario()
        {
            var neuron = new NeuronSinglePattern();
            var weights = (float[])neuron.Weights.Clone();
            Console.WriteLine(neuron.Epoch + ":\t" + neuron.Output);

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            Console.WriteLine(neuron.Epoch + ":\t" + neuron.Output);
            Console.WriteLine("Target:\t" + neuron.TrainingPattern.TargetOutput + "\n\n");
            Console.WriteLine($"Weights 0 vs {neuron.Epoch}:");
            PrintCollection(weights, neuron.Weights, "\t");
        }

        static void MultiPatternScenario()
        {
            var neuron = new NeuronMultiPattern(8);
            var weights = (float[])neuron.Weights.Clone();
            Console.WriteLine(neuron.Epoch + ":");
            PrintCollection(neuron.Output);

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            Console.WriteLine(neuron.Epoch + ":\t\tTarget:");
            PrintCollection(neuron.Output, neuron.TargetOutputs);
            Console.WriteLine($"\n\nWeights 0 vs {neuron.Epoch}:");
            PrintCollection(weights, neuron.Weights, "\t");
        }
    }
}
