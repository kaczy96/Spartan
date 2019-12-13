using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerEnemy : MonoBehaviour
{
    [SerializeField] public int dmg;
    private Player player;
    public Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    public bool hurting = false;
    private float attackTime = 0;
    private float attackCd = 1f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            sr.material = matWhite;
            Invoke("ResetMaterial", .1f);
        }
        if (other.CompareTag("Player"))
        {
            HurtThePlayer();
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hurting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hurting = false;
        }
    }

    public void HurtThePlayer()
    {
        Debug.Log("Enemy " + gameObject.name + " just attacked the player!");
        attackTime = attackCd;
        player.DamagePlayer(dmg);
    }

    private void Update()
    {

        if (hurting)
        {
            HurtThePlayer();
        }

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }
}
