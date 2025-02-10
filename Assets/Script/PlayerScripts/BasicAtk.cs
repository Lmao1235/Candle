using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAtk : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject BulletPrefab;
    private Animator anim;
    
    public float Cooldown;
    private float timer;

    private void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Cooldown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                
                timer = 0;
            }
            
        }
       
        
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
        
    }
}
