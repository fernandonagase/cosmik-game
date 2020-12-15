using UnityEngine;

public abstract class BlastBehaviour : MonoBehaviour
{
    protected float blastForce = 256f;

    void Start()
    {
        GetComponent<Rigidbody2D>()
            .AddRelativeForce(Vector2.up * blastForce);

        Destroy(gameObject, 5);
    }
}
