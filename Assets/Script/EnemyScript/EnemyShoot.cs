using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletPos;
    private float timer;

    private GameObject Player;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        float distance = Vector2.Distance(transform.position, Player.transform.position);
        

        if (distance < 50)
        {
            timer += Time.deltaTime;

            if (timer > 3f)
            {
                timer = 0;
                shoot();
            }
        }

        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);


    }

    void shoot()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
    }

    


}
