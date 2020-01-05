using DockerDotnetApi.Managers;
using DockerDotnetApi.Models.BinList;
using NUnit.Framework;
using System;

namespace DockerDotnetApi.Test
{
    public class BinListManagerTest
    {
        private IManageBinList _binListManager;

        [SetUp]
        public void Setup()
        {
            _binListManager = ProvideBinListManager();
        }
        private IManageBinList ProvideBinListManager()
        {
            return new BinListManager();
        }
        [Test]
        public void PaymentCardCost_BinListManagerTest()
        {

            // Act
            IssuerInformation info = _binListManager.PaymentCardCost("431940");

            // Assert
            Assert.AreEqual("visa", info.Scheme);
            Assert.AreEqual("IE", info.Country.Alpha2);
            Assert.AreEqual("Ireland", info.Country.Name);
            Assert.AreEqual("BANK OF IRELAND", info.Bank.Name);
            Assert.AreEqual("debit", info.CardType);
            Assert.AreEqual("53", info.Country.Latitude);
            Assert.AreEqual("-8", info.Country.Longitude);
            Assert.AreEqual("Traditional", info.Brand);
            Assert.AreEqual(false, info.Prepaid);
        }

        [Test]
        public void ArgumentNullException_PaymentCardCost_BinListManagerTest()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _binListManager.PaymentCardCost(null));
        }

        [Test]
        public void ArgumentException_PaymentCardCost_BinListManagerTest()
        {
            var ex = Assert.Throws<ArgumentException>(() => _binListManager.PaymentCardCost("333g12"));
        }
    }
}
