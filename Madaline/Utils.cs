using Madaline.Neural;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            neurons.OrderBy(x => -x.Output).ToArray();

        public static float[] FileToArray(string fileName)
        {
            List<float> fl = new List<float>();

            using (Stream stream = File.Open(@fileName, FileMode.Open))

            using (TextReader sr = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Trim().Split(',');
                    foreach (var item in arr)
                    {
                        fl.Add(Convert.ToInt32(item));
                    }
                }
            }

            float[] floatArray = fl.ToArray();
            return floatArray;
        }
    }
}
