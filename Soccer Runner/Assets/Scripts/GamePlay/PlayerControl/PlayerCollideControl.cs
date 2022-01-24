using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIControl;
using System;

namespace CharacterControl 
{
    public class PlayerCollideControl : MonoBehaviour
    {

        void Start()
        {
            RigidbodyActivator(true);
            ColliderActivator(false);
        }

        void RigidbodyActivator(bool rbStatus)
        {
            Rigidbody[] rb = transform.parent.transform.GetChild(1).GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody item in rb)
            {
                item.isKinematic = rbStatus;
            }
        }

        void ColliderActivator(bool colStatus)
        {
            Collider[] cl = transform.parent.transform.GetChild(1).GetComponentsInChildren<Collider>();
            foreach (Collider item in cl)
            {
                item.enabled = colStatus;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("enemy"))
            {
                StartCoroutine(EnemyCollision());
            }
            if (other.CompareTag("LevelEnd"))
            {
                LevelCompleteFunc();
            }
            if (other.CompareTag("Friend"))
            {
                PlayerMovement.instance.playerSpeed = 7;
            }

        }


        IEnumerator EnemyCollision()
        {
            ColliderActivator(true);
            RigidbodyActivator(false);
            Debug.Log("carpısma oldu");

            LevelManager.gameState = GameState.Finish;
            PlayerMovement.instance.isLose = true;
            PlayerMovement.instance.playerSpeed = 0;
            PlayerAnimController.instance.animator.enabled = false;

            DuringGame.instance.transform.GetChild(0).gameObject.SetActive(false);


            yield return new WaitForSeconds(.5f);

            FailPanel.instance.transform.GetChild(0).gameObject.SetActive(true);

        }


        void LevelCompleteFunc()
        {
            LevelManager.gameState = GameState.Finish;

            DuringGame.instance.transform.GetChild(0).gameObject.SetActive(false);
            CompletePanel.instance.completePanel.SetActive(true);

            PlayerMovement.instance.playerSpeed = 0;

            int a = UnityEngine.Random.Range(0, 2);
            string[] winAnims = new string[3];
            winAnims[0] = "Win1";
            winAnims[1] = "Win2";
            winAnims[2] = "Win3";
            PlayerAnimController.instance.animator.Play(winAnims[a]);
        }





    }
}

