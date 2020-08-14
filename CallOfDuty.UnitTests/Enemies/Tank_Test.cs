using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallOfDuty.UnitTests.Enemies
{
    [TestClass]
    public class Tank_Test
    {
        [TestMethod]
        public void ShootTankWithGunThatDoesNotDamage()
        {
            Weapon testWeapon = new Shotgun();
            Enemy testEnemy = new Tank();

            testWeapon.Shoot(testEnemy);
            int test = Tank.Tank_Starting_Energy;
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }

        [TestMethod]
        public void ShootTankWithGunThatDoesDamage()
        {
            Weapon testWeapon = new Bazooka();
            Enemy testEnemy = new Tank();

            testWeapon.Shoot(testEnemy);
            int test = Tank.Tank_Starting_Energy - Bazooka.Bazooka_Damage_Points;
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }
    }
}
