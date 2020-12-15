using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour, IDamageable, IDestructable
{
    protected float health = 1;

    public abstract void TakeDamage();
    public abstract void DestroySelf();
}
