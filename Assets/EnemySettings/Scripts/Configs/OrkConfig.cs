using System;
using UnityEngine;

[Serializable]
public class OrkConfig : EnemyConfig
{
    private const int MinAdditionalDamage = 2;

    [field: SerializeField, Min(MinAdditionalDamage)] public int AdditionalDamage { get; private set; }
}
