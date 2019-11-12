using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;
    public GameObject item;
    private GameObject spawnedItem;
    private Transform target;
    public float spawnerDistance;
        
    
        
        private void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            timeBetweenSpawns = startTimeBetweenSpawns;
            spawnedItem = GameObject.FindGameObjectWithTag("SpawnedItem");
        }
        void Spawn()
        {
            if (timeBetweenSpawns <= 0 )
            {
                GameObject spawnedItem = Instantiate(item, transform.position, Quaternion.identity);
                spawnedItem.tag = "SpawnedItem";
                timeBetweenSpawns = startTimeBetweenSpawns;
            }
    
            else
            {
                timeBetweenSpawns -= Time.deltaTime;
            }
        }
    
    
        private void Update()
        {
            if (Vector2.Distance(transform.position, target.position) < spawnerDistance && spawnedItem == null)
            {
                Debug.Log("Spawning");
                Spawn();
            }
    
        }
}
