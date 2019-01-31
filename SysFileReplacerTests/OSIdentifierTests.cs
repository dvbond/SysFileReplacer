using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SysFileReplacer;

namespace SysFileReplacerTests
{
    [TestClass]
    public class OSIdentifierTests
    {
        [TestMethod]
        public void IsCurrentOsSupported_ValidVersion_ReturnsTrue()
        {
            // Arrange
            var version = new Version(10, 0);

            var osVersionMock = new Mock<OSVersion>();
            osVersionMock.Setup(v => v.Platform).Returns(PlatformID.Win32NT);
            osVersionMock.Setup(v => v.Version).Returns(version);
            osVersionMock.Setup(v => v.ServicePack).Returns(string.Empty);

            // Assert
            Assert.IsTrue(OSVersionValidator.IsCurrentOsSupported(osVersionMock.Object));
        }

        [TestMethod]
        public void IsCurrentOsSupported_InvalidVersion_ReturnsFalse()
        {
            // Arrange
            var version = new Version(3, 0);

            var osVersionMock = new Mock<OSVersion>();
            osVersionMock.Setup(v => v.Platform).Returns(PlatformID.Win32NT);
            osVersionMock.Setup(v => v.Version).Returns(version);
            osVersionMock.Setup(v => v.ServicePack).Returns(string.Empty);

            // Assert
            Assert.IsFalse(OSVersionValidator.IsCurrentOsSupported(osVersionMock.Object));
        }

        [TestMethod]
        public void IsWindowsXp_ValidVersion_ReturnsTrue()
        {
            // Arrange
            var version = new Version(5, 1);

            var osVersionMock = new Mock<OSVersion>();
            osVersionMock.Setup(v => v.Platform).Returns(PlatformID.Win32NT);
            osVersionMock.Setup(v => v.Version).Returns(version);
            osVersionMock.Setup(v => v.ServicePack).Returns(string.Empty);

            // Assert
            Assert.IsTrue(OSVersionValidator.IsWindowsXp(osVersionMock.Object));
        }

        [TestMethod]
        public void IsWindowsXp_InvalidVersion_ReturnsFalse()
        {
            // Arrange
            var version = new Version(10, 0);

            var osVersionMock = new Mock<OSVersion>();
            osVersionMock.Setup(v => v.Platform).Returns(PlatformID.Win32NT);
            osVersionMock.Setup(v => v.Version).Returns(version);
            osVersionMock.Setup(v => v.ServicePack).Returns(string.Empty);

            // Assert
            Assert.IsFalse(OSVersionValidator.IsWindowsXp(osVersionMock.Object));
        }
    }
}
