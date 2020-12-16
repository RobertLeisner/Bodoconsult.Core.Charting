using System;
using System.Globalization;
using System.Linq;
using Bodoconsult.Core.Charting.Base.Models;
using ScottPlot;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Creates a column chart
    /// </summary>
    /// <typeparam name="T">input data type</typeparam>
    public class ColumnChart<T> : BaseChart<T> where T: ChartItemData
    {
        /// <summary>
        /// Creates the chart
        /// </summary>
        public override void CreateChart()
        {

            var style = ChartData.ChartStyle;

            var labels = new string[ChartData.DataSource.Count];
            var indexers = new double[ChartData.DataSource.Count];
            var values1 = new double[ChartData.DataSource.Count];
            var values2 = new double[ChartData.DataSource.Count];
            var values3 = new double[ChartData.DataSource.Count];
            var values4= new double[ChartData.DataSource.Count];
            var values5 = new double[ChartData.DataSource.Count];
            var values6 = new double[ChartData.DataSource.Count];
            var values7 = new double[ChartData.DataSource.Count];
            var values8 = new double[ChartData.DataSource.Count];
            var values9 = new double[ChartData.DataSource.Count];
            var values10 = new double[ChartData.DataSource.Count];

            for (var index = 0; index < ChartData.DataSource.Count; index++)
            {
                var item = (ChartItemData)ChartData.DataSource[index];

                if (!string.IsNullOrEmpty(item.Label))
                {
                    labels[index] = item.Label;
                    item.XValue = index;
                }
                else
                {
                    labels[index] = item.XValue.ToString(CultureInfo.CurrentCulture);
                }
                
                indexers[index] = index;
                values1[index] = item.YValue1;
                values2[index] = item.YValue2;
                values3[index] = item.YValue3;
                values4[index] = item.YValue4;
                values5[index] = item.YValue5;
                values6[index] = item.YValue6;
                values7[index] = item.YValue7;
                values8[index] = item.YValue8;
                values9[index] = item.YValue9;
                values10[index] = item.YValue10;
            }

            

            if (values1.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values1);
            if (values2.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values2);
            if (values3.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values3);
            if (values4.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values4);
            if (values5.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values5);
            if (values6.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values6);
            if (values7.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values7);
            if (values8.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values8);
            if (values9.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values9);
            if (values10.Any(x => Math.Abs(x) > 0.0000001)) Chart.PlotBar(indexers, values10);


            // customize the plot to make it look nicer
            Chart.Grid(enableVertical: false, lineStyle: LineStyle.Dot);

            Chart.XTicks(indexers, labels);

            // Titels for axis
            var label = string.IsNullOrEmpty(ChartData.XLabelText)
                ? ChartData.PropertiesToUseForChart[0]
                : ChartData.XLabelText;

            Chart.XLabel(label, fontName: style.FontName, fontSize: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            label = string.IsNullOrEmpty(ChartData.YLabelText)
                ? ChartData.PropertiesToUseForChart[1]
                : ChartData.YLabelText;

            Chart.YLabel(label, fontName: style.FontName, fontSize: style.FontSize * style.AxisTitleFontSizeDelta, bold: true);

            var formatY = string.IsNullOrEmpty(style.YAxisNumberformat) ? "0" : style.YAxisNumberformat;
            Chart.Ticks(dateTimeY: false, numericFormatStringY: formatY);

            base.CreateChart();


            
            
        }

        /// <summary>
        /// Formatting the chart
        /// </summary>
        public override void Formatting()
        {
            base.Formatting();

            var style = ChartData.ChartStyle;

            Chart.Grid(enable: true, lineStyle: LineStyle.Dash, color: style.GridLineColor, enableHorizontal: true, enableVertical: false);


        }


    }
}