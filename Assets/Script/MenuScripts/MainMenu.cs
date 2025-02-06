using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPanel;

    public GameObject OptionPanel;

    public void Start()
    {
        LevelPanel.SetActive(false);
        OptionPanel.SetActive(false);
    }
    public void PlayGame()
    {
        LevelPanel.SetActive(true);
    }

    public void Settings()
    {
        OptionPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}