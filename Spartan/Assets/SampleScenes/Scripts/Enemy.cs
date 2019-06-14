using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType enemyType = EnemyType.None;

    public enum EnemyType
    {
        None,
        Meele,
        Ranged,
        Bug
    }
}
