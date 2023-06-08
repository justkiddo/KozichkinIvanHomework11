using UnityEngine;
using Zenject;

namespace root
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        private IPlayer _player;
        public bool followPlayer;
        private EnemyInfo _enemyInfo;
        private float _distanceFromPlayer;
        private GameplayInfo _gameplayInfo;

        [Inject]
        private void Construct(IPlayer player, EnemyInfo enemyInfo,GameplayInfo gameplayInfo)
        {
            _player = player;
            _enemyInfo = enemyInfo;
            _gameplayInfo = gameplayInfo;
        }
        
        public void Init(EnemyInfo enemyInfo)
        {
            
        }

        private void Update()
        {
            DistanceCheck();
            if (followPlayer)
            {
                FollowingPlayer();
            }
        }

        private void FollowingPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.GetCurrentPosition(),
                Time.deltaTime * speed);
        }

        private void DistanceCheck()
        {
            _distanceFromPlayer = Vector2.Distance(_player.GetCurrentPosition(), transform.position);
            if (_distanceFromPlayer < _enemyInfo.FollowDistance)
            {
                followPlayer = true;
                if (Vector2.Distance(_player.GetCurrentPosition(), transform.position) < 2f)
                {
                    _gameplayInfo.EndGame.Value = true;
                }
            }
            else
            {
                followPlayer = false;
            }
        }
    }
}
