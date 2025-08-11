using System;
using UnityEngine;

[Serializable]
public class ElfConfig : EnemyConfig
{
    private const int MinMana = 5;

    [field: SerializeField, Min(MinMana)] public int Mana { get; private set; }
}
