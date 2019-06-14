using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject projectileExplosion;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        var position = player.position;
        target = new Vector2(position.x, position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
            Instantiate(projectileExplosion, transform.position, transform.rotation);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            DestroyProjectile();
    }*/

    private void DestroyProjectile()
    {
        Destroy(gameObject);
        
    }
}
