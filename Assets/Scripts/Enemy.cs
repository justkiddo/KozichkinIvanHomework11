using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace root
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed = 2;
        [SerializeField] private Transform enemyPosition;
        private IPlayer _player;
        public bool followPlayer;
        
        
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
            if (followPlayer)
            { 
                transform. position = Vector3.MoveTowards(transform.position, _player.GetCurrentPosition(), 
                    Time.deltaTime * speed );
            }
            else
            {
                
            }
        }

    }
}
