using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float timer;
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1)
        {
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D BoomHit)
    {
        EnemyScript enemy = BoomHit.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(5);
        }

    }
}
