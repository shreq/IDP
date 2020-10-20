using CommandLine;
using Delta.Neural;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

                if (o.Filepath != null) Scenario = PatternScenario.File;

                switch (Scenario)
                {
                    case PatternScenario.SinglePattern:
                        {
                            SinglePatternScenario();
                            break;
                        }
                    case PatternScenario.MultiPattern:
                        {
                            MultiPatternScenario();
                            break;
                        }
                    case PatternScenario.File:
                        {
                            FileScenario(o.Filepath);
                            break;
                        }
                    default:
                        throw new InvalidEnumArgumentException();
                }
            });
        }

        static void FileScenario(string path)
        {
            var result = File.ReadAllLines(path);
            NumberOfPatterns = (uint)result.Length - 2;

            if (NumberOfPatterns < 2)
            {
                var inputs = result[2].ParseToReals();

                var trainingPattern = new TrainingPattern(inputs.GetRange(0, inputs.Count - 1).ToArray(), inputs[^1]);

                NumberOfInputs = (uint)trainingPattern.Inputs.Length;
                SinglePatternScenario(new NeuronSinglePattern(trainingPattern));
            }
            else
            {
                var trainingPattern = new List<TrainingPattern>();

                for (int i = 0, r = 2; i < NumberOfPatterns; i++, r++)
                {
                    var inputs = result[r].ParseToReals();

                    trainingPattern.Add(
                        new TrainingPattern(inputs.GetRange(0, inputs.Count - 1).ToArray(), inputs[^1])
                    );
                }

                NumberOfInputs = (uint)trainingPattern[0].Inputs.Length;
                MultiPatternScenario(new NeuronMultiPattern(trainingPattern.ToArray()));
            }
        }

        static void SinglePatternScenario(NeuronSinglePattern neuron = null)
        {
            if (neuron == null) neuron = new NeuronSinglePattern();

            var initialWeights = (float[])neuron.Weights.Clone();
            var initialOutput = neuron.Output;

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            if (VerboseOutput)
            {
                Console.WriteLine("Input values:");
                PrintLists("  ", neuron.TrainingPattern.Inputs);

                Console.WriteLine("\nWeights:\n" +
                    "  Initial \tFinal");
                PrintLists("  ", initialWeights, neuron.Weights);
            }

            Console.WriteLine("\nOutput values:\n" +
                "  Initial \tFinal \t\t Target  \tError");
            PrintValues("  ", initialOutput, neuron.Output, neuron.TrainingPattern.TargetOutput, neuron.Error);
        }

        static void MultiPatternScenario(NeuronMultiPattern neuron = null)
        {
            if (neuron == null) neuron = new NeuronMultiPattern(NumberOfPatterns);

            var initialWeights = (float[])neuron.Weights.Clone();
            var initialOutput = (float[])neuron.Output.Clone();

            while (neuron.Epoch < NumberOfEpochs)
            {
                neuron.Train();
            }

            if (VerboseOutput)
            {
                Console.WriteLine("Input values:");
                PrintLists("  ", neuron.TrainingPattern.AggregateInputs());

                Console.WriteLine("\nWeights:\n" +
                    "  Initial \tFinal");
                PrintLists("  ", initialWeights, neuron.Weights);
            }

            Console.WriteLine("\nOutput values:\n" +
                "  Initial \tFinal \t\tTarget  \tError");
            PrintLists("  ", initialOutput, neuron.Output, neuron.TrainingPattern.AggregateOutputs(), neuron.Error);
            Console.WriteLine("Mean Squared Error:\t\t\t\t" + string.Format("{0:F5}  ", neuron.Error.SquaredMean()));
        }
    }
}
