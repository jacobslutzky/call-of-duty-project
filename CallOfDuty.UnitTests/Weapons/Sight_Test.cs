using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using CallOfDuty.IAttachments.Models;
using Microsoft.VisualStudio.CodeCoverage;
using System.Security.Cryptography.X509Certificates;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Sight_Test
    {
        [TestMethod]
        public void TestSightContructor()
        {

            Sight sight = new Sight(SightEnum.ReflexSight);
            double ExpectedSightAccuracy = sight.accuracyMultiplier;
            double ActualSightAccuracy = (double)SightEnum.ReflexSight / 100;
            Assert.AreEqual(ExpectedSightAccuracy, ActualSightAccuracy);

        }
    }
}
