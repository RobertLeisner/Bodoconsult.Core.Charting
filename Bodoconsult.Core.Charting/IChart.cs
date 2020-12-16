using System.IO;
using Bodoconsult.Core.Charting.Base.Models;

namespace Bodoconsult.Core.Charting
{
    public interface IChart
    {

        ChartData ChartData { get; set; }

        /// <summary>
        /// Creates the chart
        /// </summary>
        void CreateChart();

        /// <summary>
        /// Base formatting for the chart
        /// </summary>
        void Formatting();


        /// <summary>
        /// Render the chart to a PNG image
        /// </summary>
        /// <returns></returns>
        MemoryStream RenderImagePng();


        void InitChart();



        /// <summary>
        /// Add a copyright to the chart
        /// </summary>
        void AddCopyright();

        /// <summary>
        /// Add a title to the chart
        /// </summary>
        void AddTitle();


        ///// <summary>
        ///// Default position of the chart area
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //ElementPosition DefaultPositionChartArea();


        ///// <summary>
        ///// Position of the chart area needing smaller space
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //ElementPosition SmallerPositionChartArea();



        ///// <summary>
        ///// Wide position of the chart area
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //ElementPosition WidePositionChartArea();




        ///// <summary>
        ///// Default position of the legend
        ///// </summary>
        ///// <returns>Elementposition</returns>
        //ElementPosition DefaultLegendPosition();

        ///// <summary>
        ///// Position of the legend providing more space for the legend
        ///// </summary>
        ///// <returns>Element position</returns>
        //ElementPosition EnhancedLegendPosition();


        ///// <summary>
        ///// Position of the Copyright
        ///// </summary>
        ///// <returns>Element position</returns>
        //ElementPosition CopyrightPosition();

    }
}