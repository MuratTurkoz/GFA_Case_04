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
            Debug.Log("Magnitude"+_playerMediator.LookPosition.magnitude);
            Debug.Log("Normalized" + _playerMediator.LookPosition.normalized);
            _characterController.Move(_playerMediator.LookPosition.magnitude * Time.deltaTime * _playerMediator.Movement);





            //_groundedPlayer = _characterController.isGrounded;
            //if (_groundedPlayer && _playerVelocity.y < 0)
            //{
            //    _playerVelocity.y = 0f;
            //}

            //_characterController.Move(_playerMediator.Movement * Time.deltaTime * playerSpeed);
            ////Rotate
            //if (_playerMediator.Movement != Vector3.zero)
            //{
            //    //transform.Rotate(_playerMediator.LookPosition);
            //    gameObject.transform.forward = _playerMediator.Movement;

            //}

            //// Jump
            //if (_playerMediator.IsJumped && _groundedPlayer)
            //{
            //    _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //}

            //_playerVelocity.y += gravityValue * Time.deltaTime;
            //_characterController.Move(_playerMediator.Movement * Time.deltaTime);

            ////Crouch
            //if (_playerMediator.IsCrouch)
            //{

            //}
        }



    }
}
//[Header("Character Input Values")]
//public Vector2 move;
//public Vector2 look;
//public bool jump;
//public bool sprint;

//[Header("Movement Settings")]
//public bool analogMovement;

//[Header("Mouse Cursor Settings")]
//public bool cursorLocked = true;
//public bool cursorInputForLook = true;

//#if ENABLE_INPUT_SYSTEM
//public void OnMove(InputValue value)
//{
//    MoveInput(value.Get<Vector2>());
//}

//public void OnLook(InputValue value)
//{
//    if (cursorInputForLook)
//    {
//        LookInput(value.Get<Vector2>());
//    }
//}

//public void OnJump(InputValue value)
//{
//    JumpInput(value.isPressed);
//}

//public void OnSprint(InputValue value)
//{
//    SprintInput(value.isPressed);
//}
//#endif


//public void MoveInput(Vector2 newMoveDirection)
//{
//    move = newMoveDirection;
//}

//public void LookInput(Vector2 newLookDirection)
//{
//    look = newLookDirection;
//}

//public void JumpInput(bool newJumpState)
//{
//    jump = newJumpState;
//}

//public void SprintInput(bool newSprintState)
//{
//    sprint = newSprintState;
//}

//private void OnApplicationFocus(bool hasFocus)
//{
//    SetCursorState(cursorLocked);
//}

//private void SetCursorState(bool newState)
//{
//    Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
//}


