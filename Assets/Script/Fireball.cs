using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody2D rb;
    private bool isFollowing = false;
    private bool hasLaunched = false;

    public float launchSpeed = 10f; 
    public float followSpeed = 10f; 

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

        
        if (Input.GetMouseButton(1) && hasLaunched)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
    

}
