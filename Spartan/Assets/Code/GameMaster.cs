using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Player player;
    public Transform playerPrefab;
    public Transform spawnPoint;

    public int spawnDelay;
    
    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    
    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);  
        player.transform.position = spawnPoint.position;
        player.gameObject.SetActive(true);
        player.playerStats.health = player.playerStats.startingHealth;
        //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(Player player)
    {
        player.playerStats.health = 0;
        player.gameObject.SetActive(false);
        //Destroy(player.gameObject);
        Debug.Log("Respawning player!");
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
