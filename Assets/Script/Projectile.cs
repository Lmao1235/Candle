using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    [SerializeField] private float force;
    private float timer;
    [SerializeField] GameObject Boom;
    [SerializeField] Transform BoomPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rota = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rota);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            Instantiate(Boom, BoomPos.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
