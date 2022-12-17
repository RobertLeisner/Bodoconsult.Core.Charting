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
    /// Creates a stacked bar chart
    /// </summary>
    /// <typeparam name="T">input data type</typeparam>
    [SupportedOSPlatform("windows")]
    public class StackedBarChart<T> : BaseChart<T> where T : ChartItemData
    {
        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            if (!ChartData.DataSource.Any())
            {
                return;
            }

            var style = ChartData.ChartStyle;
            var count = ChartData.DataSource.Count;

            // IList<double> xvalues = new List<double>();
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



            var isDate = ((ChartItemData)ChartData.DataSource[0]).IsDate;

            var indexers = new double[count];
            var labels = new List<string>();
            var labelIndexers = new List<double>();

            var format = "";

            var modulo = count / 10;

            for (var index = 0; index < count; index++)
            {
                var item = ChartData.DataSource[index];
                var d = (ChartItemData)item;

                //xvalues.Add(d.XValue);
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

                indexers[index] = index;

                if (string.IsNullOrEmpty(d.Label))
                {
                    if (isDate)
                    {
                        if (string.IsNullOrEmpty(format)) format = string.IsNullOrEmpty(style.XAxisNumberformat) ? CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern : style.XAxisNumberformat;
                        if (index % modulo == 0)
                        {
                            labelIndexers.Add(index);
                            labels.Add(DateTime.FromOADate(d.XValue).ToString(format));
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(format)) format = string.IsNullOrEmpty(style.XAxisNumberformat) ? "0" : style.XAxisNumberformat;
                        if (index % modulo == 0)
                        {
                            labelIndexers.Add(index);
                            labels.Add(Convert.ToDouble(d.XValue).ToString(format));
                        }
                    }
                }
                else
                {
                    if (index % modulo == 0)
                    {
                        labelIndexers.Add(index);
                        labels.Add(d.Label);
                    }
                }

            }

            int countCol = 0;
            if (values1.Any(x => Math.Abs(x) > 0.0000001)) countCol = 1;
            if (values2.Any(x => Math.Abs(x) > 0.0000001)) countCol = 2;
            if (values3.Any(x => Math.Abs(x) > 0.0000001)) countCol = 3;
            if (values4.Any(x => Math.Abs(x) > 0.0000001)) countCol = 4;
            if (values5.Any(x => Math.Abs(x) > 0.0000001)) countCol = 5;
            if (values6.Any(x => Math.Abs(x) > 0.0000001)) countCol = 6;
            if (values7.Any(x => Math.Abs(x) > 0.0000001)) countCol = 7;
            if (values8.Any(x => Math.Abs(x) > 0.0000001)) countCol = 8;
            if (values9.Any(x => Math.Abs(x) > 0.0000001)) countCol = 9;
            if (values10.Any(x => Math.Abs(x) > 0.0000001)) countCol = 10;

            for (var index = 0; index < values1.Count; index++)
            {
                if (index > 0) values2[index] = values2[index] + values1[index];
                if (index > 1) values3[index] = values3[index] + values2[index];
                if (index > 2) values4[index] = values4[index] + values3[index];
                if (index > 3) values5[index] = values5[index] + values4[index];
                if (index > 4) values6[index] = values6[index] + values5[index];
                if (index > 5) values7[index] = values7[index] + values6[index];
                if (index > 6) values8[index] = values8[index] + values7[index];
                if (index > 7) values9[index] = values9[index] + values8[index];
                if (index > 8) values10[index] = values10[index] + values9[index];
            }

            if (countCol > 9) PlotBar(indexers, values10.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 8) PlotBar(indexers, values9.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 7) PlotBar(indexers, values8.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 6) PlotBar(indexers, values7.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 5) PlotBar(indexers, values6.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 4) PlotBar(indexers, values5.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 3) PlotBar(indexers, values4.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 2) PlotBar(indexers, values3.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 1) PlotBar(indexers, values2.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);
            if (countCol > 0) PlotBar(indexers, values1.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0);


            // customize the plot to make it look nicer
            Chart.XAxis.Grid(false);

            Chart.YTicks(labelIndexers.ToArray(), labels.ToArray());

            // customize the plot to make it look nicer
            Chart.YAxis.Grid(false);

            // Titels for axis
            var label = string.IsNullOrEmpty(ChartData.YLabelText)
                ? ChartData.PropertiesToUseForChart[1]
                : ChartData.YLabelText;

            Chart.XAxis.Label(label, fontName: style.FontName, size: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            label = string.IsNullOrEmpty(ChartData.XLabelText)
                ? ChartData.PropertiesToUseForChart[0]
                : ChartData.XLabelText;

            Chart.YAxis.Label(label, fontName: style.FontName, size: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);
            
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

            base.CreateChart();

            
        }

        private void PlotBar(double[] xValues, double[] yValues, Color outlineColor, double barWidth, int outlineWidth)
        {
            var bar = Chart.AddBar(yValues, xValues);
            bar.BarWidth = barWidth;
            bar.Orientation = Orientation.Horizontal;
            bar.BorderColor = outlineColor;
            bar.BorderLineWidth = outlineWidth;

            //Chart.PlotBar(xValues, yValues, horizontal: horizontal, outlineColor: outlineColor, barWidth: barWidth,
            //    outlineWidth: outlineWidth);
        }


        /// <summary>
        /// Formatting the chart
        /// </summary>
        public override void Formatting()
        {
            base.Formatting();

            var style = ChartData.ChartStyle;

            var legend = Chart.Legend();
            legend.IsVisible = true;
            legend.Location = Alignment.LowerRight;
            legend.FillColor = Color.WhiteSmoke;
            legend.OutlineColor = Color.Transparent;
            legend.FontSize = style.FontSize * style.LegendFontSizeDelta;
            legend.FontColor = style.FontColor;
            legend.FontBold = false;


            Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor);
            Chart.XAxis.Grid(true);
            Chart.YAxis.Grid(false);

            
        }

        ///// <summary>
        ///// Formatting the chart
        ///// </summary>
        //public override void Formatting()
        //{

        //    //var c = Chart.ChartAreas["Default"];
        //    //c.Area3DStyle.Enable3D = false;
        //    //c.Area3DStyle.Rotation = 0;
        //    //c.AlignmentStyle = AreaAlignmentStyles.All;
        //    //c.AxisX.IsMarginVisible = false;
        //    //c.AxisX.Title = ChartData.XLabelText;
        //    //c.AxisX.IsLabelAutoFit = true;
        //    //c.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont |
        //    //                            LabelAutoFitStyles.IncreaseFont |
        //    //                            LabelAutoFitStyles.WordWrap;
        //    //c.Position = Chart.Series.Count > 3 ? SmallerPositionChartArea() : DefaultPositionChartArea();


        //    //c.AxisY.Title = ChartData.YLabelText;
        //    //c.BorderColor = Color.Black;
        //    //c.BorderWidth = ChartData.ChartStyle.BorderLineWidth;
        //    //c.BorderDashStyle = ChartDashStyle.Solid;


        //    //c.AxisY.MajorGrid.LineColor = ChartData.ChartStyle.GridLineColor;
        //    //c.AxisX.MajorGrid.LineColor = ChartData.ChartStyle.GridLineColor;

        //    //c.AxisX.LineColor = ChartData.ChartStyle.AxisLineColor;
        //    //c.AxisY.LineColor = ChartData.ChartStyle.AxisLineColor;


        //    //// Legend
        //    //var legend = new Legend("Default");
        //    //Chart.Legends.Add(legend);
        //    //legend.LegendStyle = LegendStyle.Row;
        //    //legend.Enabled = true;
        //    //legend.BackColor = Color.Transparent;
        //    //legend.ForeColor = ChartData.ChartStyle.FontColor;
        //    //legend.Position = Chart.Series.Count > 3 ? EnhancedLegendPosition() : DefaultLegendPosition();
        //    //legend.Font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.LegendFontSizeDelta, FontStyle.Regular);
        //    //legend.Alignment = StringAlignment.Center;
        //    //legend.IsEquallySpacedItems = false;

        //    //foreach (var s in Chart.Series)
        //    //{
        //    //    s.ChartType = SeriesChartType.StackedBar;
        //    //    s.IsXValueIndexed = true;
        //    //    s.BorderWidth = ChartData.ChartStyle.SeriesLineWidth;
        //    //}

        //    base.Formatting();

        //    AdjustLabels();
        //}


    }
}