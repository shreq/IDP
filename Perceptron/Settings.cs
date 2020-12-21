namespace Perceptron
{
    class Settings
    {
        public int HiddenLayerSize { get; set; }
        public bool BiasEnabled { get; set; }
        public float TrainingStep { get; set; }

        public int MaximumNumberOfEpochs { get; set; }
        public float TargetError { get; set; }
        public int NumberOfTrainingPatternsToUse { get; set; }

        public bool VerboseOutput { get; set; }

        public Settings(int hiddenLayerSize = 4, bool biasEnabled = true, float trainingStep = 0.003f,
            int maximumNumberOfEpochs = 300_000, float targetError = 0.1f, int numberOfTrainingPatternsToUse = 4,
            bool verboseOutput = false)
        {
            HiddenLayerSize = hiddenLayerSize;
            BiasEnabled = biasEnabled;
            TrainingStep = trainingStep;
            MaximumNumberOfEpochs = maximumNumberOfEpochs;
            TargetError = targetError;
            NumberOfTrainingPatternsToUse = numberOfTrainingPatternsToUse;
            VerboseOutput = verboseOutput;
        }
    }
}
