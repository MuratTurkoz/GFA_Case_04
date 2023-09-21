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
        [SerializeField] private Rigidbody _rigidbody;
        public float Velocity { get { return _velocity; } set { _velocity = value; } }
        private float _velocity = 5f;

        private Vector3 _movement;
        public Vector3 Movement { get { return _movement; } set { _movement = value; } }

        private bool _isJumped;
        public bool IsJumped { get { return _isJumped; } set { _isJumped = value; } }

        private bool _isRolled;
        public bool IsRolled { get { return _isRolled; } set { _isRolled = value; } }

        private float _jumpForce=5;
        public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }
        public MoveBehaviour Behaviour { get => _behaviour; set => _behaviour = value; }
        private MoveBehaviour _behaviour;
        public PlayerController PlayerController { get => _playerController; set => _playerController = value; }
        private void Awake()
        {
            _rigidbody.isKinematic=true;
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            OnMove();
            OnJumped();
            Debug.Log(Behaviour);
        }

        private void OnMove()
        {

            switch (Behaviour)
            {
                case MoveBehaviour.Idle:
                    //Velocity = 0;
                    _anim.SetBool("IsRun", false);
                    break;
                case MoveBehaviour.Run:
                    _playerController.MoveHandle();
                    _anim.SetBool("IsRun", true);
                    break;
                case MoveBehaviour.Roll:
                    break;
                case MoveBehaviour.Jump:
                    //_anim.SetBool("IsJump", true);
                    break;
                default:
                    break;
            }
        }
        private void OnJumped()
        {
            Debug.DrawRay(transform.position, Vector3.down,Color.red,2f);
           
            bool result = Physics.Raycast(transform.position, Vector3.down, 2f);
            Debug.Log(result);
            if (result)
            {
                _isJumped = false;
               
            }
            else
            {
                JumpForce = 0;
            }
            //Debug.Log(_isJumped);
            //if (_isJumped)
            //{
            //    _behaviour = MoveBehaviour.Jump;
            //    _anim.SetBool("IsJump", true);
            //}
            //_isJumped = false;
            //_anim.SetBool("IsJump", false);
        }

    }

}
