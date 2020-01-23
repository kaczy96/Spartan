using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TitanController : MonoBehaviour {
    Player player;
    Animator animator;

    [SerializeField] float cooldown;

    public enum State {
        Idle,
        Attack
    }

    [SerializeField] State state = State.Idle;
    [SerializeField] List<BossAttackZone> attackZones = new List<BossAttackZone>();
    [SerializeField] BossAttackZone currentAttackZone;
    
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
            if (Physics2D.OverlapBoxAll(new Vector2(zone.collider.transform.position.x, zone.collider.transform.position.y), zone.collider.size, 0).Any(col => col.gameObject.tag == "Player")) {
                currentAttackZone = zone;
                return;
            }
        }
        
        currentAttackZone = null;
    }
}

[System.Serializable]
public class BossAttackZone {
    public int attackAnimationId;
    public BoxCollider2D collider;
}