using GFA.Case04.Input;
using GFA.Case04.Mediators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GFA.Case04.Movement
{
    public class PlayerInput : MonoBehaviour
    {
        private GameInput _gameInput;
        private Vector2 _position;
        private float _jumpForce;  
        [SerializeField] private PlayerMediator _playerMediator;
        private void Awake()
        {
            _gameInput = new GameInput();
        }
        private void OnEnable()
        {
            _gameInput.Enable();
            _gameInput.Player.Jump.performed += OnJump;
        }
        private void OnDisable()
        {
            _gameInput.Disable();
            _gameInput.Player.Jump.performed -= OnJump;
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            _playerMediator.IsJumped = true;   
        }

        public void OnMove()
        {
            _position = _gameInput.Player.Movement.ReadValue<Vector2>();
            if (_position == Vector2.zero)
            {
                _playerMediator.Behaviour = MoveBehaviour.Idle;
            }
            else
            {
                _playerMediator.Behaviour = MoveBehaviour.Run;
                _playerMediator.Movement = new Vector3(_position.x,0, _position.y);
            }
            Debug.Log(_position);

        }
        private void Update()
        {
            Debug.Log(_playerMediator.Movement);
            OnMove();
           
        }

    }
}