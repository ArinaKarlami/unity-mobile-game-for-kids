using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMobilePlatform : MonoBehaviour
{
    [SerializeField] private GameObject mobileCanvas;

    private void Start()
    {
#if !UNITY_EDITOR
        mobileCanvas.SetActive(Application.isMobilePlatform);
#endif
    }
}
