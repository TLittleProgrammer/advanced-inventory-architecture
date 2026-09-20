using System.Runtime.Serialization;
using GameData.LocalPackages.GameData;
using NUnit.Framework;

namespace LocalPackages.game_data.Tests
{
    internal class EnemyDataTests
    {
        private IGameData<EnemyType, EnemyData> _data;
        
        [SetUp]
        public void SetUp()
        {
            _data = new GameDataCollection<EnemyType, EnemyData, EnemyFillableData>();
        }

        [TestCase(EnemyType.Ogre, 1000, 0, 0.5f)]
        [TestCase(EnemyType.Mage,450, 750, 1f)]
        [TestCase(EnemyType.Skeleton,100, 0, 2.5f)]
        public void CheckStaticStats(EnemyType enemyType, int hp, int mana, float speed)
        {
            if (!_data.TryGetValue(enemyType, out var data))
            {
                Assert.Fail($"Data by EnemyType {enemyType.ToString()} not found!");
                return;
            }
            
            Assert.AreEqual(hp, data.Hp);
            Assert.AreEqual(mana, data.Mana);
            Assert.AreEqual(speed, data.Speed);
        }

        [TestCase(EnemyType.Ogre, 1000)]
        [TestCase(EnemyType.Mage, 450)]
        [TestCase(EnemyType.Skeleton, 100)]
        public void GetDataFromBrackets(EnemyType enemyType, int expectedHp)
        {
            Assert.AreEqual(expectedHp, _data[enemyType].Hp);
        }
        
        [Test]
        public void SumAllHpWithForEach()
        {
            var expectedHp = 1550;
            var actualHp = 0;

            foreach (var data in _data)
            {
                actualHp += data.Hp;
            }
            
            Assert.AreEqual(expectedHp, actualHp);
        }
    }
}