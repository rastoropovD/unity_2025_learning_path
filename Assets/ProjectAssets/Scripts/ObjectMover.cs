using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace ProjectAssets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ObjectMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _jumpForce = 20f;

        private Rigidbody2D _rigidbody;

        private float _horizontalInput = 0;
        private bool _isGrounded;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            Assert.IsNotNull(_rigidbody, "Rigidbody2D is required");
        }

        private void Update()
        {
            // get horizontal direction 1 - move right; -1 - move left
            _horizontalInput = Input.GetAxis("Horizontal");
            _rigidbody.linearVelocityX = _horizontalInput *_speed;
            
            // alternative movement
            // if (Input.GetKey(KeyCode.D))
            // {
            //     // move right with pressed 'D'
            //     _rigidbody.linearVelocityX = _horizontalInput *_speed;
            // }
            // else if (Input.GetKey(KeyCode.A))
            // {
            //     // move left with pressed 'A'
            //     _rigidbody.linearVelocityX = -_speed;
            // }
            
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _isGrounded = false;
                _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
        }

        // MonoBehavior method that raised when object interacted with another Collider2D
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
    }
}