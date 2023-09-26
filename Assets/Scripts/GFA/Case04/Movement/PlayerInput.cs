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
        public GameInput _gameInput;
        private Vector2 _position;
        //private float _jumpForce;
        [SerializeField] private PlayerMediator _playerMediator;
        //int _crouchCount = 0;
        private void Awake()
        {
            _gameInput = new GameInput();
        }
        private void OnEnable()
        {
            _gameInput.Enable();
            _gameInput.Player.Jump.performed += OnJump;
            _gameInput.Player.Crouch.Enable();
        }
        private void OnDisable()
        {
            _gameInput.Disable();
            _gameInput.Player.Jump.performed -= OnJump;
            _gameInput.Player.Crouch.Disable();
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            //_playerMediator.Behaviour = MoveBehaviour.Jump;
            //_playerMediator.IsJumped = true;
        }

        public void OnMove()
        {

            _position = _gameInput.Player.Movement.ReadValue<Vector2>();
            _playerMediator.Movement = new Vector3(_position.x, 0, _position.y);

        }
        private void Update()
        {
            //CrouchHandle();
            //_playerMediator.IsCrouch = _gameInput.Player.Crouch.triggered;
            //Debug.Log(_playerMediator.Movement);
            //OnMove();
            //_playerMediator.IsCrouch = false;
        }
        void CrouchHandle()
        {
            //_playerMediator.IsCrouch = _gameInput.Player.Crouch.triggered;
            //if (_gameInput.Player.Crouch.triggered == true)
            //{
            //    _crouchCount++;
            //    Debug.Log(_crouchCount);

            //}
            //if (_crouchCount % 2 == 0)
            //{
            //    //_playerMediator.IsCrouch = true;
            //}
            //else
            //{
            //    //_playerMediator.IsCrouch = false;
            //}
        }

        public Vector3 GetPlayerMovement()
        {
            _position = _gameInput.Player.Movement.ReadValue<Vector2>();
            Vector3 move = new Vector3(_position.x, 0, _position.y);
            return move;
        }
        public Vector2 GetMouseDelta()
        {
            return _gameInput.Player.Look.ReadValue<Vector2>();
        }
        public bool PlayerJumpedThisFrame()
        {
            return _gameInput.Player.Jump.triggered;
        }

    }
}