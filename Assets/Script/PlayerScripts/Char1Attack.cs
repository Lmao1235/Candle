using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1Attack : MonoBehaviour
{
    public float speed = 20f;
    public float angle = 45f;
    public Rigidbody2D rb;
    void Start()
    {
        
        rb.velocity = transform.right * speed;
        transform.rotation = Quaternion.Euler( angle, 0 ,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Char1Hit)
    {
        EnemyScript enemy = Char1Hit.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
        Destroy(gameObject);
    }
}
