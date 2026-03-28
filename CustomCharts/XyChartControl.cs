using System.Windows.Forms.DataVisualization.Charting;

namespace CustomCharts
{
    public class XyChartControl : BaseChartControl
    {
        protected override SeriesChartType GetChartType()
        {
            return SeriesChartType.Line;
        }
    }
}