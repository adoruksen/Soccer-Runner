using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int playerSpeed = 7;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    void Update()
    {
        MovementFunc();
    }

    void MovementFunc()
    {
        if (LevelManager.gameState==GameState.Normal || LevelManager.gameState==GameState.Finish)
        {
            animator.enabled = true;
            if (gameObject.CompareTag("enemy"))
            {
                Vector3 pos = transform.localPosition;
                pos.z -= playerSpeed * Time.deltaTime;
                transform.localPosition = pos;
            }
            else if (gameObject.CompareTag("Friend"))
            {
                Vector3 pos = transform.localPosition;
                pos.z += playerSpeed * Time.deltaTime;
                transform.localPosition = pos;
            }
            
        }
    }

}
