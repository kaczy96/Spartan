using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using Random = UnityEngine.Random;

public class TitanController : MonoBehaviour {
    Player player;
    Animator animator;

    [SerializeField] Camera camera;
    [SerializeField] float cooldown;
    [SerializeField] GameObject eyes;
    [SerializeField] GameObject energyEffect;
    [SerializeField] GameObject energyEffectSlot;
    [SerializeField] UnityEngine.UI.Slider healthBarValue;
    [SerializeField] int currentHealth;
    SpriteRenderer spriteRenderer;
    public enum State {
        Idle,
        Attack
    }

    [SerializeField] State state = State.Idle;
    [SerializeField] List<BossAttackZone> attackZones = new List<BossAttackZone>();
    [SerializeField] BossAttackZone currentPlayerZone;
    [SerializeField] List<damagingVisualEffects> visualEffects = new List<damagingVisualEffects>();
    [SerializeField] int currentAttackZone;

    void Start() {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        healthBarValue.value = 50;
        currentHealth = 50;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update() {

        DisplayEyesEffects();
        BossHealth();

        switch (state) {
            case State.Idle:
                    if (IsPlayerInAttackRange() && IsReadyToAttack())   
                    ChangeStateToAttack();
                break;

            case State.Attack:
                if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
                {
                    state = State.Idle;
                }
                animator.SetInteger("attackNr", 0);
                break;
        }

        cooldown -= Time.deltaTime;
    }

    void BossHealth()
    {
        healthBarValue.value = currentHealth;
    }

    void visualEffectOnTakingHit()
    {
        spriteRenderer.color = Color.white;
    }

    public void TakeDamageFromPlayer(int damageTaken)
    {
        currentHealth -= damageTaken;
        spriteRenderer.color = Color.red;
        Invoke("visualEffectOnTakingHit", .1f);
        Debug.Log("Boss got hit for: " + damageTaken);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DealDamageToPlayer();
        }
    }

    public void DealDamageToPlayer()
    {
        player.DamagePlayer(2);
    }

    

    bool IsReadyToAttack() {
        return cooldown <= 0;    
    }

    void DisplayEyesEffects()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            eyes.gameObject.SetActive(false);
        }
        else eyes.gameObject.SetActive(true);
    }

    void ChangeStateToAttack() {
        state = State.Attack;
        animator.SetInteger("attackNr", currentPlayerZone.attackAnimationId);
        currentAttackZone = currentPlayerZone.attackAnimationId;
        cooldown = Random.Range(2,3);
    }

    bool IsPlayerInAttackRange() {
        ChooseAttackZone();
        return currentPlayerZone != null;
    }

    void ChooseAttackZone() {
        foreach (var zone in attackZones) {
            var center = new Vector2(zone.collider.transform.position.x + zone.collider.offset.x,
                zone.collider.transform.position.y + zone.collider.offset.y);
            if (Physics2D.OverlapBoxAll(center, zone.collider.size, 0).Any(col => col.gameObject.tag == "Player")) {
                currentPlayerZone = zone;
                return; 
            }
        }    
        currentPlayerZone = null;
    }

    void DisplayingDamagingEffectsBasedOnZone()
    {
        if (currentAttackZone == 1)
        {
            Instantiate(visualEffects[0]._effect, visualEffects[0]._collider.transform.position, visualEffects[0]._collider.transform.rotation);
            camera.GetComponent<ShakeBehavior>().ShakeIt();      
        }
        if (currentAttackZone == 2)
        {
            Instantiate(visualEffects[2]._effect, new Vector3(player.transform.position.x, visualEffects[2]._collider.transform.position.y), visualEffects[2]._effect.transform.rotation);
            camera.GetComponent<ShakeBehavior>().ShakeIt();
        }
        if (currentAttackZone == 3)
        {
            Instantiate(visualEffects[1]._effect, visualEffects[1]._collider.transform.position, visualEffects[1]._collider.transform.rotation);
            camera.GetComponent<ShakeBehavior>().ShakeIt();
        }
    }

    void DisplayGatheringEnergy()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Titan Attack 2 Animation"))
        {
            Instantiate(energyEffect, energyEffectSlot.transform.position, energyEffectSlot.transform.rotation);
        }
    }




}

[System.Serializable]
public class BossAttackZone {
    public int attackAnimationId;
    public BoxCollider2D collider;
}

[System.Serializable]
public class damagingVisualEffects{
    public ParticleSystem _effect;
    public Collider2D _collider;
}

