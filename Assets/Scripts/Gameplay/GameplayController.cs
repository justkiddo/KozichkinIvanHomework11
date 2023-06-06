using UniRx;
using UnityEngine;
using Zenject;

namespace root
{
    public class GameplayController : IInitializable
    {
        
        private GameplayInfo _gameplayInfo;
        private CompositeDisposable _disposable;
        private static bool _endGame { get; set; } = false;

        [Inject]
        private void Construct( GameplayInfo gameplayInfo)
        {
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
            if (_gameplayInfo.CoinCount.Value == 0)
            {
                EndGame();
            } 
        }

        public void EndGame()
        {
            _endGame = true;
            _gameplayInfo.CoinTime.Value = Time.time.ToString();
            _gameplayInfo.EndGame.Value = true;
            if (_gameplayInfo.BestTime.Value !=0 )
            {
                //!!!!!!!!!!!!!
            }
            Time.timeScale = 0;
        }
        
        
    }
}
