using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace root
{
    public class DeathCollider : MonoBehaviour
    {
         private GameObject followCollider;
         private Enemy _enemy;
        private GameplayInfo _gameplayInfo;
        
        [Inject]
        private void Construct(GameplayInfo gameplayInfo)
        {
            _gameplayInfo = gameplayInfo;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _gameplayInfo.EndGame.Value = true;
            }
        }
        
        
    }
}
