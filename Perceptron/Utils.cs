using System;
using System.Linq;

namespace Perceptron
{
    static class Utils
    {
        #region random
        private static readonly Random random = new Random();

        public static float RandomFloat(float min, float max) =>
            (float)(1 - random.NextDouble()) * (max - min) + min;

        public static int[] RandomSet(int size) =>
            Enumerable.Range(0, size).OrderBy(x => random.Next()).ToArray();
        #endregion random

        public static Func<float, float> SigmoidFunc =>
            x => (float)(1.0f / (1.0f + Math.Exp(-x)));

        public static Func<float, float> SigmoidDerivativeFunc =>
            x =>
            {
                var s = SigmoidFunc(x);
                return s * (1.0f - s);
            };

        public static float Mean(this float[] array)
        {
            var result = 0f;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i];
            }
            return result / array.Length;
        }

        public static void PrintLines(this float[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]:F6}   ");
            }
            Console.WriteLine();
        }
    }
}
