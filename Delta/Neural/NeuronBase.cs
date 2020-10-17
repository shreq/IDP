using static Delta.Settings;
using static Delta.Utils;

namespace Delta.Neural
{
    abstract class NeuronBase<TTrainingPattern, TOutput>
    {
        public abstract TTrainingPattern TrainingPattern { get; }
        public abstract TOutput Output { get; }
        public abstract TOutput Error { get; }
        public float[] Weights { get; }
        public uint Epoch { get; protected set; }

        protected NeuronBase()
        {
            Weights = new float[NumberOfInputs];

            for (uint i = 0; i < NumberOfInputs; i++)
            {
                Weights[i] = RandomReal(WeightMin, WeightMax);
            }
        }

        public abstract void Train();
    }
}
