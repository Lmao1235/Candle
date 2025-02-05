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
        Vector2 direction = (transform.right + transform.up * 0.3f).normalized; // Modify 0.2f for more/less upward angle
        rb.velocity = direction * speed;

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

    private void OnTriggerEnter2D(Collider2D Char1Hit)
    {
        EnemyScript enemy = Char1Hit.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            Instantiate(Boom, BoomPos.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Instantiate(Boom, BoomPos.position, Quaternion.identity);
        Destroy(gameObject);

    }



}
