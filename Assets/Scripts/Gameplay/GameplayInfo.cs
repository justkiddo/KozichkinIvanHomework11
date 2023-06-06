using UniRx;

namespace root
{
    public class GameplayInfo
    {
        public ReactiveProperty<int> CoinCount { get; } = new IntReactiveProperty();
        public ReactiveProperty<string> CoinTime { get; } = new StringReactiveProperty();
        public ReactiveProperty<int> CollectedCoins { get; } = new IntReactiveProperty();
        public ReactiveProperty<bool> EndGame { get; } = new BoolReactiveProperty(false);
        public ReactiveProperty<float> BestTime { get; } = new FloatReactiveProperty();
    }
}
