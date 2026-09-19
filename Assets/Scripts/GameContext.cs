namespace DefaultNamespace
{
    public sealed class GameContext : IGameContext
    {
        public GameDataContainer Data { get; } = new();
    }
}