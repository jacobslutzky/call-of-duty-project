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
    public class Barrel_Test
    {
        [TestMethod]
        public void TestBarrelContructor()
        {
           
            Barrel barrel = new Barrel(BarrelEnum.LongBarrel);
            double ExpectedBarrelDamage = barrel.damageMultiplier;
            double ActualBarrelDamage = (double)BarrelEnum.LongBarrel / 100;
            Assert.AreEqual(ExpectedBarrelDamage,ActualBarrelDamage) ;

        }
    }
}
