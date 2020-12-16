using System.Collections.Generic;
using Bodoconsult.Core.Typography.Charts;

namespace Bodoconsult.Core.Charting.Base.Models
{
    public interface IChartData
    {


        /// <summary>
        /// Data source to be shown in the chart
        /// </summary>
        IList<IChartItemData> DataSource { get; set; }

        /// <summary>
        /// Contains all formatting properties of a chart
        /// </summary>
        ChartStyle ChartStyle { get; set; }

        /// <summary>
        /// Chart type to use for the chart
        /// </summary>
        ChartType ChartType { get; set; }

        /// <summary>
        /// File name the chart has to be saved to
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Contains all properties of the type contained in <see cref="ChartData{T}.DataSource"/> to be used as chart series.
        /// First element is always used as X-Axis
        /// </summary>
        IList<string> PropertiesToUseForChart { get; set; }


        /// <summary>
        /// Contains all the labels used for legends in a chart
        /// </summary>
        IList<string> LabelsForSeries { get; set; }


        /// <summary>
        /// Title to print on the chart
        /// </summary>
        string Title { get; set; }


        /// <summary>
        /// Text for Y-axis label
        /// </summary>
        string YLabelText { get; set; }


        /// <summary>
        /// Text for X-axis label
        /// </summary>
        string XLabelText { get; set; }

        /// <summary>
        /// Name of the property representing the X-Axis values
        /// </summary>
        string XName { get; set; }


        /// <summary>
        /// Name of copyright holder to print on the chart
        /// </summary>
        string Copyright { get; set; }

        /// <summary>
        /// Creates a shallow clone of the object. ChartStyle is cloned explicitly.
        /// </summary>
        /// <returns></returns>
        object Clone();

    }
}