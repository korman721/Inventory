using System;
using UnityEngine;

public class Dragon : Enemy
{
    private int _fireballDamage;

    private DragonConfig _dragonConfig;

    public override void GetInfo(EnemyConfig enemyConfig)
    {
        base.GetInfo(enemyConfig);

        Debug.Log("AdditionalInfo: Mana - " + _fireballDamage);
    }

    public override void Initialize(EnemyConfig enemyConfig)
    {
        base.Initialize(enemyConfig);

        if (enemyConfig is DragonConfig config)
        {
            _dragonConfig = config;

            _fireballDamage = _dragonConfig.FireBallDamage;
        }
        else
            throw new InvalidCastException();
    }
}
