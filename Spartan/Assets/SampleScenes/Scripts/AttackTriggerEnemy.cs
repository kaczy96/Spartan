using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerEnemy : MonoBehaviour
{
        [SerializeField ]public int dmg;
        public bool hurting = false;
        private float attackTime = 0;
        private float attackCd = 1f;
        private GameObject player;
        public Material matWhite;
        private Material matDefault;
        private SpriteRenderer sr;

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
            if(other.CompareTag("Player"))
            {
            Damage();
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
        
        

        public void Damage()
        {
                    Debug.Log("Enemy Attacking!");
                    attackTime = attackCd;
                    player.SendMessageUpwards("DamagePlayer", dmg);

            
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
