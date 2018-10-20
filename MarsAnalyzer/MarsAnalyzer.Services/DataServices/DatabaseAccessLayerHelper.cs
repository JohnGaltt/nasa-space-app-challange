namespace MarsAnalyzer.Services.DataServices
{
    public class DatabaseAccessLayerHelper
    { 
        private static HeatMapHelper _heatMapHelper;
        public static HeatMapHelper HeatMapHelper => _heatMapHelper == null ? new HeatMapHelper() : _heatMapHelper;
    }
}