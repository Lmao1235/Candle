using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera MainCam;
    private Vector3 mPos;
    [SerializeField] GameObject pb;
    [SerializeField] Transform bullettransform;
    [SerializeField] private bool CanFire;
    private float timer;
    [SerializeField] private float TimeBetweenFiring;


    // Start is called before the first frame update
    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mPos = MainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mPos - transform.position;

        float rotaze = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotaze);

        if (!CanFire)
        {
            timer += Time.deltaTime;
            if (timer > TimeBetweenFiring)
            {
                CanFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButtonDown(0) && CanFire)
        {
            CanFire = false;
            Instantiate(pb, bullettransform.position, Quaternion.identity);
        }
    }
}
