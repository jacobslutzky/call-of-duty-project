using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CallOfDuty.UnitTests.Enemies
{
    [TestClass]
    public class Enemy_Test
    {
        [TestMethod]
        public void TestEnemyIsAlive()
        {
            Weapon testWeapon = new Shotgun();
            Enemy testEnemy = new Sergeant();

            testWeapon.Shoot(testEnemy);
            Assert.IsTrue(testEnemy.Alive);
        }

        public void TestEnemyIsNotAlive()
        {
            Weapon testWeapon = new Bazooka();
            Enemy testEnemy = new Sergeant();

            testWeapon.Shoot(testEnemy);
            Assert.IsFalse(testEnemy.Alive);
        }
    }
}

