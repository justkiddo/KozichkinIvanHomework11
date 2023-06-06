using UnityEngine;

namespace root
{
    public class CharacterMovement : MonoBehaviour,IPlayer
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Collider2D cl;
        [Range(2,10)]
        [SerializeField] private float movementSpeed = 5f;
        [Range(5,15)]
        [SerializeField] private float jumpForce = 5f;

        [SerializeField] private AudioSource coinSound;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
    

        void Update()
        {
            var moveInput = Input.GetAxis("Horizontal");
            var runMultiplication =  (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;
            var speed = runMultiplication * movementSpeed;


            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
            }

        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Coin"))
            {
                coinSound.Play(); 
            }
        }

        public Vector3 GetCurrentPosition() => transform.position;

    }
}
