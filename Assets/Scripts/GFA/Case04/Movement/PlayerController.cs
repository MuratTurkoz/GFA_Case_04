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
        //[SerializeField] PlayerInput _playerInput;
        private CharacterController _characterController;
        public CharacterController CharacterControllerOld { get => _characterController;set { _characterController = value; } }
        private Camera _camera;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        //[SerializeField] private Animator _animCam;
        //Camera _mainCamera;

        private void Start()
        {
            //_playerInput = GetComponent<PlayerInput>();
            _characterController = GetComponent<CharacterController>();
            CharacterControllerOld= _characterController;
            _camera = Camera.main;
        }

        //void Update()
        //{
        //    //MoveHandle();
        //    //groundedPlayer = _characterController.isGrounded;
        //    //Debug.Log(groundedPlayer);
        //    //if (groundedPlayer && playerVelocity.y < 0)
        //    //{
        //    //    playerVelocity.y = 0f;
        //    //}
        //    ////Vector2 movement = _playerInput.GetPlayerMovement();
        //    //Vector2 movement = _playerMediator.Movement;

        //    //Vector3 move = new Vector3(movement.x, 0, movement.y);
        //    //move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        //    //move.y = 0f;
        //    //_characterController.Move(move * Time.deltaTime * playerSpeed);

        //    //if (move != Vector3.zero)
        //    //{
        //    //    gameObject.transform.forward = move;
        //    //}

        //    //// Changes the height position of the player..
        //    //if (_playerInput.PlayerJumpedThisFrame() && groundedPlayer)
        //    //{
        //    //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        //    //    //_playerInput.SetJump();
        //    //}
        //    //playerVelocity.y += gravityValue * Time.deltaTime;
        //    //_characterController.Move(playerVelocity * Time.deltaTime);
        //}
        public void MoveHandle()
        {
            groundedPlayer = _characterController.isGrounded;
            //Debug.Log(groundedPlayer);
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            //if (_playerMediator.Movement.y < 0)
            //{
            //    _camera.transform.rotation = Quaternion.Euler(0,-180,0);
            //}
            //Vector2 movement = _playerInput.GetPlayerMovement();
            Vector2 movement = _playerMediator.Movement;
            Vector3 move = new Vector3(movement.x, 0, movement.y);
      
            move = _camera.transform.forward * move.z + _camera.transform.right * move.x;
            //Debug.Log(cameraTransform.rotation.x);
            transform.rotation = Quaternion.Euler(_camera.transform.rotation.x,0,0);
            move.y = 0f;
            if (_playerMediator.IsRun == true)
            {

                CharacterControllerOld.Move(move * Time.deltaTime * playerRunSpeed);
                //_playerMediator.SetIsRun();
                //StartCoroutine(nameof(RunTime));

            }
            CharacterControllerOld.Move(move * Time.deltaTime * playerSpeed);

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
            CharacterControllerOld.Move(playerVelocity * Time.deltaTime);
            //if (_playerMediator.IsCrouch==true || _playerMediator.IsRolled==true)
            //{

            //    _characterController.height = 1f;
            //    _characterController.center = new Vector3(0, 0.5f, 0);
            //    //_animCam.SetBool("IsCrouch",_playerMediator.IsCrouch?_playerMediator.IsCrouch:_playerMediator.IsRolled);
            //}
            //else
            //{

            //    _characterController.height = 2f;
            //    _characterController.center = new Vector3(0, 1, 0);
            //}


        }




    }
}


