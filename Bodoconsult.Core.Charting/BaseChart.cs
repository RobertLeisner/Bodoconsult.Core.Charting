using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Bodoconsult.Core.Charting.Base.Models;
using ScottPlot;

//using GradientStyle = System.Web.UI.DataVisualization.Charting.GradientStyle;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Contains basic functionality for all types of charts in the current library
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseChart<T> : IChart where T : IChartItemData
    {
        /// <summary>
        /// MS-Chart object: maybe used for advanced customizing
        /// </summary>
        public Plot Chart;

        /// <summary>
        /// Contains all data to use in the Chart
        /// </summary>
        public virtual ChartData ChartData { get; set; }



        public void InitChart()
        {

            if (ChartData.ChartStyle.ChartBorderCornerRadius == 0)
            {
                Chart = new Plot((int)(0.94*ChartData.ChartStyle.Width), (int)(0.94*ChartData.ChartStyle.Height));
            }
            else
            {
                var d = (int)(2 * 0.5 * ChartData.ChartStyle.ChartBorderCornerRadius);
                Chart = new Plot(ChartData.ChartStyle.Width-d, ChartData.ChartStyle.Height-d);
            }

            
            Chart.AntiAlias(true, true, true);
            Chart.Grid(enable: false);
        }



        /// <summary>
        /// Get names of all properties to be used as series data
        /// </summary>
        /// <returns></returns>
        public IList<string> GetSeriesNames()
        {
            return ChartData.PropertiesToUseForChart.Skip(1).ToList();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseChart()
        {

            

            ////@"Templates\

            ////Template = "Default.xml";
            //Chart.RenderType = RenderType.BinaryStreaming;
            //// Set Antialiasing mode
            //Chart.AntiAliasing = AntiAliasingStyles.All;
            //Chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            //// Chart Area
            //var c = new ChartArea("Default")
            //{
            //    AxisY = { IsMarginVisible = false },
            //    AxisX = { IsMarginVisible = false },
            //    Area3DStyle = { Rotation = 0 },
            //};


            //Chart.ChartAreas.Add(c);

        }


        ///// <summary>
        ///// Default position of the chart area
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //public virtual ElementPosition DefaultPositionChartArea()
        //{
        //    return new ElementPosition(5, 12, 95, 83);
        //}


        ///// <summary>
        ///// Position of the chart area needing smaller space
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //public virtual ElementPosition SmallerPositionChartArea()
        //{
        //    return new ElementPosition(5, 19F, 95, 75.5F);
        //}



        ///// <summary>
        ///// Wide position of the chart area
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //public virtual ElementPosition WidePositionChartArea()
        //{
        //    return new ElementPosition(5, 8.5F, 95, 83);
        //}




        ///// <summary>
        ///// Default position of the legend
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //public virtual ElementPosition DefaultLegendPosition()
        //{
        //    return new ElementPosition(5, 8.5F, 95, 3.5F);
        //}

        ///// <summary>
        ///// Position of the legend providing more space for the legend
        ///// </summary>
        ///// <returns>Element position</returns>
        //public virtual ElementPosition EnhancedLegendPosition()
        //{
        //    return new ElementPosition(5, 8.5F, 95, 11F);
        //}

        ///// <summary>
        ///// Position of the Copyright
        ///// </summary>
        ///// <returns>Element position</returns>
        //public virtual ElementPosition CopyrightPosition()
        //{
        //    return new ElementPosition(70, 94f, 30, 4);
        //}

        /// <summary>
        /// Creates the chart
        /// </summary>
        public virtual void CreateChart()
        {
            AddTitle();
            AddCopyright();
        }

        /// <summary>
        /// Render the chart to a PNG image
        /// </summary>
        /// <returns></returns>
        public MemoryStream RenderImagePng()
        {
            var image = new MemoryStream();


            ////var c = Chart.ChartAreas["Default"];

            //Chart.BorderSkin.SkinStyle = BorderSkinStyle.None;
            //Chart.SaveImage(image, ChartImageFormat.Png);


            var bitmap = Chart.GetBitmap();

            bitmap.Save(image, System.Drawing.Imaging.ImageFormat.Png);

            return image;
        }



        /// <summary>
        /// Add a copyright to the chart
        /// </summary>
        public virtual void AddCopyright()
        {
            // Copyright
            if (string.IsNullOrEmpty(ChartData.Copyright)) return;

            //var copyright = new Title(ChartData.Copyright, Docking.Top,
            //    new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.CopyrightFontSizeDelta, FontStyle.Regular),
            //    ChartData.ChartStyle.CopyrightColor)
            //{
            //    Name = "Copyright"
            //};
            //Chart.Titles.Add(copyright);

            //Chart.GetBitmap(true); // force a render to force drawing/placing the legend

            ////Chart.GetSettings(false).title.

            //var settings = Chart.GetSettings(false);


            //var g = settings.gfxFigure;

            //var stringFormat = new StringFormat(StringFormat.GenericTypographic) {Alignment = StringAlignment.Far};

            //using (var font = new Font(ChartData.ChartStyle.FontName,
            //    ChartData.ChartStyle.FontSize * ChartData.ChartStyle.CopyrightFontSizeDelta, FontStyle.Regular))
            //{

            //    using (var brush = new SolidBrush(ChartData.ChartStyle.CopyrightColor))
            //    {

            //        var y = settings.dataOrigin.Y;

            //        var rect = new RectangleF(settings.dataOrigin.X, y, settings.dataSize.Width, 15);


            //        g.DrawString(ChartData.Copyright, font, brush, rect, stringFormat);
            //    }
            //}

            //var position = CopyrightPosition();

            //Chart.PlotText("Hallo", 10,
            //    y: 0.5);



            //var customPlottable = new PlottableText(text: ChartData.Copyright,
            //    x: position.X,
            //    y: position.Y,
            //    color: ChartData.ChartStyle.CopyrightColor,
            //    fontName: ChartData.ChartStyle.FontName,
            //    fontSize: ChartData.ChartStyle.FontSize * ChartData.ChartStyle.CopyrightFontSizeDelta,
            //    bold: false,
            //    label: "",
            //    alignment: TextAlignment.lowerLeft,
            //    rotation: 0,
            //    frame: false,
            //    frameColor: System.Drawing.Color.Green);

            //var customPlottable = new PlottableAnnotation(settings.dataOrigin.X+settings.dataSize.Width-20, settings.dataOrigin.Y, ChartData.Copyright,
            //    ChartData.ChartStyle.FontSize *
            //    ChartData.ChartStyle.CopyrightFontSizeDelta,
            //    ChartData.ChartStyle.FontName,
            //    ChartData.ChartStyle.CopyrightColor, false, Color.Crimson, 0, Color.Crimson, false);

            //var customPlottable = new PlottableAnnotation(text: 

            //    color: ChartData.ChartStyle.CopyrightColor,
            //    fontName: ChartData.ChartStyle.FontName,
            //    fontSize: ChartData.ChartStyle.FontSize * ChartData.ChartStyle.CopyrightFontSizeDelta,
            //    bold: false,
            //    label: "",
            //    alignment: TextAlignment.lowerLeft,
            //    rotation: 0,
            //    frame: false,
            //    frameColor: System.Drawing.Color.Green);

            //// you can access properties which may not be exposed by a Plot method
            //customPlottable.rotation = 45;

            // add the custom plottable to the list of plottables like this
            //Chart.GetPlottables().Add(customPlottable);

        }
        /// <summary>
        /// Add a title to the chart
        /// </summary>
        public virtual void AddTitle()
        {

            Chart.Title(ChartData.Title,true, 
                ChartData.ChartStyle.TitleFontName, 
                ChartData.ChartStyle.FontSize * ChartData.ChartStyle.TitleFontSizeDelta, 
                ChartData.ChartStyle.TitleColor);

            //var t = new Title(ChartData.Title, Docking.Top)
            //{
            //    Name = "Titel",
            //    Position = new ElementPosition(5, 2.5F, 95, 5),
            //    Font = new Font(ChartData.ChartStyle.TitleFontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.TitleFontSizeDelta, FontStyle.Bold),
            //    ForeColor = ChartData.ChartStyle.TitleColor,
                

            //};

            //if (ChartData.ChartStyle.TitleShadow)
            //{
            //    t.ShadowColor = Color.Gray;
            //    t.ShadowOffset = 2;
            //}

            //Chart.Titles.Add(t);
        }


        /// <summary>
        /// Base formatting for the chart
        /// </summary>
        public virtual void Formatting()
        {

            Chart.Frame(left: true, bottom: true, top: false, right: false, frameColor: ChartData.ChartStyle.AxisLineColor);

            Chart.Style(dataBg: ChartData.ChartStyle.BackgroundColor, 
                figBg: Color.Transparent, 
                grid: ChartData.ChartStyle.AxisLineColor, 
                label: ChartData.ChartStyle.AxisLineColor, 
                title: ChartData.ChartStyle.TitleColor);


            //Chart.Width = new Unit(ChartData.ChartStyle.Width, UnitType.Pixel);
            //Chart.Height = new Unit(ChartData.ChartStyle.Height, UnitType.Pixel);

            //Chart.BorderWidth = new Unit(ChartData.ChartStyle.ChartBorderWidth);
            //Chart.BorderColor = ChartData.ChartStyle.ChartBorderColor;
            //Chart.BackGradientStyle = (GradientStyle)ChartData.ChartStyle.ChartBackgroundGradientStyle;
            //Chart.BackColor = ChartData.ChartStyle.ChartBackgroundColor;
            //Chart.BackSecondaryColor = ChartData.ChartStyle.ChartBackgroundSecondColor;





            //var titel = Chart.Titles[0];
            //titel.Position = new ElementPosition(5, 2.5F, 95, 5);
            //titel.Font = new Font(ChartData.ChartStyle.TitleFontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.TitleFontSizeDelta, FontStyle.Bold);
            //titel.ForeColor = ChartData.ChartStyle.TitleColor;

            //if (ChartData.ChartStyle.TitleShadow)
            //{
            //    titel.ShadowColor = Color.Gray;
            //    titel.ShadowOffset = 3;
            //}

            //var area = Chart.ChartAreas[0];

            //area.BackColor = ChartData.ChartStyle.BackgroundColor;
            //area.BackSecondaryColor = ChartData.ChartStyle.BackgroundSecondColor;
            //area.BackGradientStyle = (GradientStyle)ChartData.ChartStyle.BackGradientStyle;
            //area.AxisY.IsMarginVisible = false;
            //area.AxisX.IsMarginVisible = false;
            //area.AxisX.LabelStyle.Font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.AxisLabelFontSizeDelta, FontStyle.Regular);
            //area.AxisY.LabelStyle.Font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.AxisLabelFontSizeDelta, FontStyle.Regular);
            //area.AxisX.TitleFont = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.AxisTitleFontSizeDelta, FontStyle.Bold);
            //area.AxisY.TitleFont = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.AxisTitleFontSizeDelta, FontStyle.Bold);
            //area.AxisX.TitleForeColor = ChartData.ChartStyle.FontColor;
            //area.AxisY.TitleForeColor = ChartData.ChartStyle.FontColor;
            //area.BorderColor = ChartData.ChartStyle.ChartBorderColor;

            //area.AxisY.MajorGrid.LineColor = ChartData.ChartStyle.GridLineColor;
            //area.AxisX.MajorGrid.LineColor = ChartData.ChartStyle.GridLineColor;

            //area.AxisX.LineColor = ChartData.ChartStyle.AxisLineColor;
            //area.AxisY.LineColor = ChartData.ChartStyle.AxisLineColor;


            //// Copyright
            //if (!string.IsNullOrEmpty(ChartData.Copyright))
            //{



            //    var copyright = Chart.Titles["Copyright"];
            //    copyright.Position = CopyrightPosition();
            //    copyright.Font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize * ChartData.ChartStyle.CopyrightFontSizeDelta, FontStyle.Regular);
            //    copyright.ForeColor = ChartData.ChartStyle.CopyrightColor;
            //    //copyright.IsDockedInsideChartArea = true;
            //}
        }

        /// <summary>
        /// Get the label for a Chart series
        /// </summary>
        /// <param name="i">index of the series</param>
        /// <returns></returns>
        internal string GetLabelForSeries(int i)
        {
            try
            {
                return ChartData.LabelsForSeries[i];
            }
            catch
            {
                try
                {
                    return ChartData.PropertiesToUseForChart[i + 1];
                }
                catch 
                {
                    return null;
                }
                
            }
        }

        /// <summary>
        /// Adjust labels to show on x axis
        /// </summary>
        protected void AdjustLabels()
        {
            //var c = Chart.ChartAreas["Default"];

            //var labelStyle = c.AxisX.LabelStyle;
            //labelStyle.IntervalOffset = 1;
            //labelStyle.Angle = 30;
            //labelStyle.Interval = Math.Floor((ChartData.DataSource.Count-1)/15.0);
            //if (labelStyle.Interval < 1) labelStyle.Interval = 1;
            //labelStyle.IsEndLabelVisible = true;


            ////c.AxisX.Crossing = 0;
            //c.AxisX.MajorGrid.Interval = labelStyle.Interval;
            //c.AxisX.MajorGrid.IntervalOffset = labelStyle.IntervalOffset;
            //c.AxisX.MajorGrid.Enabled = true;
            //c.AxisX.MajorTickMark.Interval = labelStyle.Interval;
            //c.AxisX.MajorTickMark.IntervalOffset = labelStyle.IntervalOffset;


            //c.AxisX.IsStartedFromZero = true;
        }

        /// <summary>
        /// Get a color for a series
        /// </summary>
        /// <param name="seriesNumber"></param>
        /// <returns></returns>
        protected static Color GetColor(int seriesNumber)
        {
            switch (seriesNumber)
            {
                case 0:
                    return Color.OrangeRed;
                case 1:
                    return Color.CornflowerBlue;
                case 2:
                    return Color.Gold;
                case 3:
                    return Color.Orange;
                case 4:
                    return Color.DodgerBlue;
                case 5:
                    return Color.Coral;
                case 6:
                    return Color.Lime;
                case 7:
                    return Color.DarkOrange;
                case 8:
                    return Color.Red;
                case 9:
                    return Color.Yellow;
                case 10:
                    return Color.Blue;


                default:
                    return Color.Crimson;

            }
        }


        //private string GetFormattedValue(object pointValue, ChartValueType chartValueType)
        //{

        //    if (pointValue is string) return pointValue.ToString();

        //    if (pointValue is double)
        //    {
        //        var value = (double)pointValue;

        //        switch (chartValueType)
        //        {
        //            case ChartValueType.Auto:
        //                break;
        //            case ChartValueType.Double:
        //                break;
        //            case ChartValueType.Single:
        //                break;
        //            case ChartValueType.Int32:
        //                break;
        //            case ChartValueType.Int64:
        //                break;
        //            case ChartValueType.UInt32:
        //                break;
        //            case ChartValueType.UInt64:
        //                break;
        //            case ChartValueType.String:
        //                break;
        //            case ChartValueType.DateTime:
        //            case ChartValueType.Date:
        //                return DateTime.FromOADate((int)value).ToString("dd.MM.yyyy");
        //            case ChartValueType.Time:
        //                return value.ToString("hh:mm");
        //            case ChartValueType.DateTimeOffset:
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException("chartValueType", chartValueType, null);
        //        }


        //    }

        //    return pointValue.ToString();
        //}
    }
}
