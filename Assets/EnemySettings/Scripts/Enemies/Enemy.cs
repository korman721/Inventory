using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int _health;
    protected int _baseDamage;

    public virtual void Initialize(EnemyConfig enemyConfig)
    {
        _health = enemyConfig.Health;
        _baseDamage = enemyConfig.BaseDamage;
    }

    public virtual void GetInfo(EnemyConfig enemyConfig) =>
        Debug.Log("Hp: " + _health + ", BaseDamage: " + _baseDamage);
}
