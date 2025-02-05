using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool IsPaused;
    public int BTM;
    [SerializeField] GameObject settingMenu;
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
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
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void BackToMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(BTM, LoadSceneMode.Single);
        IsPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Setting()
    {
        settingMenu.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void Back()
    {
        settingMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
