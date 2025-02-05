using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int Health = 10;
    public TextMeshProUGUI HP;
    public GameObject death;

    public void GotDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);
        HP.text = Health.ToString(); ;
        if (Health <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
