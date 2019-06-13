using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
  [System.Serializable]
  public class PlayerStats
  {
      public float playerTimeBetweenHits = 0;
      public float attackCd = 2f;
      public float Health = 10f;
      public bool startCounting = false;
  }
  
  
 public PlayerStats playerStats = new PlayerStats();

 public int fallBoundary = -20;

 private void Update()
 {
     if (transform.position.y <= fallBoundary)
     {
         DamagePlayer(99999);
     }

     if (playerStats.startCounting)
     {
         if (playerStats.playerTimeBetweenHits > 0)
         {
             playerStats.playerTimeBetweenHits -= Time.deltaTime;
         }
         else
         {
             playerStats.startCounting = false;
         }
     }
 }

 public void DamagePlayer(int damage)
 {
     if (!playerStats.startCounting)
     {
         playerStats.startCounting = true;
         playerStats.playerTimeBetweenHits = playerStats.attackCd;
         playerStats.Health -= damage;
     }

     if (playerStats.Health <= 0)
     {
         Debug.Log("Kill player");
         GameMaster.KillPlayer(this);
     }
 }

}
