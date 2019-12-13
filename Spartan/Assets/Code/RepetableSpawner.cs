using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepetableSpawner : MonoBehaviour
{
    public GameObject item;

    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    private void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    void Spawn()
    {
        if (timeBetweenSpawns <= 0)
        {
            Instantiate(item, transform.position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }

        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }

    private void Update()
    {
        Spawn();
    }
}
