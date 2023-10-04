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
        [SerializeField] private bool _isCrouch;
        [SerializeField] private bool _isRoll;
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
            _gameInput.Player.Crouch.performed += OnCrouch;
            _gameInput.Player.Rolling.performed += OnRoll;
            //_gameInput.Player.Crouch.Enable();
        }
        private void OnDisable()
        {
            _gameInput.Disable();
            _gameInput.Player.Jump.performed -= OnJump;
            _gameInput.Player.Look.performed -= OnLook;
            _gameInput.Player.Run.performed -= OnRun;
            _gameInput.Player.Crouch.performed -= OnCrouch;
            _gameInput.Player.Rolling.performed -= OnRoll;
            //_gameInput.Player.Crouch.Disable();
        }
        private void Update()
        {
            SetCrouch();
            SetIsRun();
            SetJump();
            SetRoll();

        }
        private void OnRoll(InputAction.CallbackContext context)
        {
            _isRoll = context.action.triggered;
        }

        private void OnCrouch(InputAction.CallbackContext context)
        {
            _isCrouch = context.action.triggered;
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
        }
        public void OnRun(InputAction.CallbackContext context)
        {
            _isRun = context.action.triggered;
        }
        private void SetJump()
        {
            _isJump = _gameInput.Player.Jump.IsPressed();
        }
        private void SetIsRun()
        {
            _isRun = _gameInput.Player.Run.IsPressed();
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
        public bool GetCrouchValue()
        {
            return _isCrouch;
        }
        public bool GetRollValue()
        {
            return _isRoll;
        }
        private void SetCrouch()
        {
            _isCrouch = _gameInput.Player.Crouch.IsPressed();
        }
        private void SetRoll()
        {
            _isRoll = _gameInput.Player.Rolling.IsPressed();
        }

    }
}