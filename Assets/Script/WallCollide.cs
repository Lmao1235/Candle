using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollide : MonoBehaviour
{
    public int WallDestroy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D wall)
    {
        Fireball projectile = wall.gameObject.GetComponent<Fireball>();

        if (projectile != null && projectile.FlamePoints >= WallDestroy)
        {
            Destroy(gameObject);
        }
    }
}
