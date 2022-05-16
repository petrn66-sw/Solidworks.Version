using System;
using Xunit;
using SolidWorks.Interop.sldworks;
using Moq;

namespace SolidworksVersionTests
{
    public class UnitTest1
    {
        [Fact]
        public void CompareAppFileAndSolidworksAppVersion_Com_Test()
        {
            var sldWorksMock = new Mock<SldWorks>();
            sldWorksMock.Setup(x => x.RevisionNumber()).Returns("0.0.0.0");
            var actual = new SolidworksVersion.Version(sldWorksMock.Object).CompareAppFileAndSolidworksAppVersion();
            Assert.True(actual);
        }
    }
}
