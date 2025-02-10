using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (goNextLevel)//เอาออกได้หากไม่ใช้
            {
                Debug.Log("Entered");
                UnlockNewLevel();
                SceneController.instance.NextLevel();
            }//เอาออกได้หากไม่ใช้
            else//เอาออกได้หากไม่ใช้
            {//เอาออกได้หากไม่ใช้
                SceneController.instance.LoadScene(levelName);//เอาออกได้หากไม่ใช้
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



