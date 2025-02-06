using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlayerHP gameController;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;
    Collider2D coll;

    

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Entered");
            gameController.UpdateCheckpoint(respawnPoint.position);
            spriteRenderer.sprite = active;
            coll.enabled = false;
        }
    }
}
