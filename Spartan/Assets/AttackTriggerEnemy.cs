using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerEnemy : MonoBehaviour
{
        [SerializeField ]public int dmg;
        private bool hurting = false;
        private float attackTime = 0;
        private float attackCd = 1f;
        public GameObject player;

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

        private void Damage()
        {
            Debug.Log("Enemy Attacking!");
            attackTime = attackCd;
            player.SendMessageUpwards("DamagePlayer",dmg);
        }
        
        private void Update()
        {

            if (hurting)
            {
                Damage();
            }

            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
        }
}
