using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public float damage;
    public float speed;
    public float distance;
}
