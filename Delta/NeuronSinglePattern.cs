using static Delta.Settings;

namespace Delta
{
    class NeuronSinglePattern : NeuronBase<TrainingPattern, float>
    {
        public override TrainingPattern TrainingPattern { get; }
        public override float Output
        {
            get
            {
                var result = 0f;
                for (int i = 0; i < NumberOfInputs; i++)
                {
                    result += TrainingPattern.Inputs[i] * Weights[i];
                }
                return result;
            }
        }

        public NeuronSinglePattern() : base() =>
            TrainingPattern = new TrainingPattern();

        public override void Train()
        {
            var output = Output;

            for (int i = 0; i < NumberOfInputs; i++)
            {
                Weights[i] += TrainingStep * (TrainingPattern.TargetOutput - output) * TrainingPattern.Inputs[i];
            }

            Epoch++;
        }
    }
}
