using GFA.Case04.Input;
using GFA.Case04.Mediators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GFA.Case04.Movement
{
    public class PlayerInput : MonoBehaviour
    {
        public GameInput _gameInput;
        private Vector2 _position;
        //[SerializeField] private PlayerMediator _playerMediator;
        [SerializeField] private Vector2 _look;
        [SerializeField] private Vector3 _move;
        [SerializeField] private bool _isJump;
        [SerializeField] private bool _isRun;
        private void Awake()
        {
            _gameInput = new GameInput();
        }
        private void OnEnable()
        {
            _gameInput.Enable();
            _gameInput.Player.Jump.performed += OnJump;
            _gameInput.Player.Look.performed += OnLook;
            _gameInput.Player.Run.performed += OnRun;
            _gameInput.Player.Crouch.Enable();
        }
        private void OnDisable()
        {
            _gameInput.Disable();
            _gameInput.Player.Jump.performed -= OnJump;
            _gameInput.Player.Look.performed -= OnLook;
            _gameInput.Player.Run.performed -= OnRun;
            _gameInput.Player.Crouch.Disable();
        }

        private void OnJump(InputAction.CallbackContext context)
        {
            _isJump = context.action.triggered;
        }

        private void OnLook(InputAction.CallbackContext context)
        {
            _look = Vector2.zero;
            _look = context.ReadValue<Vector2>();
        }

        public void OnMove()
        {

            _position = _gameInput.Player.Movement.ReadValue<Vector2>();
            //_move = new Vector3(_position.x, 0, _position.y);

        }
        public void OnRun(InputAction.CallbackContext context)
        {
            _isRun = false;
            _isRun =context.action.triggered;
            Debug.Log(_isRun);
        }
        public void SetJump()
        {
            _isJump = false;
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
        public bool GetPlayerRun()
        {
       
            return _isRun;
        }
        public Vector2 GetPlayerMovement()
        {
            //OnMove();
            return _gameInput.Player.Movement.ReadValue<Vector2>();
        }
        public Vector2 GetMouseDelta()
        {
            return _look;
        }
        public bool PlayerJumpedThisFrame()
        {
            return _isJump;
        }

    }
}