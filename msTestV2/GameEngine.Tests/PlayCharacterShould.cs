using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayCharacterShould
    {
        PlayerCharacter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PlayerCharacter()
            {
                FirstName = "Sarah",
                LastName = "Smith"
            };
        }

        [TestMethod]
        //[TestCategory("Player Defaults")] substituido por extension abaixo
        [PlayerDefaults]
        [Ignore("Motivo pelo qual esta ignorado")]
        public void BeInexperiencedWhenNew()
        {
            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        [PlayerDefaults]
        public void NotHaveNickNameByDefault()
        {
            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        [PlayerDefaults]
        public void StartWithDefaultHealth()
        {
            Assert.AreEqual(100, sut.Health);
        }

        public static IEnumerable<object[]> GetDamages()
        {
            return new List<object[]>
                    {
                        new object[]{1,99},
                        new object[]{0,100},
                        new object[]{100,1},
                        new object[]{101,1},
                        new object[]{ 50, 50}
                    };
        }

        [DataTestMethod]
        [DynamicData(nameof(GetDamages), DynamicDataSourceType.Method)]
        [PlayerHealth]
        public void TakeDamageMethod(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(sut.Health, expectedHealth);
        }

        public static IEnumerable<object[]> Damages
        {
            get
            {
                return new List<object[]>
                    {
                        new object[]{1,99},
                        new object[]{0,100},
                        new object[]{100,1},
                        new object[]{101,1},
                        new object[]{ 50, 50}
                    };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(Damages))]
        [PlayerHealth]
        public void TakeDamageList(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(sut.Health, expectedHealth);
        }

        [DataTestMethod]
        [DynamicData(nameof(DamageData.GetDamages), typeof(DamageData), DynamicDataSourceType.Method)]
        [PlayerHealth]
        public void TakeDamageClass(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(sut.Health, expectedHealth);
        }

        [DataTestMethod]
        [DynamicData(nameof(ExternalHealthDamageTestData.TestData), typeof(ExternalHealthDamageTestData))]
        [TestCategory("Player Health")]
        public void TakeDamageExternalSource(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(sut.Health, expectedHealth);
        }

        [DataTestMethod]
        [CsvDataSource("Damages.csv")]
        [PlayerHealth]
        public void TakeDamageExternalSourceExtension(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(sut.Health, expectedHealth);
        }

        [DataTestMethod]
        [DataRow(1, 99)]
        [DataRow(0, 100)]
        [DataRow(100, 1)]
        [DataRow(50, 50)]
        [TestCategory("Player Health")]
        public void TakeDamage(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(sut.Health, expectedHealth);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void TakeDamage_NotEqual()
        {
            sut.TakeDamage(1);

            Assert.AreNotEqual(sut.Health, 100);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void IncreaseHealthAfterSleeping()
        {
            sut.Sleep();//Expect increase between 1 to 100 inclusive

            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

        [TestMethod]
        [TestCategory("Player Health")]
        public void IncreaseHealthAfterSleepingExtensionMethod()
        {
            sut.Sleep();//Expect increase between 1 to 100 inclusive

            Assert.That.IsInRange(sut.Health, 101, 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {

            Assert.AreEqual("SARAH SMITH", sut.FullName, true);
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            StringAssert.StartsWith(sut.FullName, "Sarah");
        }

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {
            StringAssert.EndsWith(sut.FullName, "Smith");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssertExample()
        {
            StringAssert.Contains(sut.FullName, "ah Sm");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void NotHaveAStaffOfWonder()
        {
            CollectionAssert.DoesNotContain(sut.Weapons, "Staff Of Wonder");
        }

        [TestMethod]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(sut.Weapons, expectedWeapons);
        }

        [TestMethod]
        public void HaveAllExpectedWeapons_AnyOrder()
        {
            var expectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            CollectionAssert.AreEquivalent(sut.Weapons, expectedWeapons);
        }

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSwordExtensionb()
        {
            CollectionAssert.That.AtLeastOneItemSatisfies(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrEmpty(weapon)));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeaponsExtension()
        {
            CollectionAssert.That.AllItemsNotNullOrWhiteSpace(sut.Weapons);
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeaponsExtensionAllItemsSatisfy()
        {
            CollectionAssert.That.AllItemsSatisfy(sut.Weapons, weapon => !string.IsNullOrWhiteSpace(weapon));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeaponsExtensionAll()
        {
            CollectionAssert.That.All(sut.Weapons, weapon =>
            {
                StringAssert.That.NotNullOrWhiteSpace(weapon);
                Assert.IsTrue(weapon.Length > 5);
            });
        }
    }
}
