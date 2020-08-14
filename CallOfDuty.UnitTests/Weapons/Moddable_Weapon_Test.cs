using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons;
using CallOfDuty.IAttachments.Models;
using System.Diagnostics;

namespace CallOfDuty.UnitTests.Weapons
{
    [TestClass]
    public class Moddable_Weapon_Test
    {
        [TestMethod]
        public void TestModdableWeaponConstructor()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            Assert.AreEqual(testWeapon.barrelInventory.Count, 1);
            Assert.AreEqual(testWeapon.barrelInventory[testWeapon.CurrentBarrelIndex].damageMultiplier, new Barrel(BarrelEnum.NoBarrel).damageMultiplier);
            Assert.AreEqual(testWeapon.CurrentBarrelIndex, 0);

        }

        [TestMethod]
        public void TestSetFireModeWhenItDoesNotChange()
        {
            AssaultRifle testWeapon = new AssaultRifle(FireModeEnum.FullAuto);
            Assert.IsFalse(testWeapon.SetFireMode(FireModeEnum.FullAuto));
            Assert.AreEqual(testWeapon.FireMode, (int)FireModeEnum.FullAuto);

        }

        [TestMethod]
        public void TestSetFireModeWhenItDoesChange()
        {
            AssaultRifle testWeapon = new AssaultRifle(FireModeEnum.FullAuto);
            testWeapon.SetFireMode(FireModeEnum.ThreeShotBurst);
            Assert.AreEqual(testWeapon.FireMode, (int)FireModeEnum.ThreeShotBurst);
        }
        [TestMethod]
        public void TestSingleFire()
        {

            AssaultRifle testWeapon = new AssaultRifle();
            Enemy testEnemy = new Grunt();

            testWeapon.Shoot(testEnemy);
            int test = Grunt.Grunt_Starting_Energy - testWeapon.GetDamage();
            Assert.AreEqual(test, testEnemy.EnergyRemaining);

        }

        [TestMethod]
        public void TestThreeShotBurst()
        {
            AssaultRifle testWeapon = new AssaultRifle(FireModeEnum.ThreeShotBurst);
            Enemy testEnemy = new Grunt();

            testWeapon.Shoot(testEnemy);

            int test = Grunt.Grunt_Starting_Energy - testWeapon.GetDamage();
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }

        [TestMethod]
        public void TestFullAuto()
        {
            AssaultRifle testWeapon = new AssaultRifle(FireModeEnum.FullAuto);
            Enemy testEnemy = new Grunt();

            testWeapon.Shoot(testEnemy);
            int test = Grunt.Grunt_Starting_Energy - testWeapon.GetDamage();
            Assert.AreEqual(test, testEnemy.EnergyRemaining);
        }

        [TestMethod]
        public void TestAddingSingularBarrel()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            testWeapon.AddBarrel(BarrelEnum.LongBarrel);

            var expectedBarrel = testWeapon.GetCurrentBarrel();

