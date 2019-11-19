using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] public int startingHealth;
    private int currentHealth;
    public GameObject DeathExplosion;

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
