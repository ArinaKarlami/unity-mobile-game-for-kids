using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuModalView : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private void Start()
    {
#if !UNITY_EDITOR
        HideAll();
#endif
    }

    public void ShowID(int id)
    {
        Show(id);
    }

    public void HideAll()
    {
        ControlModal(-1);
    }

    private void Hide(int id)
    {
        ControlModal(id, false);
    }

    private void Show(int id)
    {
        ControlModal(id, true);
    }

    private void ControlModal(int id, bool status = false)
    {
        if (id < -1 || id >= objects.Length || objects.Length == 0) return;

        //Debug.Log($"Correct: {id}");

        for(int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(id == i);
        }
    }
}
