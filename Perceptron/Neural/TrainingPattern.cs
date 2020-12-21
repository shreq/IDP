namespace Perceptron.Neural
{
    class TrainingPattern
    {
        public float[] Inputs { get; }
        public float[] TargetOutputs { get; }

        public TrainingPattern(float[] inputs, float[] targetOutputs)
        {
            Inputs = inputs;
            TargetOutputs = targetOutputs;
        }
    }
}
