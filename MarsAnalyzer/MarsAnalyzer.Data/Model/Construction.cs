using MarsAnalyzer.Data.Enums;

namespace MarsAnalyzer.Data.Model
{
    public class Construction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ReliefTypes ReliefType { get; set; }
        public InstallationType InstallationType { get; set; }
        public string SketchupId { get; set; }
        
        public int X { get; set; }
        public int Y { get; set; }
    }
}