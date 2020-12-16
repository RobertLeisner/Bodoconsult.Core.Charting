using System;
using System.Data;
using System.Drawing;
using Bodoconsult.Core.Charting.Base.Models;

namespace Bodoconsult.Core.Charting.Util
{
    /// <summary>
    /// Unitlities to support charts
    /// </summary>
    public class ChartUtility
    {

        ///// <summary>
        ///// Convert a <see cref="DataTable"/> to a list of <see cref="PieChartItemData"/> object
        ///// </summary>
        ///// <param name="dataTable"></param>
        ///// <param name="columns"></param>
        ///// <param name="chartData"></param>
        ///// <typeparam name="T"></typeparam>
        public static void DataTableToPieChartItemData(DataTable dataTable, string columns, ChartData chartData)
        {

            if (string.IsNullOrEmpty(columns)) columns = "1;2";

            var s = columns.Split(';');

            var colLabel = Convert.ToInt32(s[0]) - 1;
            var colValue = Convert.ToInt32(s[1]) - 1;


            for (var index = 0; index < dataTable.Rows.Count; index++)
            {
                var row = dataTable.Rows[index];
                var label = row[colLabel].ToString();

                if (string.IsNullOrEmpty(label)) continue;

                if (label.Equals("Gesamt") || label.Equals("Total")) continue;

                var item = new PieChartItemData
                {
                    XValue = label,
                    YValue = GetDouble(row[colValue].ToString())
                };

                chartData.DataSource.Add(item);
            }

            chartData.PropertiesToUseForChart.Add(dataTable.Columns[colValue].ColumnName);

        }

        ///// <summary>
        ///// Convert a <see cref="DataTable"/> to a list of <see cref="PieChartItemData"/> object
        ///// </summary>
        ///// <param name="dataTable"></param>
        ///// <param name="columns"></param>
        ///// <param name="chartData"></param>
        ///// <typeparam name="T"></typeparam>
        public static void DataTableToPointChartItemData(DataTable dataTable, string columns, ChartData chartData)
        {

            if (string.IsNullOrEmpty(columns)) columns = "1;2;3;4";

            columns = columns.Replace("(", "").Replace(")", "");


            var s = columns.Split(';');


            var colXValue = Convert.ToInt32(s[0]) - 1;
            var colYValue = Convert.ToInt32(s[1]) - 1;
            var colLabel = Convert.ToInt32(s[2]) - 1;
            var colColor = Convert.ToInt32(s[3]) - 1;


            for (var index = 0; index < dataTable.Rows.Count; index++)
            {
                var row = dataTable.Rows[index];
                var label = row[colLabel].ToString();

                if (string.IsNullOrEmpty(label)) continue;

                if (label.Equals("Gesamt") || label.Equals("Total")) continue;

                var item = new PointChartItemData
                {
                    Label = label,
                    XValue = GetDouble(row[colXValue].ToString()),
                    YValue = GetDouble(row[colYValue].ToString()),
                    Color = ColorTranslator.FromOle(Convert.ToInt32(row[colColor].ToString())),
                };

                chartData.DataSource.Add(item);
            }

            chartData.PropertiesToUseForChart.Add(dataTable.Columns[colXValue].ColumnName);
            chartData.PropertiesToUseForChart.Add(dataTable.Columns[colYValue].ColumnName);

        }

