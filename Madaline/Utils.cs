using System;

namespace Madaline
{
    static class Utils
    {
        #region random
        private static readonly Random random = new Random();

        public static float RandomFloat() =>
            (float)random.NextDouble();

        public static float RandomFloat(float min, float max) =>
            (float)random.NextDouble() * (max - min) + min;
        #endregion random

        #region extension methods
        public static float[] Normalize(this float[] array)
        {
            var countNonZero = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0f)
                {
                    countNonZero++;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] /= (float)Math.Sqrt(countNonZero);
            }

            return array;
        }
        #endregion extension methods
    }
}
