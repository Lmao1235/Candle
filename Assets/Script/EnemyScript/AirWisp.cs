using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWisp : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public float DB;
    

    private float distance;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);


        if (distance < DB)
        {
            Vector2 direction = Player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;

            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHP player = collision.GetComponent<PlayerHP>();
            if (player != null)
            {
                player.GotDamage(1);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
