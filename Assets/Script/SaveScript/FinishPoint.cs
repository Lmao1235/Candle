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
            if (goNextLevel)//����͡���ҡ�����
            {//����͡���ҡ�����
                UnlockNewLevel();
                SceneManager.LoadScene(LevelNum, LoadSceneMode.Single);//����͡���ҡ�����
            }//����͡���ҡ�����
            else//����͡���ҡ�����
            {//����͡���ҡ�����
                SceneManager.LoadScene(LevelNum, LoadSceneMode.Single);//����͡���ҡ�����
            }//����͡���ҡ�����
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



