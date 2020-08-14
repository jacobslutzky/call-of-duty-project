using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallOfDuty;
using Moq;



namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Pulse_Rifle_Test
    {
       

        [TestMethod]
        //Test when three shots are consecutively taken
        public void ShootGruntWithPulseRifleConsecutive()
        {
            Weapon testWeapon = new PulseRifle();
            Enemy testEnemy = new Grunt();
            testWeapon.AddAmmo(3);
            for (int i = 0; i < 3; i++)
            {
                testWeapon.Shoot(testEnemy);
                
            }
            int test = Grunt.Grunt_Starting_Energy - PulseRifle.Pulse_Rifle_Damage_Points;
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }


        [TestMethod]
        //Test when three shots are taken with 6 seconds between shots
        public void ShootGruntWithPulseRifle()
        {
            Weapon testWeapon = new PulseRifle();
            Enemy testEnemy = new Grunt();
            
            
            var timeMock = new Mock<TimeProvider>();
            timeMock.SetupGet(tp => tp.UtcNow).Returns(DateTime.UtcNow);
            TimeProvider.Current = timeMock.Object;
            testWeapon.AddAmmo(3);
            for (int i = 0; i < 3; i++)
            {
                testWeapon.Shoot(testEnemy);
                timeMock.SetupGet(tp => tp.UtcNow).Returns(DateTime.UtcNow.AddSeconds(6));
                TimeProvider.Current = timeMock.Object;
            }

            TimeProvider.ResetToDefault();
            int test = Grunt.Grunt_Starting_Energy - (3 * PulseRifle.Pulse_Rifle_Damage_Points);
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }


    }
   
}