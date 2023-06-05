using UnityEngine;
using Zenject;

namespace root
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        [SerializeField] private Transform enemyPosition;
        private IPlayer _player;
        public bool _followPlayer;
        
        
        [Inject]
        private void Construct(IPlayer player)
        {
            _player = player;
        }

        public void Init(EnemyInfo enemyInfo)
        {
        }

        private void Update()
        {
            if (_followPlayer)
            { 
                transform. position = Vector3.MoveTowards(transform.position, _player.GetCurrentPosition(), 
                    Time.deltaTime * speed );
            }
            else
            {
                
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _followPlayer = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _followPlayer = false;
            }
        }
    }
}
