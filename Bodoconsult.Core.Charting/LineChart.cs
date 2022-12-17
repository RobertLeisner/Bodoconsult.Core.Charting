// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Versioning;
using Bodoconsult.Core.Charting.Base.Models;
using ScottPlot;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Creates a line chart
    /// </summary>
    /// <typeparam name="T">input data type</typeparam>
    [SupportedOSPlatform("windows")]
    public class LineChart<T> : BaseChart<T> where T : ChartItemData
    {

        //private bool _isContinousXAxis;

        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            var style = ChartData.ChartStyle;
            var count = ChartData.DataSource.Count;

            IList<double> xvalues = new List<double>(count);
            IList<double> values1 = new List<double>(count);
            IList<double> values2 = new List<double>(count);
            IList<double> values3 = new List<double>(count);
            IList<double> values4 = new List<double>(count);
            IList<double> values5 = new List<double>(count);
            IList<double> values6 = new List<double>(count);
            IList<double> values7 = new List<double>(count);
            IList<double> values8 = new List<double>(count);
            IList<double> values9 = new List<double>(count);
            IList<double> values10 = new List<double>(count);
            IList<string> labels = new List<string>();
            IList<double> indexers = new List<double>();


            var isDate = false;

            var modulo = count / 10;

            for (var index = 0; index < count; index++)
            {
                var d = (ChartItemData)ChartData.DataSource[index];

                xvalues.Add(d.XValue);
                values1.Add(d.YValue1);
                values2.Add(d.YValue2);
                values3.Add(d.YValue3);
                values4.Add(d.YValue4);
                values5.Add(d.YValue5);
                values6.Add(d.YValue6);
                values7.Add(d.YValue7);
                values8.Add(d.YValue8);
                values9.Add(d.YValue9);
                values10.Add(d.YValue10);
                isDate = d.IsDate;

                if (string.IsNullOrEmpty(d.Label)) continue;
                if (index % modulo != 0) continue;
                labels.Add(d.Label);
                indexers.Add(d.XValue);
                //else
                //{
                //    labels.Add(null);
                //}
            }

            var xData = xvalues.ToArray();

            if (values1.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values1.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(0));
            if (values2.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values2.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(1));
            if (values3.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values3.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(2));
            if (values4.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values4.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(3));
            if (values5.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values5.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(4));
            if (values6.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values6.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(5));
            if (values7.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values7.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(6));
            if (values8.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values8.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(7));
            if (values9.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values9.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(8));
            if (values10.Any(x => Math.Abs(x) > 0.0000001)) PlotScatter(xData, values10.ToArray(), markerShape: MarkerShape.none, lineWidth: 2D, label: GetLabelForSeries(9));

            string formatX;
            var formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;

            if (isDate)
            {
                formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern : style.XAxisNumberformat;
                Chart.XAxis.TickLabelFormat(formatX, true);
                Chart.YAxis.TickLabelFormat(formatY, false);
            }
            else
            {
                formatX = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
                Chart.XAxis.TickLabelFormat(formatX, false);
                Chart.YAxis.TickLabelFormat(formatY, false);
            }

            // Titels for axis
            var label = string.IsNullOrEmpty(ChartData.XLabelText)
                ? ChartData.PropertiesToUseForChart[0]
                : ChartData.XLabelText;

            Chart.XAxis.Label(label, fontName: style.FontName, size: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            label = string.IsNullOrEmpty(ChartData.YLabelText)
                ? ChartData.PropertiesToUseForChart[1]
                : ChartData.YLabelText;

            Chart.YAxis.Label(label, fontName: style.FontName, size: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);


            if (labels.Any())
            {
                Chart.XTicks(indexers.ToArray(), labels.ToArray());
            }


            base.CreateChart();
        }

        private void PlotScatter(double[] xValues, double[] yValues, MarkerShape markerShape, double lineWidth, string label)
        {
            var sp = Chart.AddScatter(xValues, yValues);
            sp.MarkerShape = markerShape;
            sp.LineWidth = lineWidth;
            sp.Label = label;
            
            //Chart.PlotScatter(xValues, yValues, markerShape: markerShape, lineWidth: lineWidth, label: label);
        }


        /// <summary>
        /// Formatting the chart
        /// </summary>
        public override void Formatting()
        {
            base.Formatting();

            var style = ChartData.ChartStyle;

            //Chart.Legend(enableLegend: true, location: legendLocation.upperCenter, backColor: Color.WhiteSmoke, frameColor: Color.Transparent,
            //    fontSize: style.FontSize * style.LegendFontSizeDelta, bold: false, fontColor: style.FontColor);

            var legend = Chart.Legend();
            legend.IsVisible = true;
            legend.Location = Alignment.UpperCenter;
            legend.FillColor = Color.WhiteSmoke;
            legend.OutlineColor = Color.Transparent;
            legend.FontSize = style.FontSize * style.LegendFontSizeDelta;
            legend.FontColor = style.FontColor;
            legend.FontBold = false;


            Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor);
        }

    }
}