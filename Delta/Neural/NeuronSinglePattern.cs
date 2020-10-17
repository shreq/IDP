using System;
using static Delta.Settings;

namespace Delta.Neural
{
    class NeuronSinglePattern : NeuronBase<TrainingPattern, float>
    {
        public override TrainingPattern TrainingPattern { get; }
        public override float Output
        {
            get
            {
                var result = 0f;
                for (uint i = 0; i < NumberOfInputs; i++)
                {
                    result += TrainingPattern.Inputs[i] * Weights[i];
                }
                return result;
            }
        }
        public override float Error => Math.Abs(TrainingPattern.TargetOutput - Output);

        public NeuronSinglePattern() : base() =>
            TrainingPattern = new TrainingPattern();

        public override void Train()
        {
            var output = Output;

            for (uint i = 0; i < NumberOfInputs; i++)
            {
                Weights[i] += TrainingStep * (TrainingPattern.TargetOutput - output) * TrainingPattern.Inputs[i];
            }

            Epoch++;
        }
    }
}
