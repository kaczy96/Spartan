using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    private float attackTime = 0;
    private float attackCd = 0.3f;

    public Collider2D attackTrigger;
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("f") && !attacking)
        {
            Debug.Log("Pressing attack button");
            attacking = true;
            attackTime = attackCd;
            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if (attackTime > 0)
            {
                attackTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
                
        }

        anim.SetBool("Attacking", attacking);
    }
}

