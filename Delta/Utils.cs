using Delta.Neural;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

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

        #region printers
        public static void PrintLists(string indentation, params IList[] lists)
        {
            for (int i = 0; i < lists[0].Count; i++)
            {
                Console.Write(indentation);
                for (uint li = 0; li < lists.Length; li++)
                {
                    Console.Write(string.Format("{0:F5}  ", lists[li][i]) + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void PrintValues(string indentation, params float[] values)
        {
            Console.Write(indentation);
            for (uint i = 0; i < values.Length; i++)
            {
                Console.Write(string.Format("{0:F5}  ", values[i]) + "\t");
            }
            Console.WriteLine();
        }
        #endregion printers

        #region extension methods
        public static float[] AggregateOutputs(this TrainingPattern[] trainingPattern)
        {
            var result = new float[trainingPattern.Length];
            for (uint i = 0; i < trainingPattern.Length; i++)
            {
                result[i] = trainingPattern[i].TargetOutput;
            }
            return result;
        }

        public static float[][] AggregateInputs(this TrainingPattern[] trainingPattern)
        {
            var result = new float[trainingPattern.Length][];
            for (uint i = 0; i < trainingPattern.Length; i++)
            {
                result[i] = trainingPattern[i].Inputs;
            }
            return result;
        }

        public static float SquaredMean(this float[] array)
        {
            var result = 0f;
            for (uint i = 0; i < array.Length; i++)
            {
                result += array[i] * array[i];
            }
            return result / array.Length;
        }

        public static List<float> ParseToReals(this string s)
        {
            var splitted = s.Split(' ');
            var result = new List<float>();
            for (int i = 0; i < splitted.Length; i++)
            {
                if (float.TryParse(splitted[i], NumberStyles.Any, CultureInfo.InvariantCulture.NumberFormat, out float value))
                {
                    result.Add(value);
                }
            }
            return result;
        }
        #endregion extension methods
    }
}
