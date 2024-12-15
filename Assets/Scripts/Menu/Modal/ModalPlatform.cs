using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalPlatform : MonoBehaviour
{
    [SerializeField] private GameObject modal;
    [SerializeField] private GameObject buttonExit;
    [SerializeField] private RectTransform content;

    private void Awake()
    {
        if(Application.isMobilePlatform == false)
        {
            buttonExit.SetActive(false);
            content.offsetMin = new Vector2(25, content.offsetMin.y);
        }
    }

#if UNITY_STANDALONE || UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            modal.SetActive(false);
        }
    }
#endif
}
