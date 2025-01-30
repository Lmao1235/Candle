using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;
    private bool isFollowing = false;
    private bool hasLaunched = false;
    private bool canFollow = true;

    public float launchSpeed = 10f; 
    public float followSpeed = 10f;

    public int FlamePoints = 1;

    void Start()
    {
        
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (Input.GetMouseButton(1) && !hasLaunched)
        {
            ShootProjectile();
        }

        
        if (Input.GetMouseButton(1) && hasLaunched && canFollow)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            isFollowing = false;
            canFollow = false;
        }
    }

    void FixedUpdate()
    {
        if (isFollowing)
        {
            FollowMouse();
        }
    }

    void ShootProjectile()
    {
        hasLaunched = true;

        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;

        
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;

        
        Vector2 shootDirection = (worldPosition - transform.position).normalized;

        
        rb.velocity = shootDirection * launchSpeed;

        Debug.Log("Projectile launched with velocity: " + rb.velocity);
    }

    void FollowMouse()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;

        
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;

        
        Vector2 direction = (worldPosition - transform.position).normalized;
        rb.velocity = direction * followSpeed;
    }

    public void OnTriggerEnter2D(Collider2D FireballHit)
    {
        if (FireballHit.transform.tag == "Fuel")
        {
            FlamePoints = 1 + FlamePoints;
            Debug.Log(FlamePoints);
        }
        else if (FireballHit.transform.tag == "Enemy")
        {
            EnemyScript enemy = FireballHit.GetComponent<EnemyScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(FlamePoints);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

}
