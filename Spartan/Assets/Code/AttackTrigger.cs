using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player's weapon
 */
public class AttackTrigger : MonoBehaviour
{
    [SerializeField] public int dmg;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Player just attacked the enemy!");
            var enemiesDamageController = other.GetComponent<DamageController>();
            enemiesDamageController.Damage(dmg);
        }

        if (other.CompareTag("Boss"))
        {
            //Debug.Log("Player just hit the boss!");
            var bossDamageController = other.GetComponent<TitanController>();
            bossDamageController.TakeDamageFromPlayer(dmg);
        }
    }
}
