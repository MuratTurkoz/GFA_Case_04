using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GFA.Case04.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        public float Velocity { get { return _velocity; } set { _velocity = value; } }
        private float _velocity = 5f;
        private Vector3 _movement;
        public Vector3 Movement { get { return _movement; } set { _movement = value; } }
        private bool _isJumped;
        public bool IsJumped
        {
            get { return _isJumped; }
            set { _isJumped = value; }
        }
        private bool _isRolled;
        public bool IsRolled => _isRolled;
        private CharacterController _characterController;

        //private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {

                _characterController.SimpleMove(_movement * _velocity);
            
        }
    }
}


