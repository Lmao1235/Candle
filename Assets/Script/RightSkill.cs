using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSkill : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject BulletPrefab;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(BulletPrefab, Firepoint.position, Firepoint.rotation);
    }
}
