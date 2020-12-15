using UnityEngine;

public class PlayerBlastBehaviour : MonoBehaviour
{
    private float BLAST_FORCE = 256f;

    private void Start()
    {
        GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * BLAST_FORCE);

        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            IDamageable damageable = collision.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }
        }
    }
}
