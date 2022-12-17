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
    /// Creates a stacked column chart with columns adding always to 100%
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [SupportedOSPlatform("windows")]
    public class StackedColumn100Chart<T> : BaseChart<T> where T : ChartItemData
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

            var indexers = new double[ChartData.DataSource.Count];
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
                var ges = values1[index] + values2[index] + values3[index] + values4[index] + values5[index] + values6[index] +
                          values7[index] + values8[index] + values9[index] + values10[index];

                //Debug.Print($"A: {labels[index]}: {ges}:  {values1[index]} / {values2[index]} / {values3[index]} / {values4[index]} / {values5[index]} / {values6[index]} " +
                //            $"/ {values7[index]} / {values8[index]} / {values9[index]} / {values10[index]}");

                values1[index] = values1[index] / ges;
                values2[index] = values2[index] / ges;
                values3[index] = values3[index] / ges;
                values4[index] = values4[index] / ges;
                values5[index] = values5[index] / ges;
                values6[index] = values6[index] / ges;
                values7[index] = values7[index] / ges;
                values8[index] = values8[index] / ges;
                values9[index] = values9[index] / ges;
                values10[index] = values10[index] / ges;

                //Debug.Print($"B: {labels[index]}: {ges}:  {values1[index]} / {values2[index]} / {values3[index]} / {values4[index]} / {values5[index]} / {values6[index]} " +
                //            $"/ {values7[index]} / {values8[index]} / {values9[index]} / {values10[index]}");

                values2[index] = values2[index] + values1[index];
                values3[index] = values3[index] + values2[index];
                values4[index] = values4[index] + values3[index];
                values5[index] = values5[index] + values4[index];
                values6[index] = values6[index] + values5[index];
                values7[index] = values7[index] + values6[index];
                values8[index] = values8[index] + values7[index];
                values9[index] = values9[index] + values8[index];
                values10[index] = values10[index] + values9[index];

                values1[index] = Math.Round(values1[index], 2);
                values2[index] = Math.Round(values2[index], 2);
                values3[index] = Math.Round(values3[index], 2);
                values4[index] = Math.Round(values4[index], 2);
                values5[index] = Math.Round(values5[index], 2);
                values6[index] = Math.Round(values6[index], 2);
                values7[index] = Math.Round(values7[index], 2);
                values8[index] = Math.Round(values8[index], 2);
                values9[index] = Math.Round(values9[index], 2);
                values10[index] = Math.Round(values10[index], 2);

                //Debug.Print($"C: {labels[index]}: {ges}:  {values1[index]} / {values2[index]} / {values3[index]} / {values4[index]} / {values5[index]} / {values6[index]} " +
                //            $"/ {values7[index]} / {values8[index]} / {values9[index]} / {values10[index]}");

                //ges = values2[index] + values1[index] + values3[index] + values4[index] + values5[index] + values6[index] +
                //      values7[index] + values8[index] + values9[index] + values10[index];

                //Debug.Print($"{ges}");
            }

            if (countCol > 9) PlotBar(indexers, values10.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[9]);
            if (countCol > 8) PlotBar(indexers, values9.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[8]);
            if (countCol > 7) PlotBar(indexers, values8.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[7]);
            if (countCol > 6) PlotBar(indexers, values7.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[6]);
            if (countCol > 5) PlotBar(indexers, values6.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[5]);
            if (countCol > 4) PlotBar(indexers, values5.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[4]);
            if (countCol > 3) PlotBar(indexers, values4.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[3]);
            if (countCol > 2) PlotBar(indexers, values3.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[2]);
            if (countCol > 1) PlotBar(indexers, values2.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[1]);
            if (countCol > 0) PlotBar(indexers, values1.ToArray(), outlineColor: Color.Transparent, barWidth: 1D, outlineWidth: 0, label: ChartData.LabelsForSeries[0]);


            // customize the plot to make it look nicer
            Chart.Grid(enable: false, lineStyle: LineStyle.None);
            Chart.XAxis.Grid(false);
            Chart.YAxis.Grid(false);

            Chart.XTicks(labelIndexers.ToArray(), labels.ToArray());

            // Titels for axis
            var label = string.IsNullOrEmpty(ChartData.XLabelText)
                ? ChartData.PropertiesToUseForChart[0]
                : ChartData.XLabelText;

            Chart.XAxis.Label(label, fontName: style.FontName, size: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            label = string.IsNullOrEmpty(ChartData.YLabelText)
                ? ChartData.PropertiesToUseForChart[1]
                : ChartData.YLabelText;

            Chart.YAxis.Label(label, fontName: style.FontName, size: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            Chart.SetAxisLimits(yMin: 0, xMin: 0, yMax: 1);

            base.CreateChart();


        }

        private void PlotBar(double[] xValues, double[] yValues, Color outlineColor, double barWidth, int outlineWidth, string label)
        {
            var bar = Chart.AddBar(yValues, xValues);
            bar.BarWidth = barWidth;
            bar.BorderColor = outlineColor;
            bar.BorderLineWidth = outlineWidth;

            //Chart.PlotBar(indexers, toArray, horizontal: horizontal, outlineColor: outlineColor, barWidth: barWidth,
            //    outlineWidth: outlineWidth, label: label);
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
            Chart.YAxis.Grid(true);
            
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
        //    //c.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.IncreaseFont | LabelAutoFitStyles.WordWrap;

        //    //c.Position = Chart.Series.Count > 3 ? SmallerPositionChartArea() : DefaultPositionChartArea();

        //    //c.AxisY.Title = ChartData.YLabelText;
        //    //c.BorderColor = Color.Black;
        //    //c.BorderWidth = ChartData.ChartStyle.BorderLineWidth;
        //    //c.BorderDashStyle = ChartDashStyle.Solid;

        //    //var legend = new Legend("Default");
        //    //Chart.Legends.Add(legend);
        //    ////var legend = Chart.Legends["Default"];
        //    //legend.LegendStyle = LegendStyle.Table;
        //    //legend.Enabled = true;
        //    //legend.BackColor = Color.Transparent;
        //    //legend.Position = Chart.Series.Count > 3 ? EnhancedLegendPosition() : DefaultLegendPosition();
        //    //legend.Font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize*ChartData.ChartStyle.LegendFontSizeDelta, FontStyle.Regular);
        //    //legend.ForeColor = ChartData.ChartStyle.FontColor;
        //    //legend.Alignment = StringAlignment.Center;
        //    //legend.IsEquallySpacedItems = false;

        //    //foreach (var s in Chart.Series)
        //    //{
        //    //    s.ChartType = SeriesChartType.StackedColumn100;
        //    //    s.IsXValueIndexed = true;
        //    //    s.BorderWidth = ChartData.ChartStyle.SeriesLineWidth;
        //    //}

        //    base.Formatting();
        //}
    }
}