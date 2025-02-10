using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject heart;
    [SerializeField] Transform HeartPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            Instantiate(heart, HeartPos.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
