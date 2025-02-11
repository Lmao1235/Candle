using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject Player;
    public Rigidbody2D rb;
    [SerializeField] private float force;
    
    void Start()
    {
        
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rota = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rota + 180);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D BulletHit)
    {
        PlayerHP player = BulletHit.GetComponent<PlayerHP>();
        if (player != null)
        {
            player.GotDamage(1);
            Destroy(gameObject);
        }
        else if (BulletHit.transform.tag == "PlayerAttack" || BulletHit.transform.tag == "Fireball")
        {
            Destroy(BulletHit.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
