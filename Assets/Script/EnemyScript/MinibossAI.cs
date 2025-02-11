using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinibossAI : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform BulletPos;
    private float timer;
    private Animator anim;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < 50)
        {
            timer += Time.deltaTime;

            if (timer > 2f)
            {
                timer = 0;
                shoot();
            }
        }

    }

    void shoot()
    {
        anim.SetTrigger("Attack");
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
    }
}
