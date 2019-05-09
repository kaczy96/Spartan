using System.Collections;
using UnityEditor;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Enemy enemy;
    public float stoppingDistance;
    public float rangedDistance;
    public float retreatDistance;
    public float runningAwaySpeed;

    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public GameObject projectile;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBetweenShots = startTimeBetweenShots;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position)>stoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance &&
                 Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -runningAwaySpeed * Time.deltaTime);
        }

        
            
        switch (enemy.enemyType)
        {
            case Enemy.EnemyType.Meele:
                stoppingDistance = (int) 1.0f;
                retreatDistance = 0.5f;
                break;
            case Enemy.EnemyType.Ranged:
                stoppingDistance = rangedDistance;
                retreatDistance = rangedDistance-1;
                Shoot();
                break;
            case Enemy.EnemyType.Bug:
                break;
                
        }
    }

    void Shoot()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    
}