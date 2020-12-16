using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Bodoconsult.Core.Charting.Base.Models;
using ScottPlot;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Create a histogram
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LineChartHistogram<T> : BaseChart<T>  where T: ChartItemData
    {

        //private bool _isContinousXAxis;

        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            var style = ChartData.ChartStyle;

            IList<double> xvalues = new List<double>();
            IList<double> values1 = new List<double>();
            //IList<double> values2 = new List<double>();
            //IList<double> values3 = new List<double>();
            //IList<double> values4 = new List<double>();
            //IList<double> values5 = new List<double>();
            //IList<double> values6 = new List<double>();
            //IList<double> values7 = new List<double>();
            //IList<double> values8 = new List<double>();
            //IList<double> values9 = new List<double>();
            //IList<double> values10 = new List<double>();

            var isDate = false;

            foreach (var item in ChartData.DataSource)
            {
                var d = (ChartItemData)item;

                xvalues.Add(d.XValue);
                values1.Add(d.YValue1);
                //values2.Add(d.YValue2);
                //values3.Add(d.YValue3);
                //values4.Add(d.YValue4);
                //values5.Add(d.YValue5);
                //values6.Add(d.YValue6);
                //values7.Add(d.YValue7);
                //values8.Add(d.YValue8);
                //values9.Add(d.YValue9);
                //values10.Add(d.YValue10);
                isDate = d.IsDate;
            }

            var xData = xvalues.ToArray();

            var barWidth = 1 / ((double) xData.Length*10) ;

            if (values1.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(xData, values1.ToArray(), barWidth: barWidth);
            //if (values2.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values2.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(1));
            //if (values3.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values3.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(2));
            //if (values4.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values4.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(3));
            //if (values5.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values5.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(4));
            //if (values6.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values6.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(5));
            //if (values7.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values7.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(6));
            //if (values8.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values8.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(7));
            //if (values9.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values9.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(8));
            //if (values10.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotScatter(xData, values10.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(9));


            string formatX;
            string formatY;
            if (isDate)
            {
                formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern : style.XAxisNumberformat;
                formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern : style.YAxisNumberformat;
                Chart.Ticks(dateTimeX: true, dateTimeFormatStringX: formatX, numericFormatStringY: formatY);
            }
            else
            {
                formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
                formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;
                Chart.Ticks(dateTimeX: false, numericFormatStringX: formatX, numericFormatStringY: formatY);
            }

            //Chart.Legend(enableLegend: true, location: legendLocation.upperCenter);


            base.CreateChart();


        }

        /// <summary>
        /// Formatting the chart
        /// </summary>
        public override void Formatting()
        {
            
            base.Formatting();

            var style = ChartData.ChartStyle;

            Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor, enableVertical: false, enableHorizontal: true);
        }


    }

}