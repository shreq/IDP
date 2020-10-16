using System;
using System.Collections;

namespace Delta
{
    static class Utils
    {
        #region random
        private static readonly Random random = new Random();

        public static float RandomReal() =>
            (float)random.NextDouble();

        public static float RandomReal(float min, float max) =>
            (float)(1 - random.NextDouble()) * (max - min) + min;
        #endregion random

        public static void PrintCollection(IEnumerable enumerable)
        {
            foreach (var e in enumerable)
            {
                Console.WriteLine(e);
            }
        }

        public static void PrintCollection(IList listLeft, IList listRight, string indentation = "")
        {
            if (listLeft.Count != listRight.Count) throw new InvalidOperationException("Lists must be the same size");

            for (int i = 0; i < listLeft.Count; i++)
            {
                Console.WriteLine(indentation + listLeft[i] + "\t" + listRight[i]);
            }
        }
    }
}
