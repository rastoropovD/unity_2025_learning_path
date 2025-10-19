using System;
using UnityEngine;

namespace ProjectAssets.Scripts.architecture.mvc.player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerView _view;

        private readonly PlayerModel _model = new ();
        
        private float _horizontalInput = 0;

        private void Awake()
        {
            _view.OnGrounded += OnGrounded;
        }

        private void OnGrounded()
        {
            _model.IsGrounded = true;
        }

        private void Update()
        {
            // get horizontal direction 1 - move right; -1 - move left
            _horizontalInput = Input.GetAxis("Horizontal");
            _view.Move(_horizontalInput, _model.Speed);
            
            if (Input.GetKeyDown(KeyCode.Space) && _model.IsGrounded)
            {
                _model.IsGrounded = false;
                _view.Jump(_model.JumpForce);
            }
        }

        private void OnDestroy()
        {
            _view.OnGrounded -= OnGrounded;
        }
    }
}