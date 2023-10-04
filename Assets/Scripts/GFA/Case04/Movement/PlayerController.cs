using Cinemachine;
using GFA.Case04.Input;
using GFA.Case04.Mediators;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
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
        private float playerRunSpeed = 4f;
        [SerializeField]
        private float jumpHeight = 1.0f;
        [SerializeField]
        private float gravityValue = -9.81f;
        [SerializeField] PlayerInput _playerInput;
        private CharacterController _characterController;
        public CharacterController CharacterControllerOld { get => _characterController;set { _characterController = value; } }
        private Transform cameraTransform;
        private Vector3 playerVelocity;
        private bool groundedPlayer;


        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            _characterController = GetComponent<CharacterController>();
            CharacterControllerOld= _characterController;
            cameraTransform = Camera.main.transform;
        }

        void Update()
        {
            //groundedPlayer = _characterController.isGrounded;
            //Debug.Log(groundedPlayer);
            //if (groundedPlayer && playerVelocity.y < 0)
            //{
            //    playerVelocity.y = 0f;
            //}
            ////Vector2 movement = _playerInput.GetPlayerMovement();
            //Vector2 movement = _playerMediator.Movement;

            //Vector3 move = new Vector3(movement.x, 0, movement.y);
            //move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            //move.y = 0f;
            //_characterController.Move(move * Time.deltaTime * playerSpeed);

            //if (move != Vector3.zero)
            //{
            //    gameObject.transform.forward = move;
            //}

            //// Changes the height position of the player..
            //if (_playerInput.PlayerJumpedThisFrame() && groundedPlayer)
            //{
            //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //    //_playerInput.SetJump();
            //}
            //playerVelocity.y += gravityValue * Time.deltaTime;
            //_characterController.Move(playerVelocity * Time.deltaTime);
        }
        public void MoveHandle()
        {
            groundedPlayer = _characterController.isGrounded;
            //Debug.Log(groundedPlayer);
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            //Vector2 movement = _playerInput.GetPlayerMovement();
            Vector2 movement = _playerMediator.Movement;

            Vector3 move = new Vector3(movement.x, 0, movement.y);
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;
            if (_playerMediator.IsRun == true)
            {

                _characterController.Move(move * Time.deltaTime * playerRunSpeed);
                //_playerMediator.SetIsRun();
                //StartCoroutine(nameof(RunTime));

            }
            _characterController.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            // Changes the height position of the player..
            //if (_playerInput.PlayerJumpedThisFrame() && groundedPlayer)
            //{
            //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //    _playerInput.SetJump();
            //}
            if (_playerMediator.IsJumped && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            _characterController.Move(playerVelocity * Time.deltaTime);

        }




    }
}


