using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIControl 
{
    public class StartPanel : MonoBehaviour
    {
        Text tapToPlay;
        GameObject button;
        void Start()
        {
            LevelManager.gameState = GameState.BeforeStart;
            SetValues();
        }

        void SetValues()
        {
            tapToPlay = transform.GetChild(0).GetChild(0).GetComponent<Text>();
            button = transform.GetChild(0).gameObject;
        }


        public void GameStarter()
        {
            LevelManager.gameState = GameState.Normal;
            button.SetActive(false);
            transform.parent.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }



    }
}

