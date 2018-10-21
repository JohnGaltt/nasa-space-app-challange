namespace MarsAnalyzer.Data.Model
{
    public class PixelCondition
    {
        public int Id { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public double HeightMax { get; set; }
        public double HeightMin { get; set; }
        public int TemperatureMax { get; set; }
        public int TemperatureMin { get; set; }
        public int PressureMin { get; set; }
        public int PressureMax { get; set; }
    }
}