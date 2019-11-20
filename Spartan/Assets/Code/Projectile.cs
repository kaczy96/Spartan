using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform player;
    public GameObject projectileExplosion;
    private Vector2 target;
    
    public float speed;
    public int dmg;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        var position = player.position;
        target = new Vector2(position.x, position.y);
    }

    private void Update()
    {
        ShootProjectile();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damage();
        }    
    }

    public void Damage()
    {
        Debug.Log("Enemy Attacking!");
        //attackTime = attackCd;
        player.SendMessageUpwards("DamagePlayer", dmg);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);  
    }

    private void ShootProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
            Instantiate(projectileExplosion, transform.position, transform.rotation);
        }
    }
}
