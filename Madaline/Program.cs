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
                     Utils.fileToArray("X.txt"), "X"),
                 new TemplatePattern(
                     Utils.fileToArray("Y.txt"), "Y"),
                  new TemplatePattern(
                     Utils.fileToArray("Z.txt"), "Z"),
                   new TemplatePattern(
                     Utils.fileToArray("1.txt"), "1"),
            };

            var network = new Network(templatePatterns);
            network.Run();
        }
    }
}
