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
        [SerializeField] private Animator _anim;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private GameObject targetObject;
        //[SerializeField] private Rigidbody _rigidbody;

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


        private float _rotationSpeed = 0.01f;
        //private Plane _plane = new Plane(Vector3.up, Vector3.zero);

        //        [Header("Player")]
        //        [Tooltip("Move speed of the character in m/s")]
        //        public float MoveSpeed = 4.0f;
        //        [Tooltip("Sprint speed of the character in m/s")]
        //        public float SprintSpeed = 6.0f;
        [Tooltip("Rotation speed of the character")]
        public float RotationSpeed = 1.0f;
        //        [Tooltip("Acceleration and deceleration")]
        //        public float SpeedChangeRate = 10.0f;

        //        [Space(10)]
        //        [Tooltip("The height the player can jump")]
        //        public float JumpHeight = 1.2f;
        //        [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        //        public float Gravity = -15.0f;

        //        [Space(10)]
        //        [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
        //        public float JumpTimeout = 0.1f;
        //        [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
        //        public float FallTimeout = 0.15f;

        //        [Header("Player Grounded")]
        //        [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        //        public bool Grounded = true;
        //        [Tooltip("Useful for rough ground")]
        //        public float GroundedOffset = -0.14f;
        //        [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        //        public float GroundedRadius = 0.5f;
        //        [Tooltip("What layers the character uses as ground")]
        //        public LayerMask GroundLayers;

        [Header("Cinemachine")]
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
        public GameObject CinemachineCameraTarget;
        [Tooltip("How far in degrees can you move the camera up")]
        public float TopClamp = 90.0f;
        [Tooltip("How far in degrees can you move the camera down")]
        public float BottomClamp = -90.0f;

        //        // cinemachine
        private float _cinemachineTargetPitch;

        // player
        private float _speed;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;

        // timeout deltatime
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;


        ////#if ENABLE_INPUT_SYSTEM
        ////        private PlayerInput _playerInput;
        ////#endif
        //       [SerializeField] private CharacterController _controller;
        //        //private StarterAssetsInputs _input;
        private Camera _mainCamera;

        private const float _threshold = 0.01f;

        private void Awake()
        {
            //_mainCamera = Camera.main;
            //_anim = GetComponent<Animator>();
        }

        private void Update()
        {
            //OnMove();
            //OnJumped();
            //OnRun();
            //OnRotation();
            //JumpAndGravity();
        }
        private void FixedUpdate()
        {
            Onlook();
       
        }

        private void LateUpdate()
        {
            //CameraRotation();
            //OnRotation();
        }


        private void OnMove()
        {
            //Movement = _playerInput.GetPlayerMovement();
            ////_playerController.MoveHandle();
            //_anim.SetFloat("MoveZ", _movement.normalized.magnitude);

        }
        private void OnJumped()
        {
            //IsJumped = _playerInput.PlayerJumpedThisFrame();

        }
        private void OnRun()
        {
            //IsRun = _playerInput.GetPlayerRun();
        }
        private void Onlook()
        {
            //LookPosition = Vector2.zero;
            //LookPosition = _playerInput.GetMouseDelta();
           
        }
            

    }

}
