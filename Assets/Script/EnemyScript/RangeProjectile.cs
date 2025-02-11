using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public GameObject Player;

    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        Vector3 direction = Player.transform.position - transform.position;
        

        float rota = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rota);
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifeTime = 0;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
    }

    private void Update()
    {
        if (hit)
        {
            return;
        }

        

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);//Execute logic from parent script first
        boxCollider.enabled = false;

        if (anim != null)
        {
            anim.SetTrigger("explode");//When the Object is a fireball explode it
        }
        else
        {
            gameObject.SetActive(false);//when this hits any object deactivate arrow
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
