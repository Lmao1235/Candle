using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerHP : MonoBehaviour
{
    public int Health = 20;
    public TextMeshProUGUI HP;
    public GameObject death;
    public GameObject Player;

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
    void Death()
    {
        Player.SetActive(false);
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
}
