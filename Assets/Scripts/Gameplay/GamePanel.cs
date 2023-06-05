using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace root
{
    public class GamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI coinsInfo;
        private IUnityLocalization _localization;
        private GameplayInfo _gameplayInfo;
        private CompositeDisposable _disposable;
        private List<GameObject> coins = new();
        
        private void Awake()
        {
            foreach (var coin in GameObject.FindGameObjectsWithTag("Coin"))
            {
                coins.Add(coin);
                _gameplayInfo.CoinCount.Value = coins.Count;
            }
        }

        private void Update()
        {
            if (_gameplayInfo.EndGame.Value == true)
            {
                Destroy(coinsInfo);
            }
        }

        [Inject]
        private void Construct(GameplayInfo gameplayInfo, IUnityLocalization localization)
        {
            _localization = localization;
            _gameplayInfo = gameplayInfo;
        }
        
        
        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            AddListeners();
        }

        private void AddListeners()
        {
            _gameplayInfo.CoinCount.Subscribe(_ => UpdateInfo()).AddTo(_disposable);
        }

        private void UpdateInfo()
        {
            coinsInfo.text = _localization.Translate("coins.left", _gameplayInfo.CoinCount.Value);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}
