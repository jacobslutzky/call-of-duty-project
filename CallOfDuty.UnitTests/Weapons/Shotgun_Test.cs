using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Shotgun_Test
    {
        [TestMethod]
        public void ShootGruntWithShotgun()
        {
            Weapon testWeapon = new Shotgun();
            Enemy testEnemy = new Grunt();

            testWeapon.Shoot(testEnemy);
            int test = Grunt.Grunt_Starting_Energy - Shotgun.Shotgun_Damage_Points;
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }

        

    }

}
