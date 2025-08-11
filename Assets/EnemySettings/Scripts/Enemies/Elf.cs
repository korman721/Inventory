using System;
using UnityEngine;

public class Elf : Enemy
{
    private int _mana;

    private ElfConfig _elfConfig;

    public override void GetInfo(EnemyConfig enemyConfig)
    {
        base.GetInfo(enemyConfig);

        Debug.Log("AdditionalInfo: Mana - " + _mana);
    }

    public override void Initialize(EnemyConfig enemyConfig)
    {
        base.Initialize(enemyConfig);

        if (enemyConfig is ElfConfig config)
        {
            _elfConfig = config;

            _mana = _elfConfig.Mana;
        }
        else
            throw new InvalidCastException();
    }
}