            Assert.AreEqual(expectedBarrel.damageMultiplier, new Barrel(BarrelEnum.LongBarrel).damageMultiplier);
        }

        [TestMethod]
        public void TestAddingMultipleBarrels()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            testWeapon.AddBarrel(BarrelEnum.LongBarrel);
            testWeapon.AddBarrel(BarrelEnum.MediumBarrel);

            var expectedBarrel = testWeapon.GetCurrentBarrel();

            Assert.AreEqual(expectedBarrel.damageMultiplier, new Barrel(BarrelEnum.MediumBarrel).damageMultiplier);

        }



        [TestMethod]
        public void TestToggleBarrelsWithOneBarrel()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            testWeapon.AddBarrel(BarrelEnum.LongBarrel);

            var toggleBarrelResult = testWeapon.ToggleBarrel();

            Assert.IsFalse(toggleBarrelResult);
        }

        [TestMethod]
        public void TestToggleCyclesToBeginningOfBarrelCollection()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            var numToggles = 1;

            BarrelEnum[] barrelEnumArray = { BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel };
            AddBarrelsAndToggle(testWeapon, numToggles, ToggleEnum.toggleForwards, barrelEnumArray);

            var actualCurrentbarrelIndex = testWeapon.CurrentBarrelIndex;
            var expectedIndex = ModdableWeapon.StartingBarrelIndex;
            Assert.AreEqual(expectedIndex, actualCurrentbarrelIndex);
        }

        [TestMethod]
        public void TestToggleBarrelForward()
        {

            var numToggles = 423;
            ToggleEnum toggleEnum = ToggleEnum.toggleForwards;
            BarrelEnum[] barrelEnumArray = { BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel,
                BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel};
            AssaultRifle testWeapon = new AssaultRifle();
            AddBarrelsAndToggle(testWeapon, numToggles, toggleEnum, barrelEnumArray);

            var actualCurrentbarrelIndex = testWeapon.CurrentBarrelIndex;
            var expectedIndex = (numToggles % barrelEnumArray.Length);
            Assert.AreEqual(expectedIndex, actualCurrentbarrelIndex);
        }

        [TestMethod]
        public void TestToggleCyclesToEndOfBarrelCollection()
        {
            AssaultRifle testWeapon = new AssaultRifle();

            BarrelEnum[] barrelEnumArray = { BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel };
            AddBarrelsAndToggle(testWeapon, barrelEnumArray.Length, ToggleEnum.toggleBackwards, barrelEnumArray);


            var actualCurrentbarrelIndex = testWeapon.CurrentBarrelIndex;
            var expectedIndex = barrelEnumArray.Length;
            Assert.AreEqual(expectedIndex, actualCurrentbarrelIndex);
        }

        [TestMethod]
        public void TestToggleBarrelBackward()
        {
            var numToggles = 432;
            ToggleEnum toggleEnum = ToggleEnum.toggleBackwards;
            BarrelEnum[] barrelEnumArray = { BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel, BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel };
            AssaultRifle testWeapon = new AssaultRifle();
            AddBarrelsAndToggle(testWeapon, numToggles, toggleEnum, barrelEnumArray);

            var actualCurrentbarrelIndex = testWeapon.CurrentBarrelIndex;

            //Since it's toggling backwards through the array's expected index logic is the inverse of toggling forwards
            var expectedIndex = barrelEnumArray.Length - (numToggles % barrelEnumArray.Length);
            Assert.AreEqual(expectedIndex, actualCurrentbarrelIndex);
        }

        [TestMethod]
        public void TestRemoveBarrelWithEmptyInventory()
        {
            AssaultRifle testWeapon = new AssaultRifle();

            //remove barrel returns false when the inventory is empty
            var removeBarrelResult = testWeapon.RemoveBarrel();


            Assert.IsFalse(removeBarrelResult);
        }

        [TestMethod]
        public void TestRemoveBarrelWhenInventoryIsNotTogglable()
        {
            //test exists to make sure remove barrel manually updates current index because toggle does not work on barrel collections with count of 2
            AssaultRifle testWeapon = new AssaultRifle();


            testWeapon.AddBarrel(BarrelEnum.LongBarrel);
            testWeapon.AddBarrel(BarrelEnum.MediumBarrel);
            testWeapon.RemoveBarrel();


            var expectedCurrentBarrelIndex = testWeapon.CurrentBarrelIndex;

            Assert.AreEqual(expectedCurrentBarrelIndex, ModdableWeapon.StartingBarrelIndex);
        }

        [TestMethod]
        public void TestRemoveBarrelWhenInventoryIsTogglable()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            BarrelEnum[] barrelEnumArray = { BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel, BarrelEnum.ShortBarrel, BarrelEnum.LongBarrel, BarrelEnum.MediumBarrel };
            foreach (var barrelEnum in barrelEnumArray)
            {
                testWeapon.AddBarrel(barrelEnum);
            }

            testWeapon.RemoveBarrel();

            var actualBarrelIndex = testWeapon.CurrentBarrelIndex;
            var expectedBarrelIndex = barrelEnumArray.Length - 1;

            Assert.AreEqual(expectedBarrelIndex, actualBarrelIndex);
        }

        //ToDo separate into two methods
        private void AddBarrelsAndToggle(
            ModdableWeapon testWeapon,
            int numToggles,
            ToggleEnum toggleEnum,
            BarrelEnum[] barrelEnumArray)
        {
            var actionArray = new int[numToggles];

            foreach (var barrelEnum in barrelEnumArray)
            {
                testWeapon.AddBarrel(barrelEnum);
            }
            foreach (var action in actionArray)
            {
                testWeapon.ToggleBarrel(toggleEnum);
            }
        }



        [TestMethod]
        public void TestAddingSingularSight()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            testWeapon.AddSight(SightEnum.ReflexSight);

            var expectedSight = testWeapon.GetCurrentSight();

            Assert.AreEqual(expectedSight.accuracyMultiplier, new Sight(SightEnum.ReflexSight).accuracyMultiplier);
        }

        [TestMethod]
        public void TestAddingMultipleSights()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            testWeapon.AddSight(SightEnum.ReflexSight);
            testWeapon.AddSight(SightEnum.LaserSight);

            var expectedSight = testWeapon.GetCurrentSight();

            Assert.AreEqual(expectedSight.accuracyMultiplier, new Sight(SightEnum.LaserSight).accuracyMultiplier);

        }



        [TestMethod]
        public void TestToggleSightsWithOneSight()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            testWeapon.AddSight(SightEnum.LaserSight);

            var toggleSightResult = testWeapon.ToggleSight();

            Assert.IsFalse(toggleSightResult);
        }

        [TestMethod]
        public void TestToggleCyclesToBeginningOfSightCollection()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            var numToggles = 1;

            SightEnum[] SightEnumArray = {SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight };
            AddSightsAndToggle(testWeapon, numToggles, ToggleEnum.toggleForwards, SightEnumArray);

            var actualCurrentSightIndex = testWeapon.CurrentSightIndex;
            var expectedIndex = ModdableWeapon.StartingSightIndex;
            Assert.AreEqual(expectedIndex, actualCurrentSightIndex);
        }

        [TestMethod]
        public void TestToggleSightForward()
        {

            var numToggles = 423;
            ToggleEnum toggleEnum = ToggleEnum.toggleForwards;
            SightEnum[] SightEnumArray = { SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight,
                SightEnum.ZoomSight, SightEnum.LaserSight};
            AssaultRifle testWeapon = new AssaultRifle();
            AddSightsAndToggle(testWeapon, numToggles, toggleEnum, SightEnumArray);

            var actualCurrentSightIndex = testWeapon.CurrentSightIndex;
            var expectedIndex = (numToggles % SightEnumArray.Length);
            Assert.AreEqual(expectedIndex, actualCurrentSightIndex);
        }

        [TestMethod]
        public void TestToggleCyclesToEndOfSightCollection()
        {
            AssaultRifle testWeapon = new AssaultRifle();

            SightEnum[] SightEnumArray = { SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight };
            AddSightsAndToggle(testWeapon, SightEnumArray.Length, ToggleEnum.toggleBackwards, SightEnumArray);


            var actualCurrentSightIndex = testWeapon.CurrentSightIndex;
            var expectedIndex = SightEnumArray.Length;
            Assert.AreEqual(expectedIndex, actualCurrentSightIndex);
        }

        [TestMethod]
        public void TestToggleBackward()
        {
            var numToggles = 432;
            ToggleEnum toggleEnum = ToggleEnum.toggleBackwards;
            SightEnum[] SightEnumArray = { SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight, SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight };
            AssaultRifle testWeapon = new AssaultRifle();
            AddSightsAndToggle(testWeapon, numToggles, toggleEnum, SightEnumArray);

            var actualCurrentSightIndex = testWeapon.CurrentSightIndex;

            //Since it's toggling backwards through the array's expected index logic is the inverse of toggling forwards
            var expectedIndex = SightEnumArray.Length - (numToggles % SightEnumArray.Length);
            Assert.AreEqual(expectedIndex, actualCurrentSightIndex);
        }

        [TestMethod]
        public void TestRemoveSightWithEmptyInventory()
        {
            AssaultRifle testWeapon = new AssaultRifle();

            //remove Sight returns false when the inventory is empty
            var removeSightResult = testWeapon.RemoveSight();


            Assert.IsFalse(removeSightResult);
        }

        [TestMethod]
        public void TestRemoveSightWhenInventoryIsNotTogglable()
        {
            //test exists to make sure remove Sight manually updates current index because toggle does not work on Sight collections with count of 2
            AssaultRifle testWeapon = new AssaultRifle();


            testWeapon.AddSight(SightEnum.LaserSight);
            testWeapon.AddSight(SightEnum.ReflexSight);
            testWeapon.RemoveSight();


            var expectedCurrentSightIndex = testWeapon.CurrentSightIndex;

            Assert.AreEqual(expectedCurrentSightIndex, ModdableWeapon.StartingSightIndex);
        }

        [TestMethod]
        public void TestRemoveSightWhenInventoryIsTogglable()
        {
            AssaultRifle testWeapon = new AssaultRifle();
            SightEnum[] SightEnumArray = {SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight, SightEnum.ZoomSight, SightEnum.LaserSight, SightEnum.ReflexSight };
            foreach (var SightEnum in SightEnumArray)
            {
                testWeapon.AddSight(SightEnum);
            }

            testWeapon.RemoveSight();

            var actualSightIndex = testWeapon.CurrentSightIndex;
            var expectedSightIndex = SightEnumArray.Length - 1;

            Assert.AreEqual(expectedSightIndex, actualSightIndex);
        }

        //ToDo separate into two methods
        private void AddSightsAndToggle(
            ModdableWeapon testWeapon,
            int numToggles,
            ToggleEnum toggleEnum,
            SightEnum[] SightEnumArray)
        {
            var actionArray = new int[numToggles];

            foreach (var SightEnum in SightEnumArray)
            {
                testWeapon.AddSight(SightEnum);
            }
            foreach (var action in actionArray)
            {
                testWeapon.ToggleSight(toggleEnum);
            }
        }

    }
}
    

