using GFA.Case04.Input;
using GFA.Case04.Movement;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Windows;

namespace GFA.Case04.Mediators
{
    public class PlayerMediator : MonoBehaviour, IPlayer
    {
        [SerializeField] private Animator _animPlayer;
        [SerializeField] private Animator _animCam;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerController _playerController;
        private float _velocity = 5f;
        public float Velocity { get { return _velocity; } set { _velocity = value; } }
        private float _rotation;
        public float Rotation { get { return _rotation; } set { _rotation = value; } }
        [SerializeField]
        private Vector3 _movement;
        public Vector3 Movement { get { return _movement; } set { _movement = value; } }

        private bool _isCrouch;
        public bool IsCrouch { get { return _isCrouch; } set { _isCrouch = value; } }
        [SerializeField]
        private bool _isJumped;
        public bool IsJumped { get { return _isJumped; } set { _isJumped = value; } }

        private bool _isRolled;
        public bool IsRolled { get { return _isRolled; } set { _isRolled = value; } }
        [SerializeField]
        private bool _isGrounded;
        public bool IsGrounded { get { return _isGrounded; } set { _isGrounded = value; } }
        [SerializeField]
        private bool _isRun;
        public bool IsRun { get { return _isRun; } set { _isRun = value; } }

        private float _jumpForce = 0;
        public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }
        [SerializeField]
        private Vector2 _lookPosition;
        public Vector2 LookPosition { get { return _lookPosition; } set { _lookPosition = value; } }
        private Vector2 _pointerPosition;
        public Vector2 PointerPosition { get { return _pointerPosition; } set { _pointerPosition = value; } }
        public MoveBehaviour Behaviour { get => _behaviour; set => _behaviour = value; }
        private MoveBehaviour _behaviour;
        public PlayerController PlayerController { get => _playerController; set => _playerController = value; }
        private void Awake()
        {

        }

        private void Update()
        {
            OnMove();
            OnJumped();
            OnRun();
            OnCrouch();
            OnRoll();
        }
        private void FixedUpdate()
        {


        }

        private void LateUpdate()
        {

        }
        private void OnRoll()
        {
            IsRolled = _playerInput.GetRollValue();
            _animPlayer.SetBool("IsRoll", IsRolled);
            _animCam.SetBool("IsCrouch", IsRolled);
            if (IsRolled)
            {
                _playerController.CharacterControllerOld.height = 1.1f;
                _playerController.CharacterControllerOld.center = new Vector3(0, 0.5f, 0);

            }
            else
            {
                _playerController.CharacterControllerOld.height = 1.5f;
                _playerController.CharacterControllerOld.center = new Vector3(0, 0.8f, 0);
            }
        }


        private void OnMove()
        {
            Movement = _playerInput.GetPlayerMovement();
            _playerController.MoveHandle();
            _animPlayer.SetFloat("MoveZ", _movement.normalized.magnitude);

        }
        private void OnJumped()
        {
            IsJumped = _playerInput.PlayerJumpedThisFrame();
            _animPlayer.SetBool("IsJump", IsJumped);

        }
        private void OnRun()
        {
            IsRun = _playerInput.GetPlayerRun();
        }
        private void OnCrouch()
        {
            IsCrouch = _playerInput.GetCrouchValue();
            _animPlayer.SetBool("IsCrouch", IsCrouch);
            _animCam.SetBool("IsCrouch", IsCrouch);
            if (IsCrouch)
            {
                _playerController.CharacterControllerOld.height = 1.1f;
                _playerController.CharacterControllerOld.center = new Vector3(0, 0.5f, 0);

            }
            else
            {
                _playerController.CharacterControllerOld.height = 1.5f;
                _playerController.CharacterControllerOld.center = new Vector3(0, 0.8f, 0);
            }

         
        }


    }

}
