using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spikes : MonoBehaviour
{
    private Transform player;
    public int dmg;
    public bool hurting = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Damage();

        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hurting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hurting = false;
        }
    }

    private void Update()
    {

        if (hurting)
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
}

