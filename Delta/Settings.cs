namespace Delta
{
    enum PatternScenario
    {
        SinglePattern,
        MultiPattern,
        File
    }

    static class Settings
    {
        #region default values
        public const PatternScenario scenarioDefault = PatternScenario.SinglePattern;
        public const uint numberOfPatternsDefault = 5;
        public const uint numberOfInputsDefault = 10;
        public const uint numberOfEpochsDefault = 10_000;
        public const float trainingStepDefault = 0.0001f;

        public const float weightMinDefault = 0.1f;
        public const float weightMaxDefault = 0.9f;
        public const float valueMinDefault = 0f;
        public const float valueMaxDefault = 1f;

        public const bool verboseOutputDefault = true;
        #endregion default values

        #region active values
        public static PatternScenario Scenario = scenarioDefault;
        public static uint NumberOfPatterns = numberOfPatternsDefault;
        public static uint NumberOfInputs = numberOfInputsDefault;
        public static uint NumberOfEpochs = numberOfEpochsDefault;
        public static float TrainingStep = trainingStepDefault;

        public static float WeightMin = weightMinDefault;
        public static float WeightMax = weightMaxDefault;
        public static float ValueMin = valueMinDefault;
        public static float ValueMax = valueMaxDefault;

        public static bool VerboseOutput = verboseOutputDefault;
        #endregion active values
    }
}
