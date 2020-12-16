using UnityEngine;

public class DescendingEnemyBehaviour : EnemyBehaviour, IShooterShip
{
    private const float SPEED = 2.4f;

    private GameObject _firespot;
    [SerializeField] private GameObject _blastPrefab = null;
    private Camera _mainCam;

    private Vector3 _lowerLeftCorner;

    private void Start()
    {
        _mainCam = Camera.main;
        _lowerLeftCorner = _mainCam.ScreenToWorldPoint(Vector3.zero);
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
        CheckLowerBoundary();
        transform.position += Vector3.down * SPEED * Time.deltaTime;
    }

    private void CheckLowerBoundary()
    {
        if (transform.position.y < _lowerLeftCorner.y)
        {
            DestroySelf();
        }
    }

    public override void DestroySelf()
    {
        GameObject
            .FindWithTag("EnemySpawner")
            .GetComponent<EnemySpawner>()
            .RemoveFromList(gameObject);
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
