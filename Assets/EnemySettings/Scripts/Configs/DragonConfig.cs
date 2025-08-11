using System;
using UnityEngine;

[Serializable]
public class DragonConfig : EnemyConfig
{
    private const int MinFireBallDamage = 25;
    private const int MaxFireBallDamage = 50;

    [field: SerializeField, Range(MinFireBallDamage, MaxFireBallDamage)] public int FireBallDamage { get; private set; }
}
