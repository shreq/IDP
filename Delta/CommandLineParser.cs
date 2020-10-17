using CommandLine;

namespace Delta
{
    class CommandLineParser
    {
        public PatternScenario Scenario => Scenario_ == 'M' ? PatternScenario.MultiPattern : PatternScenario.SinglePattern;

        [Option('s', "scenario",
            Default = 'S',
            HelpText = "\nChoose between [S]ingle Training Pattern and [M]ultiple Training Patterns scenarios")]
        public char Scenario_ { get; set; }

        [Option('p', "patterns",
            Default = Settings.numberOfPatternsDefault,
            HelpText = "\nNumber of patterns. Works only with Multiple Training Patterns scenario")]
        public uint NumberOfPatterns { get; set; }

        [Option('i', "inputs",
            Default = Settings.numberOfInputsDefault,
            HelpText = "\nNumber of inputs")]
        public uint NumberOfInputs { get; set; }

        [Option('e', "epochs",
            Default = Settings.numberOfEpochsDefault,
            HelpText = "\nNumber of epochs")]
        public uint NumberOfEpochs { get; set; }

        [Option('t', "trainingstep",
            Default = Settings.trainingStepDefault,
            HelpText = "\nTraining step")]
        public float TrainingStep { get; set; }

        [Option("wmin",
            Default = Settings.weightMinDefault,
            HelpText = "\nWeight minimum value (exclusive)")]
        public float WeightMin { get; set; }

        [Option("wmax",
            Default = Settings.weightMaxDefault,
            HelpText = "\nWeight maximum value (inclusive)")]
        public float WeightMax { get; set; }

        [Option("vmin",
            Default = Settings.valueMinDefault,
            HelpText = "\nInput/Desired output minimum value (exclusive)")]
        public float ValueMin { get; set; }

        [Option("vmax",
            Default = Settings.valueMaxDefault,
            HelpText = "\nInput/Desired output maximum value (inclusive)")]
        public float ValueMax { get; set; }

        public bool VerboseOutput => VerboseOutput_ != 'F';

        [Option('v', "verbose",
            Default = 'T',
            HelpText = "\nChoose [T]rue to provide more detailed output. Otherwise choose [F]alse")]
        public char VerboseOutput_ { get; set; }

        public static void UpdateSettings(CommandLineParser commandLineParser)
        {
            Settings.Scenario = commandLineParser.Scenario;
            Settings.NumberOfPatterns = commandLineParser.NumberOfPatterns;
            Settings.NumberOfInputs = commandLineParser.NumberOfInputs;
            Settings.NumberOfEpochs = commandLineParser.NumberOfEpochs;
            Settings.TrainingStep = commandLineParser.TrainingStep;
            Settings.WeightMin = commandLineParser.WeightMin;
            Settings.WeightMax = commandLineParser.WeightMax;
            Settings.ValueMin = commandLineParser.ValueMin;
            Settings.ValueMax = commandLineParser.ValueMax;
            Settings.VerboseOutput = commandLineParser.VerboseOutput;
        }
    }
}
