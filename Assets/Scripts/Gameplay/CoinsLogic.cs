using UnityEngine;
using Zenject;

namespace root
{
    public class CoinsLogic : MonoBehaviour
    {
        [SerializeField] private GameObject coin;
        private GameplayInfo _gameplayInfo;
        
        [Inject]
        private void Construct(GameplayInfo gameplayInfo)
        {
            _gameplayInfo = gameplayInfo;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            _gameplayInfo.CoinCount.Value--;
            _gameplayInfo.CollectedCoins.Value++;
            Destroy(coin);
        }
    }
}
