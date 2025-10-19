using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectAssets.Scripts.architecture.mvc.player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        public event Action OnGrounded;
        
        private void Awake()
        {
            Assert.IsNotNull(_rb, "Rigidbody2D is required");
        }

        public void Move(float horizontalInput, float speed)
        {
            _rb.linearVelocityX = horizontalInput * speed;
        }

        public void Jump(float jumpForce)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                OnGrounded?.Invoke();
            }
        }
    }
}