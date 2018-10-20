namespace MarsAnalyzer.Data.Model
{
    public class PixelCondition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public double HeightCoef { get; set; }
        public double TemperatureCoef { get; set; }
        public double GravityCoef { get; set; }
    }
}