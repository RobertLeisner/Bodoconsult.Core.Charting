// Copyright (c) Bodoconsult EDV-Dienstleistungen GmbH. All rights reserved.


using NUnit.Framework;
using System.Runtime.Versioning;

// ReSharper disable InconsistentNaming

namespace Bodoconsult.Core.Charting.Test
{
    [TestFixture]
    [SupportedOSPlatform("windows")]

    public class UnitTestChartHandler_NoDatabase: BaseTestChartHandler
    {

        public UnitTestChartHandler_NoDatabase()
        {
            HighResolution = false;
            UseDatabase = false;
        }
    }
}
