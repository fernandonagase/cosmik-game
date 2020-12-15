using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    protected float spawnClock;
    protected float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnClock)
        {
            Spawn();
            elapsedTime -= spawnClock;
        }
    }

    protected abstract void Spawn();
}
