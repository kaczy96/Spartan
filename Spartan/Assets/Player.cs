using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
  [System.Serializable]
  public class PlayerStats
  {
      public float playerTimeBetweenHits = 0;
      public float attackCd = 2f;
      public float startingHealth = 5f;
      public float health = 0;
      public bool startCounting = false;
      public Text livesText;
      public Image firestHp;
      public Image secondHp;
      public Image thirdHp;
  }
  
  
 public PlayerStats playerStats = new PlayerStats();

 public int fallBoundary = -20;

 private void Start()
 {
     playerStats.health = playerStats.startingHealth;
     playerStats.livesText.text = "Lives x " + playerStats.health;
 }

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
     playerStats.livesText.text = "Lives x " + playerStats.health;

     UpdateHpMeter();
 }

 public void DamagePlayer(int damage)
 {
     if (!playerStats.startCounting)
     {
         playerStats.startCounting = true;
         playerStats.playerTimeBetweenHits = playerStats.attackCd;
         playerStats.health -= damage;
     }

     if (playerStats.health <= 0)
     {
         Debug.Log("Kill player");
         GameMaster.KillPlayer(this);
     }
 }

 public void UpdateHpMeter()
 {
     switch ((int) playerStats.health)
     {
         case 5:
         {
             playerStats.firestHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1;
             playerStats.thirdHp.fillAmount = 1;
             break;
         }
         case 4:
         {
             playerStats.firestHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1;
             playerStats.thirdHp.fillAmount = 0.5f;
             break;
         }
         case 3:
         {
             playerStats.firestHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1f;
             playerStats.thirdHp.fillAmount = 0;
             break;
         }
         case 2:
         {
             playerStats.firestHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 0.5f;
             playerStats.thirdHp.fillAmount = 0;
             break;
         }
         case 1:
         {
             playerStats.firestHp.fillAmount = 1f;
             playerStats.secondHp.fillAmount = 0;
             playerStats.thirdHp.fillAmount = 0;
             break;
         }
         case 0:
         {
             playerStats.firestHp.fillAmount = 0f;
             playerStats.secondHp.fillAmount = 0;
             playerStats.thirdHp.fillAmount = 0;
             break;
         }
     }

 }
 
}
