using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause;
    public static bool IsPaused;
    public int BTM;
    void Start()
    {
        Pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Pause.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame() 
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void BackToMenu()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(BTM, LoadSceneMode.Single);
        IsPaused = false;
    }

}
