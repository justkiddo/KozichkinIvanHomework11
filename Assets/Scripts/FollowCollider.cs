using UnityEngine;

namespace root
{
    public class FollowCollider : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _enemy._followPlayer = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _enemy._followPlayer = false;
            }
        }
    }
}
