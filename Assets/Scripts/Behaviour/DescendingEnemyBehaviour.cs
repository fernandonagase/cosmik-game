using UnityEngine;

public class DescendingEnemyBehaviour : EnemyBehaviour
{
    private const float SPEED = 2.4f;

    void Update()
    {
        transform.position += Vector3.down * SPEED * Time.deltaTime;
    }

    public override void Destroy()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage()
    {
        if (--health <= 0)
        {
            Destroy();
        }
    }
}
