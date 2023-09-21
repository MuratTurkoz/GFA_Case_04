using GFA.Case04.Input;
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
        [SerializeField] private PlayerController _playerController;

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

        }

        public void OnMove()
        {
            _position = _gameInput.Player.Movement.ReadValue<Vector2>();
            _playerController.Movement = new Vector3(_position.x, 0, _position.y);

        }

    }
}