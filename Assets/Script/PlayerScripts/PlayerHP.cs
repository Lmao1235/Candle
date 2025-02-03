using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int Health = 10;

    public GameObject death;

    public void GotDamage(int damage)
    {
        Health -= damage;
        Debug.Log(Health);

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
