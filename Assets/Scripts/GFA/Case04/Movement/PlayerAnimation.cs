using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GFA.Case04.Movement
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

    }

}