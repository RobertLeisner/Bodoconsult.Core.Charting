using Bodoconsult.Core.Typography;
using Bodoconsult.Core.Typography.Charts;

namespace Bodoconsult.Core.Charting.Test
{
    public static class GlobalValues
    {
        /// <summary>
        /// Get a elegant default typography
        /// </summary>
        /// <returns></returns>
        public static ITypography DefaultTypography()
        {
            var typography = new ElegantTypographyPageHeader("Calibri", "Calibri", "Calibri")
            {
                ChartStyle =
                {
                    Width = 750,
                    Height = 464,
                    FontSize = 10,
                    BackGradientStyle = GradientStyle.TopBottom,
                }
            };

            return typography;
        }

    }
}
