using UnityEngine;

public class EnemyConfig
{
    private const int MinHealth = 1;
    private const int MinDamage = 5;
    private const int MaxDamage = 100;

    [field: SerializeField, Min(MinHealth)] public int Health { get; private set; }
    [field: SerializeField, Range(MinDamage, MaxDamage)] public int BaseDamage { get; private set; }
}
