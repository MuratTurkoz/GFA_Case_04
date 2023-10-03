using Cinemachine;
using GFA.Case04.Input;
using GFA.Case04.Mediators;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

namespace GFA.Case04.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMediator _playerMediator;
        [SerializeField]
        private float playerSpeed = 0.2f;
        [SerializeField]
        private Vector3 _direction;
        [SerializeField]
        private float jumpHeight = 1.0f;
        [SerializeField]
        private float gravityValue = -9.81f;
        private CharacterController _characterController;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        private Transform cameraTransform;
        private Vector3 move;
        private float xRotation = 0;
        [SerializeField] CinemachineVirtualCamera _camera;
        public bool canMove = true;


        public float walkSpeed = 6f;
        public float runSpeed = 12f;
        public float jumpPower = 7f;
        public float gravity = 10f;


        public float lookSpeed = 2f;
        public float lookXLimit = 45f;
        float rotationX = 0;


        Vector3 moveDirection = Vector3.zero;

        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
       [SerializeField] PlayerInput _playerInput;
        //private float playerSpeed = 2.0f;
        //private float jumpHeight = 1.0f;
        //private float gravityValue = -9.81f;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _characterController = GetComponent<CharacterController>();
            cameraTransform=Camera.main.transform;
        }

        void Update()
        {
            groundedPlayer = _characterController.isGrounded;
            Debug.Log(groundedPlayer);
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            Vector2 movement = _playerInput.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            move=cameraTransform.forward*move.z+cameraTransform.right*move.x;
            move.y = 0f;
            _characterController.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            if (_playerInput.PlayerJumpedThisFrame()&& groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                _playerInput.SetJump();
               
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            _characterController.Move(playerVelocity * Time.deltaTime);
        }

        //private void Awake()
        //{
        //    //cameraTransform = Camera.main.transform;
        //    _characterController = GetComponent<CharacterController>();
        //}
        //private void Start()
        //{
        //    //_characterController = GetComponent<CharacterController>();
        //}
        //public void MoveHandle()
        //{
        //    //_playerMediator.IsGrounded = _characterController.isGrounded;
        //    //var gamepadLookDir = _playerMediator.LookPosition;
        //    //if (gamepadLookDir != Vector2.zero)
        //    //{
        //    //    transform.Rotate(Vector3.up * gamepadLookDir.x * Time.deltaTime);
        //    //}
        //    //Vector3 inputDirection = new Vector3(_playerMediator.Movement.x, 0.0f, _playerMediator.Movement.y).normalized;
        //    //if (_playerMediator.Movement != Vector3.zero)
        //    //{
        //    //    // move
        //    //    inputDirection = transform.right * _playerMediator.Movement.x + transform.forward * _playerMediator.Movement.z;
        //    //}
        //    //float movementDirectionY = inputDirection.y;
        //    ////#region Handles Jumping
        //    //if (_playerMediator.IsJumped && canMove && _characterController.isGrounded)
        //    //{
        //    //    inputDirection.y = jumpPower;
        //    //}
        //    //else
        //    //{
        //    //    inputDirection.y = movementDirectionY;
        //    //}

        //    //if (!_characterController.isGrounded)
        //    //{
        //    //    moveDirection.y -= gravity * Time.deltaTime;
        //    //}
        //    //_characterController.Move(inputDirection.normalized * (playerSpeed * Time.deltaTime) + new Vector3(0.0f, _playerVelocity.y, 0.0f) * Time.deltaTime);


        //}

    }
}


