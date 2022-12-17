using System;
using System.Collections.Generic;
using Bodoconsult.Core.Typography.Charts;

namespace Bodoconsult.Core.Charting.Base.Models
{

    /// <summary>
    /// Contains all data needed for a chart
    /// </summary>
    public class ChartData: IChartData, ICloneable
    {

        /// <summary>
        /// Default ctor
        /// </summary>
        public ChartData()
        {
            BaseConstructor();
            DataSource = new List<IChartItemData>();
        }


        ///// <summary>
        ///// Constructor with default style to load
        ///// </summary>
        ///// <param name="style"></param>
        //public ChartData(DefaultStyles style)
        //{
        //    // ToDo: reaction on style
        //}


        ///// <summary>
        ///// Load style from a file
        ///// </summary>
        ///// <param name="fileNameStyleSheet">file name of a JSON serialiazed style sheet. Structure is derived from <see cref="ChartStyle"/></param>
        //public ChartData(string fileNameStyleSheet)
        //{
        //    // ToDo: reaction on fileName
        //}


        private void BaseConstructor()
        {
            ChartStyle = new ChartStyle();
            PropertiesToUseForChart = new List<string>();
            LabelsForSeries = new List<string>();
        }


        /// <summary>
        /// Data source to be shown in the chart
        /// </summary>
        public IList<IChartItemData> DataSource { get; set; }

        /// <summary>
        /// Contains all formatting properties of a chart
        /// </summary>
        public ChartStyle ChartStyle { get; set; }

        /// <summary>
        /// Chart type to use for the chart
        /// </summary>
        public ChartType ChartType { get; set; }

        /// <summary>
        /// File name the chart has to be saved to
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Contains all properties of the type contained in <see cref="ChartData.DataSource"/> to be used as chart series.
        /// First element is always used as X-Axis
        /// </summary>
        public IList<string> PropertiesToUseForChart { get; set; }


        /// <summary>
        /// Contains all the labels used for legends in a chart
        /// </summary>
        public IList<string> LabelsForSeries { get; set; }


        /// <summary>
        /// Title to print on the chart
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Text for Y-axis label
        /// </summary>
        public string YLabelText { get; set; }


        /// <summary>
        /// Text for X-axis label
        /// </summary>
        public string XLabelText { get; set; }

        /// <summary>
        /// Name of the property representing the X-Axis values
        /// </summary>
        public string XName { get; set; }


        /// <summary>
        /// Name of copyright holder to print on the chart
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Creates a shallow clone of the object. ChartStyle is cloned explicitly.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var erg = (ChartData)MemberwiseClone();
            erg.ChartStyle = (ChartStyle)ChartStyle.Clone();
            return erg;
        }
    }
}
