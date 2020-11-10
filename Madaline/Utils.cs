using Madaline.Neural;
using System;
using System.Linq;

namespace Madaline
{
    static class Utils
    {
        public static float[] Normalized(this float[] array)
        {
            var result = (float[])array.Clone();

            var countNonZero = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0f)
                {
                    countNonZero++;
                }
            }

            var sqrt = (float)Math.Sqrt(countNonZero);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] /= sqrt;
            }

            return result;
        }

        public static Neuron[] Sorted(this Neuron[] neurons) =>
            neurons.OrderBy(x => x.Output).ToArray();
    }
}
