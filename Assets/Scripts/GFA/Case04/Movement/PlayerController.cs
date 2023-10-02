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
        private void Awake()
        {
            cameraTransform = Camera.main.transform;
            _characterController = GetComponent<CharacterController>();
        }
        private void Start()
        {
            //_characterController = GetComponent<CharacterController>();
        }
        public void MoveHandle()
        {
            //_playerMediator.IsGrounded = _characterController.isGrounded;
            //var gamepadLookDir = _playerMediator.LookPosition;
            //if (gamepadLookDir != Vector2.zero)
            //{
            //    transform.Rotate(Vector3.up * gamepadLookDir.x * Time.deltaTime);
            //}
            //Vector3 inputDirection = new Vector3(_playerMediator.Movement.x, 0.0f, _playerMediator.Movement.y).normalized;
            //if (_playerMediator.Movement != Vector3.zero)
            //{
            //    // move
            //    inputDirection = transform.right * _playerMediator.Movement.x + transform.forward * _playerMediator.Movement.z;
            //}
            //#region Handles Jumping
            //if (_playerMediator.IsJumped && canMove && _characterController.isGrounded)
            //{
            //    moveDirection.y = jumpPower;
            //}
            //else
            //{
            //    moveDirection.y = movementDirectionY;
            //}

            //if (!characterController.isGrounded)
            //{
            //    moveDirection.y -= gravity * Time.deltaTime;
            //}
            //_characterController.Move(inputDirection.normalized * (playerSpeed * Time.deltaTime) + new Vector3(0.0f, _playerVelocity.y, 0.0f) * Time.deltaTime);
  

        }
        private void Update()
        {
            #region Handles Movment
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            // Press Left Shift to run
            bool isRunning = _playerMediator.IsRun;
            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * _playerMediator.Movement.x : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * _playerMediator.Movement.x : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            #endregion

            #region Handles Jumping
            if (_playerMediator.IsJumped && canMove && _characterController.isGrounded)
            {
                moveDirection.y = jumpPower;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }

            if (!_characterController.isGrounded)
            {
                _playerMediator.IsJumped = false;
                moveDirection.y -= gravity * Time.deltaTime;
            }

            #endregion

            #region Handles Rotation
            _characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -_playerMediator.LookPosition.y * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                cameraTransform.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, _playerMediator.LookPosition.x * lookSpeed, 0);
            }

            #endregion  
        }
    }
}


