using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace root
{
    public class FollowPlayerCollider : MonoBehaviour
    {
        [SerializeField] private GameObject followCollider;
        [SerializeField] private Enemy _enemy;
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
                _enemy.followPlayer = true;
            }
        }


        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy.followPlayer = false;
            }
        }
    }
}
