using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamageSystem : MonoBehaviour
{
    [SerializeField] int particleDamage;
    Player player;

    void Start()
    {
        player.GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
       /* if (other.CompareTag("Player"))
        {
            Debug.Log("damage dealt");
           // player.DamagePlayer(2);
        }*/
    }

}
