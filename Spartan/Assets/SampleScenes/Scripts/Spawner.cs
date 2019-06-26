using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject spawningObject;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public Transform target;
    void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && target != null)
            Spawn();
           
    }

    private void Spawn()
    {
        if (timeBetweenSpawn <= 0)
        {

            Instantiate(spawningObject, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;

        }
        else
        {

            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
