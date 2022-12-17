// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using Bodoconsult.Core.Charting.Base.Models;
using Bodoconsult.Core.Typography.Charts;

namespace Bodoconsult.Core.Charting
{
    /// <summary>
    /// Handles the creation process of a Chart. Set property <see cref="set_ChartData"  /> and then export Chart as image or memorystream.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class ChartHandler
    {
        ///// <summary>
        ///// Set chart data to high resolution: 4500 x 3000 pixels
        ///// </summary>
        //public void SetChartToHighResolution()
        //{
        //    ChartData.ChartStyle.Width = 4500;
        //    ChartData.ChartStyle.Height = 3300;
        //    ChartData.ChartStyle.FontSize = 70;
        //    ChartData.ChartStyle.HighQuality = true;
        //    ChartData.ChartStyle.BorderLineWidth = 2;
        //    ChartData.ChartStyle.IntervalXLineWidth = 2;
        //    ChartData.ChartStyle.IntervalYLineWidth = 2;
        //    ChartData.ChartStyle.ChartBorderCornerRadius = 100;
        //    ChartData.ChartStyle.CorrectiveFactor = 30;
        //    ChartData.ChartStyle.ChartBorderWidth = 10;

        //    switch (ChartData.ChartType)
        //    {
        //        case ChartType.StackedBarChart:
        //        case ChartType.StackedColumn100Chart:
        //        case ChartType.StackedColumnChart:
        //            ChartData.ChartStyle.SeriesLineWidth = 0;
        //            break;
        //        default:
        //            ChartData.ChartStyle.SeriesLineWidth = 15;
        //            break;
        //    }


        //}

        //public ChartHandler()
        //{

        //}

        /// <summary>
        /// Contains all data to use in the Chart
        /// </summary>
        public ChartData ChartData { get; set; }

        /// <summary>
        /// Export Chart as PNG file
        /// </summary>
        public void Export()
        {
            if (File.Exists(ChartData.FileName)) File.Delete(ChartData.FileName);

            Bitmap b;


            if (ChartData.DataSource == null || ChartData.DataSource.Count == 0)
            {
                var msg = "No data available! Keine Daten verfügbar!";

                var image = new Bitmap(ChartData.ChartStyle.Width, ChartData.ChartStyle.Height);

                var g = Graphics.FromImage(image);

                using (var font = new Font(ChartData.ChartStyle.FontName, ChartData.ChartStyle.FontSize, FontStyle.Bold))
                {
                    using (var brush = new SolidBrush(Color.LightGray))
                    {
                        g.FillRectangle(brush, 0, 0, ChartData.ChartStyle.Width, ChartData.ChartStyle.Height);

                        var sf = StringFormat.GenericDefault;
                        sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;

                        var textSize = g.MeasureString(msg, font, -1, sf);

                        var x = (ChartData.ChartStyle.Width - textSize.Width) / 2;
                        var y = (ChartData.ChartStyle.Height - textSize.Height) / 2;


                        using (var brush1 = new SolidBrush(Color.Black))
                        {
                            g.DrawString(msg, font, brush1, x, y, sf);
                        }


                    }
                }

                b = new Bitmap(RoundCorners(image, ChartData.ChartStyle.ChartBorderCornerRadius));
            }
            else
            {
                b = CreateChartWithRoundedCorners();
            }


            //save the image to a memorystream to apply the compression level
            var jpgEncoder = GetEncoderInfo("image/jpeg");
            using (var ms = new MemoryStream())
            {
                //var encoderParameters = new EncoderParameters(1);
                //encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (byte)compressionLevel);

                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (uint)80);

                b.Save(ms, jpgEncoder, encoderParameters);

                //save the image as byte array here if you want the return type to be a Byte Array instead of Image
                //byte[] imageAsByteArray = ms.ToArray();

                //write to file
                var file = new FileStream(ChartData.FileName, FileMode.Create, FileAccess.Write);
                ms.WriteTo(file);
                file.Close();
                ms.Close();
                file.Dispose();
                ms.Dispose();
            }


            b.Save(ChartData.FileName, ImageFormat.Png);
            b.Dispose();
        }


