using NUnit.Framework;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Charting.Test
{
    [TestFixture]
    public class UnitTestChartHandler_NoDatabase: BaseTestChartHandler
    {

        public UnitTestChartHandler_NoDatabase()
        {
            HighResolution = false;
            UseDatabase = false;
        }
    }
}
