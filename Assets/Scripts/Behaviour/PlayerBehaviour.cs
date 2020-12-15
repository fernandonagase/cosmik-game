using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float SHOOT_CLOCK = 1f;
    private float BLAST_FORCE = 256f;

    private float _elapsedTime;

    private GameObject _firespot;
    [SerializeField]
    private GameObject _blastPrefab = null;

    private void Start()
    {
        _firespot = GameObject.FindWithTag("PlayerFirespot");
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= SHOOT_CLOCK)
        {
            Shoot();
            _elapsedTime -= SHOOT_CLOCK;
        }
    }

    private void Shoot()
    {
        GameObject newBlast = Instantiate(
            _blastPrefab,
            _firespot.transform.position,
            transform.rotation
        );
        newBlast.GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * BLAST_FORCE);

        Destroy(newBlast, 5);
    }
}
