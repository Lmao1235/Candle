using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] int LevelNum;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entered");
            Debug.Log("Entered");
            if (goNextLevel)//เอาออกได้หากไม่ใช้
            {//เอาออกได้หากไม่ใช้
                UnlockNewLevel();
                SceneManager.LoadScene(LevelNum, LoadSceneMode.Single);//เอาออกได้หากไม่ใช้
            }//เอาออกได้หากไม่ใช้
            else//เอาออกได้หากไม่ใช้
            {//เอาออกได้หากไม่ใช้
                SceneManager.LoadScene(LevelNum, LoadSceneMode.Single);//เอาออกได้หากไม่ใช้
            }//เอาออกได้หากไม่ใช้
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex > -PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}



