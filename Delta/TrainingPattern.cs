using static Delta.Settings;
using static Delta.Utils;

namespace Delta
{
    class TrainingPattern
    {
        public float[] Inputs { get; }
        public float TargetOutput { get; }

        public TrainingPattern()
        {
            Inputs = new float[NumberOfInputs];

            for (uint i = 0; i < NumberOfInputs; i++)
            {
                Inputs[i] = RandomReal(ValueMin, ValueMax);
            }

            TargetOutput = RandomReal(ValueMin, ValueMax);
        }
    }
}
