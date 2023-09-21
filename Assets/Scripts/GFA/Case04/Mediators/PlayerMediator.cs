using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.Case04.Mediators
{
    public class PlayerMediator : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private PlayerController _playerController;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            OnMove();
        }

        private void OnMove()
        {
            if (_playerController.Movement == Vector3.zero)
            {
                _anim.SetBool("IsRun", false);
                _playerController.Velocity = 0;
            }
            else
            {
                _anim.SetBool("IsRun", true);
                _playerInput.OnMove();
            }
            //_playerInput.OnMove();  
        }
    }

}
