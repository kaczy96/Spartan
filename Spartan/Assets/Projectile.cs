using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject ProjectileExplosion;
    public GameObject ProjectileTrail;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        var position = player.position;
        target = new Vector2(position.x, position.y);
        
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        /*ProjectileTrail.transform.position = transform.position;
        Instantiate(ProjectileTrail, transform.position, transform.rotation);
        Spróbuj zrobić 1 instantiate, który leci za pociskiem juz do konca i spawnuje (bo jest zapętlony)
        Instantiate(ProjectileTrail, transform.position, transform.rotation);*/

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
            Instantiate(ProjectileExplosion, transform.position, transform.rotation);
            Debug.Log("boom");
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            DestroyProjectile();
        Instantiate(ProjectileExplosion, transform.position, transform.rotation);
        Debug.Log("boom");
    }*/

    private void DestroyProjectile()
    {
        Destroy(gameObject);
        
    }
}