        //=== get encoder info
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var encoders = ImageCodecInfo.GetImageEncoders();

            for (var j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType.ToLower() == mimeType.ToLower())
                {
                    return encoders[j];
                }
            }

            return null;
        }

        private Bitmap CreateChartWithRoundedCorners()
        {
            var chart = CreateBaseChart();
            var ms = chart.RenderImagePng();

            Bitmap b;

            if (ChartData.ChartStyle.ChartBorderCornerRadius > 0)
            {
                var image = Image.FromStream(ms);
                b = new Bitmap(RoundCorners(image, ChartData.ChartStyle.ChartBorderCornerRadius));

                //b = new Bitmap(RoundCorners(image, 0));
            }
            else
            {
                b = new Bitmap(Image.FromStream(ms));
            }

            if (ChartData.ChartStyle.PaperColor == Color.Transparent)
            {
                b.MakeTransparent(Color.White);
            }



            return b;
        }

        private Image RoundCorners(Image image, int cornerRadius)
        {
            cornerRadius *= 2;

            //cornerRadius = 0;

            var deltaX = (ChartData.ChartStyle.Width - image.Width) / 2;
            var deltaY = (ChartData.ChartStyle.Height - image.Height) / 2;

            var roundedImage = new Bitmap(ChartData.ChartStyle.Width, ChartData.ChartStyle.Height);

            GraphicsPath gp = null;

            if (cornerRadius > 0)
            {
                gp = new GraphicsPath();
                gp.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                gp.AddArc(0 + roundedImage.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
                gp.AddArc(0 + roundedImage.Width - cornerRadius, 0 + roundedImage.Height - cornerRadius - ChartData.ChartStyle.CorrectiveFactor, cornerRadius, cornerRadius, 0, 90);
                gp.AddArc(0, 0 + roundedImage.Height - cornerRadius - ChartData.ChartStyle.CorrectiveFactor, cornerRadius, cornerRadius, 90, 90);
                gp.CloseFigure();
            }


            using (var g = Graphics.FromImage(roundedImage))
            {
                // Fill Background
                if (ChartData.ChartStyle.PaperColor != Color.Transparent)
                {
                    g.FillRectangle(new SolidBrush(ChartData.ChartStyle.PaperColor), 0, 0, image.Width, image.Height);
                }


                // Rounded corners
                g.SmoothingMode = SmoothingMode.HighQuality;

                if (cornerRadius > 0) g.SetClip(gp);

                // Fill with gradients
                if (ChartData.ChartStyle.BackGradientStyle == GradientStyle.TopBottom)
                {

                    var rect = new Rectangle(0, 0, ChartData.ChartStyle.Width, ChartData.ChartStyle.Height);


                    var lb = new LinearGradientBrush(
                        rect,
                        ChartData.ChartStyle.ChartBackgroundSecondColor,
                        ChartData.ChartStyle.ChartBackgroundColor,
                        LinearGradientMode.Vertical);

                    g.FillRectangle(lb, rect);
                }

                // Insert the image 
                g.DrawImage(image, new Rectangle(deltaX, deltaY, image.Width, image.Height - ChartData.ChartStyle.CorrectiveFactor), new Rectangle(0, 0, image.Width, image.Height - ChartData.ChartStyle.CorrectiveFactor), GraphicsUnit.Pixel);

                if (ChartData.ChartStyle.ChartBorderWidth > 0)
                {
                    if (cornerRadius > 0)
                    {
                        var gp1 = new GraphicsPath();
                        gp1.AddArc(1, 1, cornerRadius, cornerRadius, 180, 90);
                        gp1.AddArc(1 + roundedImage.Width - cornerRadius - 2, 1, cornerRadius, cornerRadius, 270, 90);
                        gp1.AddArc(1 + roundedImage.Width - cornerRadius - 2, 1 + roundedImage.Height - cornerRadius - ChartData.ChartStyle.CorrectiveFactor - 2, cornerRadius, cornerRadius, 0, 90);
                        gp1.AddArc(1, 1 + roundedImage.Height - cornerRadius - ChartData.ChartStyle.CorrectiveFactor - 2, cornerRadius, cornerRadius, 90, 90);
                        gp1.CloseFigure();
                        g.DrawPath(new Pen(ChartData.ChartStyle.ChartBorderColor, ChartData.ChartStyle.ChartBorderWidth), gp1);
                    }
                    else
                    {
                        var gp1 = new GraphicsPath();
                        gp1.AddRectangle(new Rectangle(1, 1, roundedImage.Width - 2, roundedImage.Height - ChartData.ChartStyle.CorrectiveFactor - 4));
                        gp1.CloseFigure();
                        g.DrawPath(new Pen(ChartData.ChartStyle.ChartBorderColor, ChartData.ChartStyle.ChartBorderWidth), gp1);
                    }

                }
            }

            var roundedImageEnd = new Bitmap(ChartData.ChartStyle.Width, ChartData.ChartStyle.Height - ChartData.ChartStyle.CorrectiveFactor);
            using (var g = Graphics.FromImage(roundedImageEnd))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.DrawImage(roundedImage, new Rectangle(0, 0, ChartData.ChartStyle.Width, ChartData.ChartStyle.Height - ChartData.ChartStyle.CorrectiveFactor), new Rectangle(0, 0, ChartData.ChartStyle.Width, ChartData.ChartStyle.Height - ChartData.ChartStyle.CorrectiveFactor), GraphicsUnit.Pixel);

                if (!string.IsNullOrEmpty(ChartData.Copyright))
                {
                    var stringFormat = new StringFormat(StringFormat.GenericTypographic) { Alignment = StringAlignment.Far };

                    using (var font = new Font(ChartData.ChartStyle.FontName,
                        ChartData.ChartStyle.FontSize * ChartData.ChartStyle.CopyrightFontSizeDelta, FontStyle.Regular))
                    {

                        using (var brush = new SolidBrush(ChartData.ChartStyle.CopyrightColor))
                        {

                            var y = image.Height + 0.5F * font.SizeInPoints;
                            var x = 0;

                            var rect = new RectangleF(x, y, image.Width, font.SizeInPoints * 1.1F);


                            g.DrawString(ChartData.Copyright, font, brush, rect, stringFormat);
                        }
                    }
                }


            }


            //roundedImage.Dispose();
            //return roundedImageEnd;

            if (ChartData.ChartStyle.ChartShadow < 0.0001)
            {
                roundedImage.Dispose();
                return roundedImageEnd;
            }

            var shadowedImageEnd = new Bitmap((int)(roundedImageEnd.Width * (1 + ChartData.ChartStyle.ChartShadow)),
                (int)(roundedImageEnd.Height * (1 + 1.5 * ChartData.ChartStyle.ChartShadow) - ChartData.ChartStyle.CorrectiveFactor));
            using (var g = Graphics.FromImage(shadowedImageEnd))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;

                // Fill Background
                if (ChartData.ChartStyle.PaperColor != Color.Transparent)
                {
                    g.FillRectangle(new SolidBrush(ChartData.ChartStyle.PaperColor), 0, 0, shadowedImageEnd.Width, shadowedImageEnd.Height);
                }

                var left = (int)(ChartData.ChartStyle.Width * ChartData.ChartStyle.ChartShadow);
                var top = (int)(1.5 * ChartData.ChartStyle.Height * ChartData.ChartStyle.ChartShadow);

                var gp1 = new GraphicsPath();
                gp1.AddArc(left, top, cornerRadius, cornerRadius, 180, 90);
                gp1.AddArc(left + roundedImageEnd.Width - cornerRadius, top, cornerRadius, cornerRadius, 270, 90);
                gp1.AddArc(left + roundedImageEnd.Width - cornerRadius, top + roundedImageEnd.Height - cornerRadius - ChartData.ChartStyle.CorrectiveFactor, cornerRadius, cornerRadius, 0, 90);
                gp1.AddArc(left, top + roundedImageEnd.Height - cornerRadius - ChartData.ChartStyle.CorrectiveFactor, cornerRadius, cornerRadius, 90, 90);
                gp1.CloseFigure();


                //var brush = new PathGradientBrush(gp1)
                //{
                //    CenterPoint = new PointF(left + roundedImage.Width / 2, top + roundedImage.Height / 2),
                //    CenterColor = Color.Black,
                //    SurroundColors = new[] { Color.White }
                //};


                //g.FillPath(brush, gp1);
                //g.SetClip(gp);


                // this is where we create the shadow effect, so we will use a 
                // pathgradientbursh and assign our GraphicsPath that we created of a 
                // Rounded Rectangle
                using (var brush = new PathGradientBrush(gp1))
                {
                    // set the wrapmode so that the colors will layer themselves
                    // from the outer edge in
                    brush.WrapMode = WrapMode.Clamp;

                    // Create a color blend to manage our colors and positions and
                    // since we need 3 colors set the default length to 3
                    var colorBlend = new ColorBlend(3)
                    {

                        // here is the important part of the shadow making process, remember
                        // the clamp mode on the colorblend object layers the colors from
                        // the outside to the center so we want our transparent color first
                        // followed by the actual shadow color. Set the shadow color to a 
                        // slightly transparent DimGray, I find that it works best.|
                        Colors = new[]
                        {
                            Color.Transparent,
                            Color.FromArgb(180, ChartData.ChartStyle.ChartShadowColor),
                            Color.FromArgb(180, ChartData.ChartStyle.ChartShadowColor)
                        },
                        Positions = new[] { 0f, .1f, 1f }
                    };



                    // our color blend will control the distance of each color layer
                    // we want to set our transparent color to 0 indicating that the 
                    // transparent color should be the outer most color drawn, then
                    // our Dimgray color at about 10% of the distance from the edge

                    // assign the color blend to the pathgradientbrush
                    brush.InterpolationColors = colorBlend;

                    // fill the shadow with our pathgradientbrush

                    g.FillPath(brush, gp1);
                }

                if (cornerRadius > 0) g.SetClip(gp);
                // g.DrawImage(roundedImageEnd, new Rectangle(0, 0, roundedImageEnd.Width, roundedImageEnd.Height - ChartData.ChartStyle.CorrectiveFactor), new Rectangle(0, 0, roundedImageEnd.Width, roundedImage.HeightEnd - ChartData.ChartStyle.CorrectiveFactor), GraphicsUnit.Pixel);


                g.DrawImage(roundedImageEnd, new Rectangle(0, 0, roundedImageEnd.Width, roundedImageEnd.Height), new Rectangle(0, 0, roundedImageEnd.Width, roundedImageEnd.Height), GraphicsUnit.Pixel);
            }

            roundedImageEnd.Dispose();

            return shadowedImageEnd;
        }



        /// <summary>
        /// Create the chart
        /// </summary>
        /// <returns></returns>
        private IChart CreateBaseChart()
        {

            AdjustChartDataToRequestedSize();

            IChart chart;

            if (ChartData.DataSource == null)
            {
                throw new Exception("ChartHandler.Export: DataSource is empty");
            }

            if (ChartData.PropertiesToUseForChart.Count == 0)
            {
                throw new Exception("ChartHandler.Export: PropertiesToUseForChart is empty");
            }


            if (string.IsNullOrEmpty(ChartData.XName))
            {
                ChartData.XName = ChartData.PropertiesToUseForChart[0];
            }


            if (string.IsNullOrEmpty(ChartData.XLabelText))
            {
                ChartData.XLabelText = ChartData.XName;
            }

            if (ChartData.LabelsForSeries.Count == 0)
            {
                ChartData.LabelsForSeries = ChartData.PropertiesToUseForChart.Skip(1).ToList();
            }



            switch (ChartData.ChartType)
            {
                case ChartType.ColumnChart:
                    chart = new ColumnChart<ChartItemData>();
                    break;
                case ChartType.BarChart:
                    chart = new BarChart<ChartItemData>();
                    break;
                case ChartType.StackedBarChart:
                    chart = new StackedBarChart<ChartItemData>();
                    break;
                case ChartType.PointChart:
                    chart = new PointChart<PointChartItemData>();
                    break;
                case ChartType.StackedColumnChart:
                    chart = new StackedColumnChart<ChartItemData>();
                    break;
                case ChartType.StackedColumn100Chart:
                    chart = new StackedColumn100Chart<ChartItemData>();
                    break;
                case ChartType.PieChart:
                    chart = new PieChart<PieChartItemData>();
                    break;
                case ChartType.LineChart:
                    chart = new LineChart<ChartItemData>();
                    break;
                case ChartType.Histogram:
                    chart = new LineChartHistogram<ChartItemData>();
                    break;
                case ChartType.StockChart:
                    throw new NotImplementedException($"No such chart type: {ChartData.ChartType}");
                //chart = new StockChart<ChartItemData>();
                //break;
                default:
                    throw new NotImplementedException($"No such chart type: {ChartData.ChartType}");
            }

            chart.ChartData = (ChartData)ChartData.Clone();
            chart.InitChart();
            chart.CreateChart();
            chart.Formatting();

            return chart;
        }

        private void AdjustChartDataToRequestedSize()
        {

            var ratio = (float)(1.0 + (ChartData.ChartStyle.Width / 750 - 1) * 0.92);

            if (ratio < 1) ratio = 1;

            ChartData.ChartStyle.FontSize = ChartData.ChartStyle.FontSize * ratio * 1.3f;
            ChartData.ChartStyle.BorderLineWidth = (int)(ChartData.ChartStyle.BorderLineWidth * ratio);
            ChartData.ChartStyle.IntervalXLineWidth = (int)(ChartData.ChartStyle.IntervalXLineWidth * ratio);
            ChartData.ChartStyle.IntervalYLineWidth = (int)(ChartData.ChartStyle.IntervalYLineWidth * ratio);
            ChartData.ChartStyle.ChartBorderCornerRadius = (int)(ChartData.ChartStyle.ChartBorderCornerRadius * ratio);
            //if (ChartData.ChartStyle.Width>750)  ChartData.ChartStyle.CorrectiveFactor = 30;
            ChartData.ChartStyle.ChartBorderWidth = (int)(ChartData.ChartStyle.ChartBorderWidth * ratio);
            ChartData.ChartStyle.IntervalYLineWidth = (int)(ChartData.ChartStyle.IntervalYLineWidth * ratio);
            ChartData.ChartStyle.IntervalXLineWidth = (int)(ChartData.ChartStyle.IntervalXLineWidth * ratio);

            switch (ChartData.ChartType)
            {
                case ChartType.StackedBarChart:
                case ChartType.StackedColumn100Chart:
                case ChartType.StackedColumnChart:
                    ChartData.ChartStyle.SeriesLineWidth = 0;
                    break;
                default:
                    ChartData.ChartStyle.SeriesLineWidth = (int)(ChartData.ChartStyle.SeriesLineWidth * ratio * 1.2);
                    break;
            }
        }


        /// <summary>
        /// Export Chart as <see cref="MemoryStream"/>
        /// </summary>
        /// <returns>MemoryStream containing the Chart image in PNG format</returns>
        public MemoryStream ExportMemoryStream()
        {

            var b = CreateChartWithRoundedCorners();

            var ms = new MemoryStream();
            b.Save(ms, ImageFormat.Jpeg);
            b.Dispose();

            return ms;
        }
    }
}
