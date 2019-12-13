using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public GameObject DeathExplosion;

    [SerializeField] public int startingHealth;
    private int currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage:" + damage);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(DeathExplosion, transform.position, Quaternion.identity);
        }
    }
}