        ///// <summary>
        ///// Convert a <see cref="DataTable"/> to a list of <see cref="ChartItemData"/> object
        ///// </summary>
        ///// <param name="dataTable"></param>
        ///// <param name="columns"></param>
        ///// <param name="chartData"></param>
        ///// <typeparam name="T"></typeparam>
        public static void DataTableToChartItemData(DataTable dataTable, string columns, ChartData chartData)
        {
            int length;
            int[] columnArray;
            int colLabel;

            if (string.IsNullOrEmpty(columns))
            {
                length = dataTable.Columns.Count - 1;
                colLabel = 0;
                columnArray = new int[length];

                for (var i = 1; i <= length; i++)
                {
                    columnArray[i - 1] = i;
                }
            }
            else
            {
                var s = columns.Split(';');

                length = s.Length - 1;

                columnArray = new int[length];
                colLabel = Convert.ToInt32(s[0]) - 1;

                for (var i = 1; i <= length; i++)
                {
                    //Debug.Print($"{i}: {s[i]}");

                    columnArray[i - 1] = Convert.ToInt32(s[i]) - 1;
                }
            }


            var isDate = dataTable.Columns[colLabel].DataType == typeof(DateTime);


            for (var index = 0; index < dataTable.Rows.Count; index++)
            {
                var row = dataTable.Rows[index];

                var item = new ChartItemData();

                double label;
                if (isDate)
                {
                    label = ((DateTime)row.ItemArray[colLabel]).ToOADate();
                }
                else
                {
                    var success = double.TryParse(row.ItemArray[colLabel].ToString(), out var x);

                    if (success)
                    {
                        label = x;
                    }
                    else
                    {
                        label = index + 1;
                        item.Label = row.ItemArray[colLabel].ToString();
                    }
                }

                item.XValue = label;
                item.IsDate = isDate;



                switch (length)
                {
                    case 1:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        break;
                    case 2:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        break;
                    case 3:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        break;
                    case 4:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        break;
                    case 5:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        item.YValue5 = GetDouble(row[columnArray[4]].ToString());
                        break;
                    case 6:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        item.YValue5 = GetDouble(row[columnArray[4]].ToString());
                        item.YValue6 = GetDouble(row[columnArray[5]].ToString());

                        break;
                    case 7:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        item.YValue5 = GetDouble(row[columnArray[4]].ToString());
                        item.YValue6 = GetDouble(row[columnArray[5]].ToString());
                        item.YValue7 = GetDouble(row[columnArray[6]].ToString());
                        break;
                    case 8:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        item.YValue5 = GetDouble(row[columnArray[4]].ToString());
                        item.YValue6 = GetDouble(row[columnArray[5]].ToString());
                        item.YValue7 = GetDouble(row[columnArray[6]].ToString());
                        item.YValue8 = GetDouble(row[columnArray[7]].ToString());
                        break;
                    case 9:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        item.YValue5 = GetDouble(row[columnArray[4]].ToString());
                        item.YValue6 = GetDouble(row[columnArray[5]].ToString());
                        item.YValue7 = GetDouble(row[columnArray[6]].ToString());
                        item.YValue8 = GetDouble(row[columnArray[7]].ToString());
                        item.YValue9 = GetDouble(row[columnArray[8]].ToString());
                        break;
                    case 10:
                        item.YValue1 = GetDouble(row[columnArray[0]].ToString());
                        item.YValue2 = GetDouble(row[columnArray[1]].ToString());
                        item.YValue3 = GetDouble(row[columnArray[2]].ToString());
                        item.YValue4 = GetDouble(row[columnArray[3]].ToString());
                        item.YValue5 = GetDouble(row[columnArray[4]].ToString());
                        item.YValue6 = GetDouble(row[columnArray[5]].ToString());
                        item.YValue7 = GetDouble(row[columnArray[6]].ToString());
                        item.YValue8 = GetDouble(row[columnArray[7]].ToString());
                        item.YValue9 = GetDouble(row[columnArray[8]].ToString());
                        item.YValue10 = GetDouble(row[columnArray[9]].ToString());
                        break;
                    default:
                        throw new NotImplementedException("No valid number of columns!");
                }

                chartData.DataSource.Add(item);
            }

            chartData.PropertiesToUseForChart.Add(dataTable.Columns[colLabel].ColumnName);

            // Added series names to the Properties
            for (var i = 0; i < columnArray.Length; i++)
            {
                chartData.LabelsForSeries.Add(dataTable.Columns[columnArray[i]].ColumnName);
                chartData.PropertiesToUseForChart.Add(dataTable.Columns[columnArray[i]].ColumnName);
            }

        }


        /// <summary>
        /// Get a double from a string or 0 if no valid string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double GetDouble(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;

            var success = double.TryParse(value, out var x);

            return success ? x : 0;
        }



        /// <summary>
        /// Get the minimum and maximum for y-axis of a line Chart
        /// </summary>
        /// <param name="minimum">minimum value found in a Chart series for the line Chart</param>
        /// <param name="maximum">maximum value found in a Chart series for the line Chart</param>
        /// <returns>Interval for grid on y-axis</returns>
        public static double GetMinMaxForLineChart(ref double minimum, ref double maximum)
        {

            var delta = Math.Abs(maximum - minimum);

            var length = 0;

            if (delta < 1)
            {

                var deltaString = delta.ToString("0.0000000000000000");

                for (var i = 2; i < deltaString.Length; i++)
                {
                    if (deltaString[i] != '0')
                    {
                        length = i;
                        break;
                    }
                }

                length -= 1;

            }
            else
            {
                length = ((int)(delta)).ToString("0").Length - 2;
            }

            var p = Math.Pow(10, length);

            var count = (int)(delta / p);

            if (count > 10)
            {
                p *= 5;

                count = (int)(delta / p);

                if (count > 10)
                {
                    p *= 2;
                }
            }

            p = delta < 1 ? 1 / p : p;

            var min = Math.Floor(minimum / p) * p;
            var max = Math.Ceiling(maximum / p) * p;

            //if (max - maximum > 0.5 * x) max = max - 0.5 * (1 / x);
            //if (min - minimum > 0.5 * x) min = min + 0.5 * (1 / x);


            minimum = min;
            maximum = max;
            return p;

        }
    }
}
