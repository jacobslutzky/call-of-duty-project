using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Knife_Test
    {
        [TestMethod]
        public void AttackGruntWithKnifeAndAmmoIsNull()
        {
            Weapon testWeapon = new Knife();
            Enemy testEnemy = new Grunt();
            testWeapon.Shoot(testEnemy);
            int test = Grunt.Grunt_Starting_Energy - Knife.Knife_Damage_Points;
            Assert.IsNull(testWeapon.ammoRemaining);
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }
        
        
    }
}
