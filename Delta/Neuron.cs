using static Delta.Settings;
using static Delta.Utils;

namespace Delta
{
    class Neuron
    {
        public TrainingPattern TrainingPattern { get; }
        public float[] Weights { get; private set; }
        public float Output
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
        public uint Epoch { get; private set; }

        #region constructors
        public Neuron()
        {
            TrainingPattern = new TrainingPattern();
            Weights = new float[NumberOfInputs];

            for (uint i = 0; i < NumberOfInputs; i++)
            {
                Weights[i] = RandomReal(WeightMin, WeightMax);
            }
        }

        public Neuron(TrainingPattern trainingPattern)
        {
            TrainingPattern = trainingPattern;
            Weights = new float[NumberOfInputs];

            for (uint i = 0; i < NumberOfInputs; i++)
            {
                Weights[i] = RandomReal(WeightMin, WeightMax);
            }
        }
        #endregion constructors

        public void Train()
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
