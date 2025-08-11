using System;
using UnityEngine;

public class Ork : Enemy
{
    private int _additionalDamage;

    private OrkConfig _orkConfig;

    public override void GetInfo(EnemyConfig enemyConfig)
    {
        base.GetInfo(enemyConfig);

        Debug.Log("AdditionalInfo: Additional Damage - " + _additionalDamage);
    }

    public override void Initialize(EnemyConfig enemyConfig)
    {
        base.Initialize(enemyConfig);

        if (enemyConfig is OrkConfig config)
        {
            _orkConfig = config;

            _additionalDamage = _orkConfig.AdditionalDamage;
        }
        else
            throw new InvalidCastException();
    }
}
