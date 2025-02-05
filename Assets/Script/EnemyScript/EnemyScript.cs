using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int EnemyHealth = 10;

    public GameObject death;

    public void TakeDamage (int damage)
    {
        EnemyHealth -= damage;

        if (EnemyHealth <= 0)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
    }
}
