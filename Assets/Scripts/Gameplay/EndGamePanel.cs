using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace root
{
    public class EndGamePanel : MonoBehaviour, IInitializable
    {
        [SerializeField] private TextMeshProUGUI coinsInfo;
        [SerializeField] private TextMeshProUGUI timeInfo;
        [SerializeField] private TextMeshProUGUI bestTimeInfo;
        [SerializeField] private TextMeshProUGUI bestCoinInfo;
        [SerializeField] private Button restartButton;
        [SerializeField] private TextMeshProUGUI restartButtonText;
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
            _disposable = new CompositeDisposable();  // не отрабатывает при перезагрузке
        }

        private void Awake()
        {
            _disposable = new CompositeDisposable();
        }

        private void Update()
        {
            if (_gameplayInfo.EndGame.Value)
            {
                AddListeners();
            }
        }

        private void AddListeners()
        {
            _gameplayInfo.CollectedCoins.Subscribe(_ => UpdateCoinInfo()).AddTo(_disposable);
            _gameplayInfo.CoinTime.Subscribe(_=>UpdateCoinTimeInfo()).AddTo(_disposable);
            _gameplayInfo.BestTime.Subscribe(_=>BestTimeUpdate());
            _gameplayInfo.BestCoins.Subscribe(_=>BestCoinsUpdate());
             restartButton.onClick.AsObservable().Subscribe(_=> OnButtonClicked()).AddTo(_disposable);
             restartButtonText.text = _localization.Translate("restart.button");
        }
        
        private void UpdateCoinInfo()
        {
            coinsInfo.text = _localization.Translate("endgame.score", _gameplayInfo.CollectedCoins.Value);
            
        }
        private void OnButtonClicked()
        {
            // Time.timeScale = 1f;
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //PlayerPrefs.DeleteAll();
            
            
            
        }

        private void UpdateCoinTimeInfo()
        {
            timeInfo.text = _localization.Translate("endgame.time", _gameplayInfo.CoinTime.Value);
        }

        private void BestTimeUpdate()
        {
            if (_gameplayInfo.BestTime.Value > _gameplayInfo.CoinTime.Value || _gameplayInfo.BestTime.Value == 0)
            {
                _gameplayInfo.BestTime.Value = _gameplayInfo.CoinTime.Value;
            }
            bestTimeInfo.text = _localization.Translate("endgame.best.time",_gameplayInfo.BestTime.Value);
        }

        private void BestCoinsUpdate()
        {
            
            if (_gameplayInfo.BestCoins.Value <= _gameplayInfo.CollectedCoins.Value)
            {
                _gameplayInfo.BestCoins.Value = _gameplayInfo.CollectedCoins.Value;
            }
            bestCoinInfo.text = _localization.Translate("endgame.best.coins",_gameplayInfo.BestCoins.Value);
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }
    }
}
