using System;
using static Delta.Settings;

namespace Delta.Neural
{
    class NeuronMultiPattern : NeuronBase<TrainingPattern[], float[]>
    {
        public override TrainingPattern[] TrainingPattern { get; }
        public override float[] Output
        {
            get
            {
                var result = new float[TrainingPattern.Length];
                for (uint tpi = 0; tpi < TrainingPattern.Length; tpi++)
                {
                    for (uint i = 0; i < NumberOfInputs; i++)
                    {
                        result[tpi] += TrainingPattern[tpi].Inputs[i] * Weights[i];
                    }
                }
                return result;
            }
        }
        public override float[] Error
        {
            get
            {
                var result = new float[TrainingPattern.Length];
                var output = Output;
                for (uint tpi = 0; tpi < TrainingPattern.Length; tpi++)
                {
                    result[tpi] = Math.Abs(TrainingPattern[tpi].TargetOutput - output[tpi]);
                }
                return result;
            }
        }

        public NeuronMultiPattern(uint numberOfPatterns) : base()
        {
            TrainingPattern = new TrainingPattern[numberOfPatterns];
            for (uint tpi = 0; tpi < numberOfPatterns; tpi++)
            {
                TrainingPattern[tpi] = new TrainingPattern();
            }
        }

        public override void Train()
        {
            var output = Output;

            for (uint tpi = 0; tpi < TrainingPattern.Length; tpi++)
            {
                for (uint i = 0; i < NumberOfInputs; i++)
                {
                    Weights[i] += TrainingStep * (TrainingPattern[tpi].TargetOutput - output[tpi]) * TrainingPattern[tpi].Inputs[i];
                }
            }

            Epoch++;
        }
    }
}
