using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    [SerializeField] private GameObject _enemyPrefab = null;
    private Camera _mainCam;

    private Vector3 _lowerLeftLimit;
    private Vector3 _upperRightLimit;
    private List<GameObject> enemiesSpawned = new List<GameObject>();

    private void Start()
    {
        spawnClock = 2f;

        _mainCam = Camera.main;
        _lowerLeftLimit = _mainCam.ScreenToWorldPoint(Vector3.zero);
        _upperRightLimit = _mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    protected override void Spawn()
    {
        float horizontalPosition = Random.Range(_lowerLeftLimit.x, _upperRightLimit.x);
        enemiesSpawned.Add(Instantiate(
            _enemyPrefab,
            new Vector3(horizontalPosition, transform.position.y, 0),
            transform.rotation
        ));
    }

    public void RemoveFromList(GameObject enemy)
    {
        enemiesSpawned.Remove(enemy);
    }

    public List<GameObject> GetAllEnemiesSpawned()
    {
        List<GameObject> enemies = enemiesSpawned;
        enemiesSpawned = new List<GameObject>();
        return enemies;
    }
}
