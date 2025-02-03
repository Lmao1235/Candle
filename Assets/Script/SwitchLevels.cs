using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevels : MonoBehaviour //สำหรับกดเข้า Level
{
    public int Level1;
    public int Level2;
    public int Level3;

    public void Lvl1()
    {
        SceneManager.LoadScene(Level1, LoadSceneMode.Single);
    }
    public void Lvl2()
    {
        SceneManager.LoadScene(Level2, LoadSceneMode.Single);
    }
    public void Lvl3()
    {
        SceneManager.LoadScene(Level3, LoadSceneMode.Single);
    }

   
}
