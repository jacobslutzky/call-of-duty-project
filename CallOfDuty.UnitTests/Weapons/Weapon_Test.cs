using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Weapon_Test
    {
        //Test with bazooka because it instantiates the weapon class and does not override any methods
        [TestMethod]
        public void ShootGruntWithBazooka()
        {
            Weapon testWeapon = new Bazooka();
            Enemy testEnemy = new Grunt();

            testWeapon.Shoot(testEnemy);
            int test = Grunt.Grunt_Starting_Energy - Bazooka.Bazooka_Damage_Points;
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }

        [TestMethod]
        public void AddMoreThanMaxAmmoToBazooka()
        {
            Weapon testWeapon = new Bazooka();

            testWeapon.AddAmmo(3);

            Assert.AreEqual(2, testWeapon.ammoRemaining);
        }

        [TestMethod]
        public void AddLessThanMaxAmmoToBazooka()
        {
            Weapon testWeapon = new Bazooka();
            testWeapon.SetAmmo(0);
            testWeapon.AddAmmo(1);

            Assert.AreEqual(1, testWeapon.ammoRemaining);
        }

    }

}
