using UnityEngine;
using Zenject;

namespace root
{
    public class DeathCollider : MonoBehaviour
    {
        private GameplayController _gameplayController;


        [Inject]
        private void Construct(GameplayController gameplayController)
        {
            _gameplayController = gameplayController;
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _gameplayController.EndGame();
            }
        }
    }
}
