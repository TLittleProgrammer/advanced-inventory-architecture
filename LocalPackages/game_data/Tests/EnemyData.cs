namespace LocalPackages.game_data.Tests
{
    internal class EnemyData
    {
        public readonly int Hp;
        public readonly int Mana;
        public readonly float Speed;

        public EnemyData(int hp, int mana, float speed)
        {
            Speed = speed;
            Mana = mana;
            Hp = hp;
        }
    }
}