using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIControl;
using DG.Tweening;


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
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable!=null)
            {
                if (interactable.type == InteractableType.Enemy)
                {
                    StartCoroutine(EnemyCollision());
                }
                if (interactable.type == InteractableType.EndChunk)
                {
                    Vector3 pos = new Vector3(other.transform.position.x-1, other.transform.position.y, other.transform.position.z);
                    LevelCompleteFunc(pos);
                }
                if (interactable.type == InteractableType.Friend)
                {
                    PlayerMovement.instance.playerSpeed = 7;
                }
            }
            
        }


        IEnumerator EnemyCollision()
        {
            ColliderActivator(true);
            RigidbodyActivator(false);

            LevelManager.gameState = GameState.Finish;
            PlayerMovement.instance.isLose = true;
            PlayerMovement.instance.playerSpeed = 0;
            PlayerAnimController.instance.animator.enabled = false;

            DuringGame.instance.transform.GetChild(0).gameObject.SetActive(false);


            yield return new WaitForSeconds(.5f);

            FailPanel.instance.transform.GetChild(0).gameObject.SetActive(true);

        }


        void LevelCompleteFunc(Vector3 center)
        {
            LevelManager.gameState = GameState.Finish;

            DuringGame.instance.transform.GetChild(0).gameObject.SetActive(false);
            CompletePanel.instance.completePanel.SetActive(true);

            CinemachineController.instance.FovAdder(30);
            PlayerMovement.instance.transform.DOMove(center, .5f);
            PlayerMovement.instance.playerSpeed = 0;

            string[] winAnims = new string[3];
            winAnims[0] = "Win1";
            winAnims[1] = "Win2";
            winAnims[2] = "Win3";
            PlayerAnimController.instance.animator.Play(winAnims[Random.Range(0,2)]);
        }
    }
}

