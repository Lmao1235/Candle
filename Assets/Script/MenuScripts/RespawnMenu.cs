using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    public GameObject Canva;
    public int BTM;
    public void respawn()
    {
        Canva.SetActive(false);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(BTM, LoadSceneMode.Single);
    }

}

