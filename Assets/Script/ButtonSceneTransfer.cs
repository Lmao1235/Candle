using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTransfer : MonoBehaviour
{
    public int StartG;
    public int AboutG;
    public void Startgame()
    {
        SceneManager.LoadScene(StartG, LoadSceneMode.Single);
    }

    public void Aboutgame()
    {
        SceneManager.LoadScene(AboutG, LoadSceneMode.Single);
    }
}
