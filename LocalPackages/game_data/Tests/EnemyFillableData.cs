using GameData.LocalPackages.GameData;

namespace LocalPackages.game_data.Tests
{
    internal class EnemyFillableData : FillableGameData<EnemyType, EnemyData>
    {
        public override void FillData()
        {
            Add
            (
                key: EnemyType.Ogre,
                value: enemy(1000, 0, 0.5f)
            );
            
            Add
            (
                key: EnemyType.Mage,
                value: enemy(450, 750, 1f)
            );
            
            Add
            (
                key: EnemyType.Skeleton,
                value: enemy(100, 0, 2.5f)
            );
        }

        private EnemyData enemy(int hp, int mana, float speed) => new(hp, mana, speed);
    }
}