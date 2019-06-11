using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
  [System.Serializable]
  public class PlayerStats
  {
      public float Health = 5f;
  }
  
  
 public PlayerStats playerStats = new PlayerStats();

 public int fallBoundary = -20;

 private void Update()
 {
     if (transform.position.y <= fallBoundary)
     {
         DamagePlayer(99999);
     }
 }

 private void OnTriggerEnter2D(Collider2D other)
 {
     if (other.CompareTag("Enemy"))
     {
         
     }
 }

 public void DamagePlayer(int damage)
 {
     playerStats.Health -= damage;
     if (playerStats.Health <= 0)
     {
         Debug.Log("Kill player");
         GameMaster.KillPlayer(this);
     }
 }
 
}
