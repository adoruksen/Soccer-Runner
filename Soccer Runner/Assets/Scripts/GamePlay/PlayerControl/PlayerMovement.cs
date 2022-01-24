using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UIControl;

namespace CharacterControl
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Singleton Pattern
        public static PlayerMovement instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion
        
        [System.NonSerialized] public float playerSpeed = 10;
        [System.NonSerialized] public bool isLose;
        void Update()
        {
            MoveForward();
            MovementFunction();
        }

        void MoveForward()
        {
            if (LevelManager.gameState==GameState.Normal)
            {
                PlayerAnimController.instance.SetAnimState(AnimState.Run);
                float speed = GetSpeed();
                Vector3 pos = transform.localPosition;
                pos.z += speed * Time.deltaTime;
                transform.localPosition = pos;
            }
        }
        public void MovementFunction()
        {
            if (LevelManager.gameState==GameState.Normal)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && !isLose)
                {
                    DuringGame.instance.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                    playerSpeed = 15;
                    gameObject.transform.DOMoveX(-3, .5f);

                }

                else if (Input.GetKeyUp(KeyCode.Mouse0) && !isLose)
                {
                    playerSpeed = 10;
                    gameObject.transform.DOMoveX(0, .5f);
                }
            }
            
        }

        public float GetSpeed()
        {
            return playerSpeed;
        }
    }
}

