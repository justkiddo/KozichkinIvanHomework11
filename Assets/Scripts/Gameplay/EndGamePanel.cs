using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace root
{
    public class EndGamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI coinsInfo;
        [SerializeField] private TextMeshProUGUI timeInfo;
        private IUnityLocalization _localization;
        private GameplayInfo _gameplayInfo;
        private CompositeDisposable _disposable;
        
        
        [Inject]
        private void Construct(GameplayInfo gameplayInfo, IUnityLocalization localization)
        {
            _localization = localization;
            _gameplayInfo = gameplayInfo;
        }

        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            
        }

        private void Update()
        {
            if (_gameplayInfo.EndGame.Value== true)
            {
                AddListeners();
            }
        }

        private void AddListeners()
        {
            _gameplayInfo.CollectedCoins.Subscribe(_ => UpdateCoinInfo()).AddTo(_disposable);
            _gameplayInfo.CoinTime.Subscribe(_=>UpdateCoinTimeInfo());
        }
        
        private void UpdateCoinInfo()
        {
            coinsInfo.text = _localization.Translate("endgame.score", _gameplayInfo.CollectedCoins.Value);
            
        }

        private void UpdateCoinTimeInfo()
        {
            timeInfo.text = _localization.Translate("endgame.time", _gameplayInfo.CoinTime.Value);
        }
        
        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}
