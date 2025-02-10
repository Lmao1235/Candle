using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerHP : MonoBehaviour
{
    public int Health = 20;
    public TextMeshProUGUI HP;
    public GameObject death;
    public GameObject Player;
    Vector2 checkpointPos;
    public int BTM;

    public GameObject RespawnCanva;

    public void Start()
    {
        checkpointPos = transform.position;
    }
    public void Update()
    {
        
    }
    public void GotDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);
        HP.text = "HP: " + Health.ToString(); ;
        if (Health <= 0)
        {
            Death();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    public void Death()
    {
        gameObject.SetActive(false);
        RespawnCanva.SetActive(true);
        


    }

    public void Respawn()
    {
        transform.position = checkpointPos;
        gameObject.SetActive(true);
        Health = 10;
        HP.text = "HP: " + Health.ToString(); 
        RespawnCanva.SetActive (false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Heal")
        {
            Health = Health + 3;
            Destroy(other.gameObject);
            
            if (Health > 10)
            {
                Health = 10;
            }

            HP.text = "HP: " + Health.ToString(); ;

        }
    }

    public void BackToMenu()
    {
        RespawnCanva.SetActive(false);
        SceneManager.LoadScene(BTM, LoadSceneMode.Single);
    }
}
