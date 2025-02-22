using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char2ATK : MonoBehaviour
{
    public float speed = 25f;
    public Rigidbody2D rb;
    private float timer;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D Char2Hit)
    {
        EnemyScript enemy = Char2Hit.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(2);
            Destroy(gameObject);
        }
        
    }



}
