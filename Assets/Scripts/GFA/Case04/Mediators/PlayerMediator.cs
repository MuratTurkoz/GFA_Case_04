using GFA.Case04.Input;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace GFA.Case04.Mediators
{
    public class PlayerMediator : MonoBehaviour, IPlayer
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerController _playerController;
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
        //private Plane _plane = new Plane(Vector3.up, Vector3.zero);

        private Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Debug.Log(_playerInput.GetMouseDelta().normalized);
            OnMove();
            OnJumped();
        }
        private void LateUpdate()
        {
            
            Onlook();
        }


        private void OnMove()
        {
            //Movement = _playerInput.GetPlayerMovement()* _playerInput.GetMouseDelta().normalized;
            _playerController.MoveHandle();
            _anim.SetFloat("MoveZ", _movement.normalized.magnitude);

        }
        private void OnJumped()
        {
            IsJumped = _playerInput.PlayerJumpedThisFrame();
            if (IsJumped == true)
            {
                _anim.SetBool("IsJump",true);

            }
            else
            {
                _anim.SetBool("IsJump", false);
            }

        }
        private void Onlook()
        {
            LookPosition=_playerInput.GetMouseDelta();
        }

    }

}
