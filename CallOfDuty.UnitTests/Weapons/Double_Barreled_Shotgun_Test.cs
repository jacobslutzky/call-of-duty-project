using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Double_Barreled_Shotgun_Test
    {
        [TestMethod]
        public void ShootGruntWithDBShotgun()
        {
            Weapon testWeapon = new Double_Barreled_Shotgun();
            Enemy testEnemy = new Grunt();

            testWeapon.Shoot(testEnemy);

            int expected = Grunt.Grunt_Starting_Energy - Double_Barreled_Shotgun.DB_Default_Ammo_Used*Double_Barreled_Shotgun.DB_Shotgun_Damage_Points;
            // Test damage done with two bullets
            Assert.AreEqual(expected, testEnemy.EnergyRemaining);


        }
        [TestMethod]
        public void ShootGruntWithOneBulletDBShotgun()
        {
            Weapon testWeapon = new Double_Barreled_Shotgun();
            Enemy testEnemy = new Grunt();

            testWeapon.SetAmmo(1);
            testWeapon.Shoot(testEnemy);

            int expected = Grunt.Grunt_Starting_Energy - (Double_Barreled_Shotgun.DB_Shotgun_Damage_Points);
            Assert.AreEqual(expected, testEnemy.EnergyRemaining);
        }

       
    }
}
