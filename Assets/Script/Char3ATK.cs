using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char3ATK : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    private float timer;
    [SerializeField] GameObject Boom;
    [SerializeField] Transform BoomPos;
    void Start()
    {
        rb.velocity = transform.right * speed;
        rb.rotation = 45;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1f)
        {
            Instantiate(Boom, BoomPos.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    

}
