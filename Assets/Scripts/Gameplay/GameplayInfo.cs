using UniRx;
using UnityEngine;
using Zenject;

namespace root
{
    public class GameplayInfo: IInitializable
    {
        public ReactiveProperty<int> CoinCount { get; } = new IntReactiveProperty();
        public ReactiveProperty<float> CoinTime { get; } = new FloatReactiveProperty();
        public ReactiveProperty<int> CollectedCoins { get; } = new IntReactiveProperty(0);
        public ReactiveProperty<bool> EndGame { get; } = new BoolReactiveProperty(false);
        public ReactiveProperty<float> BestTime { get; } = new FloatReactiveProperty(0);
        public ReactiveProperty<int> BestCoins { get; } = new IntReactiveProperty(0);
        private const string BestTimeKey = "BEST.TIME";
        private const string BestCoinsKey = "BEST.COINS";
        public void Initialize()
        {
            BestTime.Value = PlayerPrefs.GetFloat(BestTimeKey);
            BestCoins.Value = PlayerPrefs.GetInt(BestCoinsKey);
            BestTime.Subscribe(_=>OnBestTimeChange());
            BestCoins.Subscribe(_=> OnBestCoinsChange());
            
        }

        private void OnBestTimeChange()
        {
            PlayerPrefs.SetFloat(BestTimeKey, BestTime.Value);
            PlayerPrefs.Save();
        }
        private void OnBestCoinsChange()
        {
            PlayerPrefs.SetInt(BestCoinsKey, BestCoins.Value);
            PlayerPrefs.Save();
        }
        
    }
}
