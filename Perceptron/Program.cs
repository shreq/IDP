using Perceptron.Neural;

namespace Perceptron
{
    static class Program
    {
        static void Main()
        {
            var trainingPatterns = new TrainingPattern[]
            {
                new TrainingPattern(new float[] { 1, 0, 0, 0 }, new float[] { 1, 0, 0, 0 }),
                new TrainingPattern(new float[] { 0, 1, 0, 0 }, new float[] { 0, 1, 0, 0 }),
                new TrainingPattern(new float[] { 0, 0, 1, 0 }, new float[] { 0, 0, 1, 0 }),
                new TrainingPattern(new float[] { 0, 0, 0, 1 }, new float[] { 0, 0, 0, 1 })
            };

            var network = new Network(trainingPatterns, new Settings(
                hiddenLayerSize: 5,
                biasEnabled: false,
                maximumNumberOfEpochs: 300_000,
                numberOfTrainingPatternsToUse: 4,
                verboseOutput: false
            ));
            network.Train();

            network.PrintFinalResults();
        }
    }
}
