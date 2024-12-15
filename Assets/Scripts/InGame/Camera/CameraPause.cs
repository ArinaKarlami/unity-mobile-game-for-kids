using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPause : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool pause;

    private void Start()
    {
#if !UNITY_EDITOR
        Time.timeScale = 1;
        pause = false;
#endif
    }

#if UNITY_STANDALONE || UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
#endif

    public void Pause()
    {
        pause = !pause;
        menu.SetActive(pause);
        Time.timeScale = pause ? 0f : 1f;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        pause = false;

        SceneManager.LoadScene("MenuScene");
    }

    public void Quit()
    {
        Time.timeScale = 1;
        pause = false;

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
