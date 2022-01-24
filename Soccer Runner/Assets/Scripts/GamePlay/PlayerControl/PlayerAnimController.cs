using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CharacterControl 
{
    public class PlayerAnimController : MonoBehaviour
    {
        #region Singleton Pattern
        public static PlayerAnimController instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion


        [NonSerialized] public Animator animator;
        [NonSerialized] public AnimState curState;


        private void Start()
        {
            animator = transform.GetComponent<Animator>();
        }
        public void SetAnimState(AnimState state, int layer = 0)
        {
            string animName = Enum.GetName(typeof(AnimState), state);
            curState = state;

            if (animator != null)
            {
                animator.Play(animName, layer);
            }
        }
    }
}



