using UnityEngine;

public class DescendingEnemyBehaviour : EnemyBehaviour, IShooterShip
{
    private const float SPEED = 2.4f;

    private GameObject _firespot;
    [SerializeField] private GameObject _blastPrefab = null;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if (transform.GetChild(i).gameObject.CompareTag("DescendingEnemyFirespot"))
            {
                _firespot = transform.GetChild(i).gameObject;
                return;
            }
        }
    }

    void Update()
    {
        transform.position += Vector3.down * SPEED * Time.deltaTime;
    }

    public override void DestroySelf()
    {
        Destroy(gameObject);
    }

    public override void TakeDamage()
    {
        if (--health <= 0)
        {
            DestroySelf();
        }
    }

    public void Shoot()
    {
        Instantiate(
            _blastPrefab,
            _firespot.transform.position,
            transform.rotation
        );
    }
}
