using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    public class AcutatorTests
    {
        //Linear Drives
        [Test]
        public void CanCreateLinearDrive()
        {
            var x = new LinearDrive("PLA", 400, 3.5, 24.0);

            Assert.IsTrue(x.Name == "PLA");
            Assert.IsTrue(x.Hub == 400);
            Assert.IsTrue(x.Current == 3.5);
            Assert.IsTrue(x.Voltage == 24.0);
        }

        [Test]
        public void CannotCreateLinearDriveWithEmptyTitle1()
        {
            Assert.Catch(() =>
            {
            var x = new LinearDrive(null, 400, 3.5, 24.0);
            });
        }

        [Test]
        public void CannotCreateLinearDriveWithEmptyTitle2()
        {
            Assert.Catch(() =>
            {
                var x = new LinearDrive("", 400, 3.5, 24.0);
            });
        }

        [Test]
        public void CannotCreateLinearDriveWithNegativeHub()
        {
            Assert.Catch(() =>
            {
                var x = new LinearDrive("PLA", -1, 3.5, 24.0);
            });
        }

        [Test]
        public void CannotCreateLinearDriveWithNegativeCurrent()
        {
            Assert.Catch(() =>
            {
                var x = new LinearDrive("PLA", 400, -3.5, 24.0);
            });
        }

        [Test]
        public void CannotCreateLinearDriveWithVoltageLower18Higher30()
        {
            Assert.Catch(() =>
            {
                var x = new LinearDrive("PLA", 400, 3.5, 18.0-30.0);
            });
        }

        //Chain Drives
        [Test]
        public void CanCreateChainDrive()
        {
            var x = new ChainDrive("KSA", 433.42);

            Assert.IsTrue(x.Name == "KSA");
            Assert.IsTrue(x.Price == 433.42);
        }

        [Test]
        public void CannotCreateChainDriveWithEmptyTitle1()
        {
            Assert.Catch(() =>
            {
                var x = new ChainDrive(null, 433.42);
            });
        }

        [Test]
        public void CannotCreateChainDriveWithEmptyTitle2()
        {
            Assert.Catch(() =>
            {
                var x = new ChainDrive("", 433.42);
            });
        }
        
        [Test]
        public void CannotCreateChainDriveWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new ChainDrive("KSA", -1);
            });
        }

        [Test]
        public void CanUpdateChainDriveWithPrice()
        {
            var x = new ChainDrive("KSA", 433.42);
            x.SetPrice(475.90);

            Assert.IsTrue(x.Price == 475.90);
        }

        [Test]
        public void CannotUpdateChainDriveWithNegativePrice()
        {
            Assert.Catch(() =>
            {
                var x = new ChainDrive("KSA", 433.42);
                x.SetPrice(-56.73);
            });
        }
    }
}
