using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    [SerializeField] private GameObject _enemyPrefab = null;

    private void Start()
    {
        spawnClock = 2f;
    }

    protected override void Spawn()
    {
        Instantiate(_enemyPrefab, transform.position, transform.rotation);
    }
}
