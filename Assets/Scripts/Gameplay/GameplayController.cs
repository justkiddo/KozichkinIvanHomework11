using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace root
{
    public class GameplayController : IInitializable
    {
        
        private GameplayInfo _gameplayInfo;
        private EnemyFactory _enemyFactory;
        private static bool _endGame { get; set; } = false;

        [Inject]
        private void Construct( GameplayInfo gameplayInfo, EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _gameplayInfo = gameplayInfo;
        }
        

        public void Initialize()
        {
            AddListeners();
            _gameplayInfo.EndGame.Value = false;
            _gameplayInfo.CoinTime.Value = String.Empty;
            _enemyFactory.Create();
        }
        
        private void AddListeners()
        {
            _gameplayInfo.CoinCount.Subscribe(_ => UpdateInfo());
            _gameplayInfo.EndGame.Subscribe(_ => UpdateInfo());
        }

        private void UpdateInfo()
        {
            if (_gameplayInfo.CoinCount.Value == 0 || _gameplayInfo.EndGame.Value )
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
