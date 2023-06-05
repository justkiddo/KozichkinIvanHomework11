using UniRx;

namespace root
{
    public class GameplayInfo
    {
        public ReactiveProperty<int> CoinCount { get; } = new();
        public ReactiveProperty<string> CoinTime { get; } = new StringReactiveProperty();
        public ReactiveProperty<int> CollectedCoins { get; } = new();
        public ReactiveProperty<bool> EndGame = new BoolReactiveProperty(false);
    }
}
