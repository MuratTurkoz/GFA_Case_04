using GFA.Case04.Input;
using GFA.Case04.Mediators;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

namespace GFA.Case04.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float playerSpeed = 2.0f;
        [SerializeField]
        private float jumpHeight = 1.0f;
        [SerializeField]
        private float gravityValue = -9.81f;
        [SerializeField] private PlayerMediator _playerMediator;
        private CharacterController _characterController;
        private Vector3 _playerVelocity;
        private bool _groundedPlayer;
        private void Awake()
        {
            //_characterController = GetComponent<CharacterController>();
        }
        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
        }
        public void MoveHandle()
        {
            _groundedPlayer = _characterController.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            _characterController.Move(_playerMediator.Movement * Time.deltaTime * playerSpeed);
            //Rotate
            if (_playerMediator.Movement != Vector3.zero)
            {
                //transform.Rotate(_playerMediator.LookPosition);
                gameObject.transform.forward = _playerMediator.Movement;

            }

            // Jump
            if (_playerMediator.IsJumped && _groundedPlayer)
            {
                _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            _playerVelocity.y += gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);

            //Crouch
            if (_playerMediator.IsCrouch)
            {

            }
        }



    }
}


