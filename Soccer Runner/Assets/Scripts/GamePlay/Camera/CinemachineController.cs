using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CinemachineController : MonoBehaviour
{
    #region Singleton Pattern
    public static CinemachineController instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion


    CinemachineVirtualCamera vCam;
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void FovAdder(int plus)
    {
        DOTween.To(()=> vCam.m_Lens.FieldOfView, x => vCam.m_Lens.FieldOfView = x, vCam.m_Lens.FieldOfView + plus, 1.5f);
    }
}
