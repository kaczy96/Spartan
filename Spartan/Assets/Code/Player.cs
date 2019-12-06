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
      public Image firstHp;
      public Image secondHp;
      public Image thirdHp;
      public Image forthHp;
      public Image fifthHp;
      public Image damageScreen;
      public GameObject playerDeathEffect;
      public bool damaged = false;
      public Color damageColour = new Color(0f,0f,0f, 0.5f);
      public float smoothColour = 5f;

     
    }

 public PlayerStats playerStats = new PlayerStats();
 public int fallBoundary = -20;
    public Material matBlinking;
    private Material matDefault;
    private SpriteRenderer sr;

    private void Start()
 {
     playerStats.health = playerStats.startingHealth;
     playerStats.livesText.text = "Lives x " + playerStats.health;
        sr = GetComponent<SpriteRenderer>();
        matDefault = sr.material;
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
                sr.material = matBlinking;
                Invoke("ResetMaterial", .1f);
                playerStats.playerTimeBetweenHits -= Time.deltaTime;
         }
         else
         {
             playerStats.startCounting = false;
         }
     }
     playerStats.livesText.text = "Lives x " + playerStats.health;

     UpdateHpMeter();

     if (playerStats.damaged)
     {
            playerStats.damageScreen.color = playerStats.damageColour;   
     }
     else
     {
         playerStats.damageScreen.color = Color.Lerp(playerStats.damageScreen.color, Color.clear,
             playerStats.smoothColour * Time.deltaTime);
     }

     playerStats.damaged = false;
 }

 public void DamagePlayer(int damage)
 {
     if (!playerStats.startCounting)
     {
         playerStats.startCounting = true;
         playerStats.playerTimeBetweenHits = playerStats.attackCd;
         playerStats.damaged = true;
         playerStats.health -= damage;
        }

     if (playerStats.health <= 0)
     {
         UpdateHpMeter();
         Debug.Log("Kill player");
         
         GameMaster.KillPlayer(this);
         Instantiate(playerStats.playerDeathEffect, transform.position, transform.rotation);
        }
 }

 public void UpdateHpMeter()
 {
        switch ((int) playerStats.health)
     {
         case 5:
         {
             playerStats.firstHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1;
             playerStats.thirdHp.fillAmount = 1;
             playerStats.forthHp.fillAmount = 1;
             playerStats.fifthHp.fillAmount = 1;
             return;
         }
         case 4:
         {
             playerStats.firstHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1;
             playerStats.thirdHp.fillAmount = 1;
             playerStats.forthHp.fillAmount = 1;
             playerStats.fifthHp.fillAmount = 0;
             return;
         }
         case 3:
         {
             playerStats.firstHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1;
             playerStats.thirdHp.fillAmount = 1;
             playerStats.forthHp.fillAmount = 0;
             playerStats.fifthHp.fillAmount = 0;
             return;
         }
         case 2:
         {
             playerStats.firstHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 1;
             playerStats.thirdHp.fillAmount = 0;
             playerStats.forthHp.fillAmount = 0;
             playerStats.fifthHp.fillAmount = 0;
             return;
         }
         case 1:
         {
             playerStats.firstHp.fillAmount = 1;
             playerStats.secondHp.fillAmount = 0;
             playerStats.thirdHp.fillAmount = 0;
             playerStats.forthHp.fillAmount = 0;
             playerStats.fifthHp.fillAmount = 0;
             return;
         }
         case 0:
         {
             playerStats.firstHp.fillAmount = 0;
             playerStats.secondHp.fillAmount = 0;
             playerStats.thirdHp.fillAmount = 0;
             playerStats.forthHp.fillAmount = 0;
             playerStats.fifthHp.fillAmount = 0;
             return;
         }

         default:
         {
             playerStats.firstHp.fillAmount = 0;
             playerStats.secondHp.fillAmount = 0;
             playerStats.thirdHp.fillAmount = 0;
             playerStats.forthHp.fillAmount = 0;
             playerStats.fifthHp.fillAmount = 0;
             return;
         }
        }
 }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }

}
