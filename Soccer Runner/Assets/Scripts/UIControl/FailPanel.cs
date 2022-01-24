using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIControl
{
    public class FailPanel : MonoBehaviour
    {
        #region Singleton Pattern
        public static FailPanel instance;
        private void Awake()
        {
            instance = this;
        }

        #endregion

        public void TryAgainButton()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


