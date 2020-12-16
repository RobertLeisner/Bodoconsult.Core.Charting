using System.Drawing;

namespace Bodoconsult.Core.Charting.Base.Models
{

    /// <summary>
    /// Point item to show in a point chart
    /// </summary>
    public class PointChartItemData: IChartItemData
    {
        /// <summary>
        /// X axis value
        /// </summary>
        public double XValue { get; set; }

        /// <summary>
        /// Y axis value
        /// </summary>
        public double YValue { get; set; }

        /// <summary>
        /// Label for the data point
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Color index for the data point
        /// </summary>
        public Color Color { get; set; }

    }
}
