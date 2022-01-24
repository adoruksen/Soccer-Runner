using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UIControl 
{
    public class CompletePanel : MonoBehaviour
    {
        #region Singleton Pattern
        public static CompletePanel instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion

        [System.NonSerialized] public GameObject completePanel;

        void Start()
        {
            SetValues();
        }

        void SetValues()
        {
            completePanel = transform.GetChild(0).gameObject;
        }

        public void NextButtonFunc()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


    } 
}

