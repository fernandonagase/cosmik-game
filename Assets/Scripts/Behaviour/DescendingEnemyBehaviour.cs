using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescendingEnemyBehaviour : EnemyBehaviour
{
    private const float SPEED = 2.4f;

    void Update()
    {
        transform.position += Vector3.down * SPEED * Time.deltaTime;
    }
}
