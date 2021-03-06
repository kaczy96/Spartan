﻿using UnityEngine;

public class AIController : MonoBehaviour
{
    private Transform target;
    public Enemy enemy;
    public GameObject projectile;
    private Animator EnemyAnimator;
    public Transform ProjectileTransformArea;
    private Player player;

    public float speed;
    public float stoppingDistance;
    public float rangedDistance;
    public float retreatDistance;
    public float runningAwaySpeed;
    public float missileRange;
    private bool m_FacingRight = true;
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBetweenShots = startTimeBetweenShots;
        EnemyAnimator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, target.position) < stoppingDistance &&
                 Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            transform.position = transform.position;
        }
        else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -runningAwaySpeed * Time.deltaTime);
        }

        if (enemy.transform.position.x > target.transform.position.x && m_FacingRight)
        {
            Flip();
        }
        if (enemy.transform.position.x < target.transform.position.x && !m_FacingRight)
        {
            Flip();
        }

        switch (enemy.enemyType)
        {
            case Enemy.EnemyType.Meele:
                stoppingDistance = (int)1.0f;
                retreatDistance = 0.5f;
                break;
            case Enemy.EnemyType.Ranged:
                stoppingDistance = rangedDistance;
                retreatDistance = rangedDistance - 1;
                Shoot();
                break;
            case Enemy.EnemyType.Bug:
                if(player.isActiveAndEnabled == false)
                {
                    Destroy(gameObject);  
                }
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(enemy.transform.position, missileRange);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Shoot()
    {
        if (timeBetweenShots <= 0 && Vector2.Distance(transform.position, target.position) < missileRange)
        {
            EnemyAnimator.SetTrigger("Attack");
            Instantiate(projectile, ProjectileTransformArea.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

}