using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawningObject;
    public Transform target;
    private Animator SpawnerAnimator;

    private bool isSpawning;
    public float rangeOfSpawner;
    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
 
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SpawnerAnimator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        Spawn();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangeOfSpawner);
    }

    private void Spawn()
    {
        if (timeBetweenSpawn <= 0 && Vector2.Distance(transform.position, target.position) <= rangeOfSpawner)
        {
            Instantiate(spawningObject, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            SpawnerAnimator.SetTrigger("Spawning");
        }
        else
        {    
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
