using Madaline.Neural;
using System;

namespace Madaline
{
    static class Program
    {
        static void Main(string[] args)
        {
            TemplatePattern[] templatePatterns;

            if (args.Length != 2)
            {
                //throw new ArgumentException("Provide arguments:\n" +
                //    "1. Path for file with template pattern\n" +
                //    "2. Identifier of template pattern");
                templatePatterns = new TemplatePattern[4]
                {
                    new TemplatePattern(Utils.FileToArray("../../../Data/1.txt"), "1"),
                    new TemplatePattern(Utils.FileToArray("../../../Data/X.txt"), "X"),
                    new TemplatePattern(Utils.FileToArray("../../../Data/Y.txt"), "Y"),
                    new TemplatePattern(Utils.FileToArray("../../../Data/Z.txt"), "Z")
                };
            }
            else
            {
                string path = args[0];
                string identifier = args[1];

                templatePatterns = new TemplatePattern[]
                {
                    new TemplatePattern(Utils.FileToArray(path), identifier)
                };
            }

            var network = new Network(templatePatterns);
            var output = network.Run();

            //for (int i = 0; i < output.Length; i++)
            //{
            //    Console.WriteLine($"Target: {templatePatterns[i].Identifier}\n" +
            //        $"Network (output, corresponding identifier):");
            //    for (int j = 0; j < output[i].Length; j++)
            //    {
            //        Console.WriteLine($"{output[i][j].Output}, {output[i][j].Identifier}");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
