using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletPos1;
    [SerializeField] Transform BulletPos2;
    [SerializeField] Transform BulletPos3;
    [SerializeField] Transform BulletPos4;
    private float timer;
    private Animator anim;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        timer = 8;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < 100)
        {
            timer += Time.deltaTime;

            if (timer > 10f)
            {
                timer = 0;
                shoot();
            }
        }

    }

    void shoot()
    {
        anim.SetTrigger("Attack");
        Instantiate(Bullet, BulletPos1.position, Quaternion.identity);
        Instantiate(Bullet, BulletPos2.position, Quaternion.identity);
        Instantiate(Bullet, BulletPos3.position, Quaternion.identity);
        Instantiate(Bullet, BulletPos4.position, Quaternion.identity);
    }
}
