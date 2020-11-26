using Madaline.Neural;
using System;

namespace Madaline
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args is null) throw new ArgumentException();
            string path =  args[0];
            string identifier = args[1];
 

            var templatePatterns = new TemplatePattern[]
            {               
                new TemplatePattern(
                     Utils.fileToArray(path), identifier)
            };

            var network = new Network(templatePatterns);
            network.Run(); 
        }
    }
}
