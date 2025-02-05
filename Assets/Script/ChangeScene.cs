using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private int Menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D Scene)
    {
        if (Scene.CompareTag("Player"))
        {
            SceneManager.LoadScene(Menu, LoadSceneMode.Single);
        }
        
    }
}
