using Madaline.Neural;

namespace Madaline
{
    static class Program
    {
        static void Main()
        {
            var templatePatterns = new TemplatePattern[]
            {
                new TemplatePattern(
                    new float[16]
                    {
                        1, 0, 0, 1,
                        0, 1, 1, 0,
                        0, 1, 1, 0,
                        1, 0, 0, 1
                    }, "X"),
                new TemplatePattern(
                    new float[16]
                    {
                        1, 0, 0, 1,
                        0, 1, 1, 0,
                        0, 1, 0, 0,
                        1, 0, 0, 0
                    }, "Y"),
                new TemplatePattern(
                    new float[16]
                    {
                        1, 1, 1, 1,
                        0, 0, 1, 0,
                        0, 1, 0, 0,
                        1, 1, 1, 1
                    }, "Z"),
                new TemplatePattern(
                    new float[16]
                    {
                        0, 0, 1, 0,
                        0, 1, 1, 0,
                        0, 0, 1, 0,
                        0, 0, 1, 0
                    }, "1")
            };

            var network = new Network(templatePatterns);
            network.Run();
        }
    }
}
