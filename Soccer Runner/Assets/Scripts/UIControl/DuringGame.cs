using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CharacterControl;

namespace UIControl 
{
    public class DuringGame : MonoBehaviour
    {
        #region Singleton Pattern
        public static DuringGame instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion

        Text levelText;
        Image barFill;
        Vector3 levelEndChunk;
        void Start()
        {
            SetValues();
        }

        void SetValues()
        {
            levelText = transform.GetChild(0).GetChild(1).GetComponent<Text>();
            barFill = transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();

            StartCoroutine(DistanceCalculator());
            
        }

        void Update()
        {
            if (LevelManager.gameState==GameState.Normal)
            {
                BarFillerFunc();
            }

        }

        void LevelTextSetter()
        {

        }
        public void BarFillerFunc()
        {
            float distance =  levelEndChunk.z - PlayerMovement.instance.transform.position.z ;
            float distanceFill = distance / levelEndChunk.z;

            barFill.fillAmount = 1 - distanceFill;

            if (distanceFill < 0)
            {
                distanceFill = 0;
            }
        }

        IEnumerator DistanceCalculator()
        {
            yield return new WaitForSeconds(.5f);
            int childIndex = SpawnManager.instance.transform.GetChild(0).childCount;
            levelEndChunk = SpawnManager.instance.transform.GetChild(0).GetChild(childIndex - 1).localPosition;
        }
    }
}

