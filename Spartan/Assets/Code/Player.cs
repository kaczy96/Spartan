using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public HealthVisualisation healthVisualisation;
        public Image damageScreen;
        public GameObject playerDeathEffect;
        public Color damageColour = new Color(0f, 0f, 0f, 0.5f);

        public float playerTimeBetweenHits = 0;
        public float attackCd = 2f;
        public float startingHealth = 5f;
        public float health = 0;
        public bool startCounting = false;
        public bool damaged = false;
        public float smoothColour = 5f;
    }

    public PlayerStats playerStats = new PlayerStats();
    public Material matBlinking;
    private Material matDefault;
    private SpriteRenderer sr;


    private void Start()
    {
        playerStats.health = playerStats.startingHealth;
        sr = GetComponent<SpriteRenderer>();
        matDefault = sr.material;
    }

    private void Update()
    {


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

        playerStats.healthVisualisation.UpdateHpMeter((int)playerStats.health);

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
        Debug.Log("DealDamage");
        if (!playerStats.startCounting)
        {
            Debug.Log("\t Dealing damage");
            playerStats.startCounting = true;
            playerStats.playerTimeBetweenHits = playerStats.attackCd;
            playerStats.damaged = true;
            playerStats.health -= damage;
        }

        if (playerStats.health <= 0)
        {
            Debug.Log("\t Killing the player");
            playerStats.healthVisualisation.UpdateHpMeter((int)playerStats.health);
            GameMaster.KillPlayer(this);
            Instantiate(playerStats.playerDeathEffect, transform.position, transform.rotation);
        }
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Killzone"))
        {
            GameMaster.KillPlayer(this);
            Instantiate(playerStats.playerDeathEffect, transform.position, transform.rotation);
        }
    }
}