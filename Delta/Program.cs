using CommandLine;
using Delta.Neural;
using System;
using System.ComponentModel;
using static Delta.Settings;
using static Delta.Utils;

namespace Delta
{
    static class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineParser>(args).WithParsed(o =>
            {
                CommandLineParser.UpdateSettings(o);

                switch (Scenario)
                {
                    case PatternScenario.SinglePattern:
                        {
                            SinglePatternScenario();
                            break;
                        }
                    case PatternScenario.MultiPattern:
                        {
                            MultiPatternScenario(NumberOfPatterns);
                            break;
                        }
                    default:
                        throw new InvalidEnumArgumentException();
                }
            });
        }

        static void SinglePatternScenario()
        {
            var neuron = new NeuronSinglePattern();

            var initialWeights = (float[])neuron.Weights.Clone();
            var initialOutput = neuron.Output;

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            Console.WriteLine("Input values:");
            PrintLists("  ", neuron.TrainingPattern.Inputs);

            Console.WriteLine("\nWeights:\n" +
                "  Initial \tFinal");
            PrintLists("  ", initialWeights, neuron.Weights);

            Console.WriteLine("\nOutput values:\n" +
                "  Initial \tFinal \t\t Target  \tError");
            PrintValues("  ", initialOutput, neuron.Output, neuron.TrainingPattern.TargetOutput, neuron.Error);
        }

        static void MultiPatternScenario(uint numberOfPatterns)
        {
            var neuron = new NeuronMultiPattern(numberOfPatterns);

            var initialWeights = (float[])neuron.Weights.Clone();
            var initialOutput = (float[])neuron.Output.Clone();

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            Console.WriteLine("Input values:");
            PrintLists("  ", neuron.TrainingPattern.AggregateInputs());

            Console.WriteLine("\nWeights:\n" +
                "  Initial \tFinal");
            PrintLists("  ", initialWeights, neuron.Weights);

            Console.WriteLine("\nOutput values:\n" +
                "  Initial \tFinal \t\tTarget  \tError");
            PrintLists("  ", initialOutput, neuron.Output, neuron.TrainingPattern.AggregateOutputs(), neuron.Error);
            Console.WriteLine("Mean Squared Error:\t\t\t\t" + string.Format("{0:F5}  ", neuron.Error.SquaredMean()));
        }
    }
}
