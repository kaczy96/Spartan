using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealthController : MonoBehaviour
{
    public GameObject DeathExplosion;
    private Player player;

    [SerializeField] public int enemyStartingHealth;
    [SerializeField] private int enemyCurrentHealth;

    void Start()
    {
        enemyCurrentHealth = enemyStartingHealth;
        player = FindObjectOfType<Player>();
    }

    public void damageDealtToEnemy(int damage)
    {
        enemyCurrentHealth -= damage;
        Debug.Log("Damage:" + damage);
    }

    private void Update()
    {
        enemyHealth();
    }

    private void enemyHealth()
    {
        if (enemyCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(DeathExplosion, transform.position, Quaternion.identity);
        }
        if (player.isActiveAndEnabled == false)
        {
            enemyCurrentHealth = enemyStartingHealth;
        }
    }
}
