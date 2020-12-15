using UnityEngine;

public class PlayerBlastBehaviour : BlastBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
                GameManager.GetGameManager().IncrementScore(100);
            }
        }
    }
}
