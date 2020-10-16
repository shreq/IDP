using static Delta.Settings;

namespace Delta
{
    class NeuronMultiPattern : NeuronBase<TrainingPattern[], float[]>
    {
        public override TrainingPattern[] TrainingPattern { get; }
        public override float[] Output
        {
            get
            {
                var result = new float[TrainingPattern.Length];
                for (int tpi = 0; tpi < TrainingPattern.Length; tpi++)
                {
                    for (int i = 0; i < NumberOfInputs; i++)
                    {
                        result[tpi] += TrainingPattern[tpi].Inputs[i] * Weights[i];
                    }
                }
                return result;
            }
        }
        public float[] TargetOutputs
        {
            get
            {
                var result = new float[TrainingPattern.Length];
                for (int tpi = 0; tpi < TrainingPattern.Length; tpi++)
                {
                    result[tpi] = TrainingPattern[tpi].TargetOutput;
                }
                return result;
            }
        }

        public NeuronMultiPattern(uint numberOfPatterns) : base()
        {
            TrainingPattern = new TrainingPattern[numberOfPatterns];
            for (int tpi = 0; tpi < numberOfPatterns; tpi++)
            {
                TrainingPattern[tpi] = new TrainingPattern();
            }
        }

        public override void Train()
        {
            var output = Output;

            for (int tpi = 0; tpi < TrainingPattern.Length; tpi++)
            {
                for (int i = 0; i < NumberOfInputs; i++)
                {
                    Weights[i] += TrainingStep * (TrainingPattern[tpi].TargetOutput - output[tpi]) * TrainingPattern[tpi].Inputs[i];
                }
            }

            Epoch++;
        }
    }
}
