using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using CallOfDuty.IAttachments.Models;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Assault_Rifle_Test
    {    
        [TestMethod]
        public void TestToggleWhenAssaultRifleIsOutOfAmmoAndAuxiliaryFireIsAvailable()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            Enemy testEnemy = new Grunt();
            testWeapon.AddAuxiliaryAttachment();
            
            testWeapon.SetAmmo(0);
            testWeapon.Shoot(testEnemy);
            
            int ExpectedGruntHealth = Grunt.Grunt_Starting_Energy - AuxiliaryFire.Auxiliary_Fire_Damage_Points;
            int ActualGruntHealth = testEnemy.EnergyRemaining;
            Assert.AreEqual(ExpectedGruntHealth, ActualGruntHealth);
        }
        [TestMethod]
        public void TestShootAssaultRifleWithAmmo()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            Enemy testEnemy = new Grunt();
            
            testWeapon.Shoot(testEnemy);

            int ExpectedGruntHealth = Grunt.Grunt_Starting_Energy - AssaultRifle.Assault_Rifle_Damage_Points;
            int ActualGruntHealth = testEnemy.EnergyRemaining;
            Assert.AreEqual(ExpectedGruntHealth, ActualGruntHealth);
        }
        [TestMethod]
        public void TestToggleWhenAuxiliaryFireIsOutOfAmmoAndAssaultRifleIsAvailable()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            Enemy testEnemy = new Grunt();
            testWeapon.AddAuxiliaryAttachment();
            testWeapon.Toggle();
     
            testWeapon.auxiliaryFireWeapon.SetAmmo(0);
            testWeapon.Shoot(testEnemy);

            int ExpectedGruntHealth = Grunt.Grunt_Starting_Energy - AssaultRifle.Assault_Rifle_Damage_Points;
            int ActualGruntHealth = testEnemy.EnergyRemaining;
            Assert.AreEqual(ExpectedGruntHealth, ActualGruntHealth);
        }
        [TestMethod]
        public void TestShootAuxiliaryFireWithAmmo()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            Enemy testEnemy = new Grunt();
            testWeapon.AddAuxiliaryAttachment();
            testWeapon.Toggle();

            testWeapon.Shoot(testEnemy);

            int ExpectedGruntHealth = Grunt.Grunt_Starting_Energy - AuxiliaryFire.Auxiliary_Fire_Damage_Points;
            int ActualGruntHealth = testEnemy.EnergyRemaining;
            Assert.AreEqual(ExpectedGruntHealth, ActualGruntHealth);
        }
        
     
        [TestMethod]
        public void TestToggleWhenWeaponDoesNotHaveAuxiliaryFire()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            Assert.IsFalse(testWeapon.Toggle());
        }

    }
}
