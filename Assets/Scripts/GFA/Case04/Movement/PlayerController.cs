using GFA.Case04.Mediators;
using GFA.Case04.Movement;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace GFA.Case04.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private PlayerMediator _playerMediator;
        private CharacterController _characterController;
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
        public void MoveHandle()
        {
            _characterController.Move((_playerMediator.Movement + new Vector3(0, _playerMediator.JumpForce, 0)) * _playerMediator.Velocity * Time.deltaTime);
        }
    }
}


