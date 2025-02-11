using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int ShieldDestroyed;
    private float timer;
    public GameObject Heart;
    [SerializeField] Transform HeartPos;
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

        if (projectile != null && projectile.FlamePoints >= ShieldDestroyed)
        {
            gameObject.SetActive(false);
            Instantiate(Heart, HeartPos.position, Quaternion.identity);
            Invoke("Respawn", 4);
        }
        timer += Time.deltaTime;
    }
    private void Respawn()
    {
        gameObject.SetActive(true);
    }
}
