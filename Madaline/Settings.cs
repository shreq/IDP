namespace Madaline
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S2223:Non-constant static fields should not be visible", Justification = "<Pending>")]
    static class Settings
    {
        public static float TrainingStep = 0.0001f;
        public static float ValueMin = -1f;
        public static float ValueMax = 1f;
        public static float WeightMin = -1f;
        public static float WeightMax = 1f;
    }
}
