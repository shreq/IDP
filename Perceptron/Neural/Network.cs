using System;

namespace Perceptron.Neural
{
    class Network
    {
        public TrainingPattern[] TrainingPatterns { get; private set; }
        public LayerHidden HiddenLayer { get; }
        public LayerOutput OutputLayer { get; }
        public float[] Error
        {
            get
            {
                var result = new float[Settings.NumberOfTrainingPatternsToUse];
                for (int tp = 0; tp < Settings.NumberOfTrainingPatternsToUse; tp++)
                {
                    SetInputs(tp);
                    var outputs = OutputLayer.Outputs;
                    var mse = 0f;
                    for (int i = 0; i < outputs.Length; i++)
                    {
                        var error = TrainingPatterns[tp].TargetOutputs[i] - outputs[i];
                        mse += error * error;
                    }
                    result[tp] = mse / outputs.Length;
                }
                return result;
            }
        }
        public Settings Settings { get; }

        public Network(TrainingPattern[] trainingPatterns, in Settings settings)
        {
            TrainingPatterns = trainingPatterns;
            Settings = settings;
            HiddenLayer = new LayerHidden(Settings.HiddenLayerSize, TrainingPatterns[0].Inputs.Length, Settings.BiasEnabled);
            OutputLayer = new LayerOutput(TrainingPatterns[0].TargetOutputs.Length, Settings.HiddenLayerSize, Settings.BiasEnabled);
        }

        private void SetInputs(int trainingPatternIndex)
        {
            HiddenLayer.SetInputs(TrainingPatterns[trainingPatternIndex].Inputs);
            OutputLayer.SetInputs(HiddenLayer.Outputs);
        }

        private float[] BackwardPropagation(float[] targetOutputs)
        {
            var errors = OutputLayer.GetErrors(targetOutputs);

            var targets = new float[HiddenLayer.Neurons.Length];
            for (int i = 0; i < HiddenLayer.Neurons.Length; i++)
            {
                for (int j = 0; j < OutputLayer.Neurons.Length; j++)
                {
                    targets[i] += OutputLayer.Neurons[j].Weights[i] * errors[j];
                }
            }
            return targets;
        }

        private void Train(int trainingPatternIndex)
        {
            SetInputs(trainingPatternIndex);

            var outputErrors = OutputLayer.GetErrors(TrainingPatterns[trainingPatternIndex].TargetOutputs);

            OutputLayer.Train(outputErrors, Settings.TrainingStep);
            HiddenLayer.Train(BackwardPropagation(outputErrors), Settings.TrainingStep);
        }

        public void Train()
        {
            var order = Utils.RandomSet(Settings.NumberOfTrainingPatternsToUse);

            float error = float.MaxValue;
            for (int epoch = 0; epoch < Settings.MaximumNumberOfEpochs && error > Settings.TargetError; epoch++)
            {
                for (int i = 0; i < order.Length; i++)
                {
                    Train(order[i]);
                }

                error = Error.Mean();

                if (Settings.VerboseOutput) Error.PrintLines();
            }

            if (Settings.VerboseOutput) Console.WriteLine();
        }

        public void PrintFinalResults()
        {
            for (int i = 0; i < Settings.NumberOfTrainingPatternsToUse; i++)
            {
                SetInputs(i);
                Console.Write($"Training pattern #{i}\n");
                Console.Write("Target outputs:\t");
                TrainingPatterns[i].TargetOutputs.PrintLines();
                Console.Write("Output layer:  \t");
                OutputLayer.Outputs.PrintLines();
                Console.Write("Hidder layer:  \t");
                HiddenLayer.Outputs.PrintLines();
                Console.WriteLine($"Error:         \t{Error[i]:F6}\n");
            }
            Console.WriteLine($"Mean error:    \t{Error.Mean():F6}");
        }
    }
}
