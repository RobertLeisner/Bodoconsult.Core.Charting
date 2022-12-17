namespace Bodoconsult.Core.Charting.Base.Models
{
    /// <summary>
    /// Item data for a bar or column chart
    /// </summary>
    public class BarColumnChartItemData: IChartItemData
    {
        /// <summary>
        /// X axis value
        /// </summary>
        public string XValue { get; set; }

        /// <summary>
        /// Y axis value
        /// </summary>
        public double YValue { get; set; }

    }
}