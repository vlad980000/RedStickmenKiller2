using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Settings",menuName = "Level Settings / Create new level",order = 51)]
public class EnemySettings : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _reward;
    [SerializeField] private int _spawnIndex;

    public int Health => _health;
    public int Damage => _damage;
    public int SpawnIndex => _spawnIndex;
    public int Reward => _reward;   

}
