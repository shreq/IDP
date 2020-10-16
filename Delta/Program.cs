using System;
using static Delta.Settings;
using static Delta.Utils;

namespace Delta
{
    static class Program
    {
        static void Main()
        {
            var neuron = new Neuron();
            var weights = (float[])neuron.Weights.Clone();
            Console.WriteLine(neuron.Epoch + ":\t" + neuron.Output);

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            Console.WriteLine(neuron.Epoch + ":\t" + neuron.Output);
            Console.WriteLine("Target:\t" + neuron.TrainingPattern.TargetOutput + "\n\n");
            PrintCollection(weights, neuron.Weights, "\t");
        }
    }
}
