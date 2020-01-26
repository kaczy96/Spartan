using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Random = UnityEngine.Random;

public class TitanController : MonoBehaviour {
    Player player;
    Animator animator;

    [SerializeField] Camera camera;
    [SerializeField] float cooldown;

    public enum State {
        Idle,
        Attack
    }

    [SerializeField] State state = State.Idle;
    [SerializeField] List<BossAttackZone> attackZones = new List<BossAttackZone>();
    [SerializeField] BossAttackZone currentAttackZone;
    [SerializeField] List<visualEffects> visualEffects = new List<visualEffects>();

    void Start() {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
    }


    void Update() {
        switch (state) {
            case State.Idle:
                if (IsPlayerInAttackRange() && IsReadyToAttack())
                    ChangeStateToAttack();
                break;
            case State.Attack:
                state = State.Idle;    
                animator.SetInteger("attackNr", 0);
                break;
        }

        cooldown -= Time.deltaTime;
    }

    bool IsReadyToAttack() {
        return cooldown <= 0;
    }

    void ChangeStateToAttack() {
        state = State.Attack;
        animator.SetInteger("attackNr", currentAttackZone.attackAnimationId);   
        cooldown = 4f;
    }

    bool IsPlayerInAttackRange() {
        ChooseAttackZone();
        return currentAttackZone != null;
    }

    void ChooseAttackZone() {
        foreach (var zone in attackZones) {
            var center = new Vector2(zone.collider.transform.position.x + zone.collider.offset.x,
                zone.collider.transform.position.y + zone.collider.offset.y);
            if (Physics2D.OverlapBoxAll(center, zone.collider.size, 0).Any(col => col.gameObject.tag == "Player")) {
                currentAttackZone = zone;
                return; 
            }
        }    
        currentAttackZone = null;
    }

    void DisplayingEffectsBasedOnZone()
    {
        if (currentAttackZone.attackAnimationId == 1)
        {
            Instantiate(visualEffects[0]._effect, visualEffects[0]._collider.transform.position, visualEffects[0]._collider.transform.rotation);
            camera.GetComponent<ShakeBehavior>().ShakeIt();
        }
        if (currentAttackZone.attackAnimationId == 2)
        {
            //StartCoroutine("WaitForPillarHit");
            Instantiate(visualEffects[2]._effect, new Vector3(player.transform.position.x, visualEffects[2]._collider.transform.position.y), visualEffects[2]._effect.transform.rotation);
        }
        if (currentAttackZone.attackAnimationId == 3)
        {
            Instantiate(visualEffects[1]._effect, visualEffects[1]._collider.transform.position, visualEffects[1]._collider.transform.rotation);
            camera.GetComponent<ShakeBehavior>().ShakeIt();
        }

    }

    public IEnumerator WaitForPillarHit()
    {
        yield return new WaitForSeconds(2f);
    }
}

[System.Serializable]
public class BossAttackZone {
    public int attackAnimationId;
    public BoxCollider2D collider;
}

[System.Serializable]
public class visualEffects{
    public ParticleSystem _effect;
    public Collider2D _collider;
}