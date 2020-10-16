namespace Delta
{
    static class Settings
    {
        public static uint NumberOfInputs = 10;
        public static uint NumberOfEpochs = 10_000;
        public static float TrainingStep = 0.01f;

        public static float WeightMin = 0.1f;
        public static float WeightMax = 0.9f;
        public static float ValueMin;
        public static float ValueMax = 1f;
    }
}
