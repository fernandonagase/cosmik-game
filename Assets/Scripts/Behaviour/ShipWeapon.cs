using System;
using UnityEngine;

public class ShipWeapon : MonoBehaviour
{
    protected const float SHOOT_CLOCK = 1f;

    protected float _elapsedTime;
    private IShooterShip _shooterShip;

    private void Start()
    {
        _shooterShip = GetComponent<IShooterShip>();
        if (_shooterShip == null)
        {
            throw new ArgumentException(
                "The current game object doesn't contain a valid IShooterShip component"
            );
        }
    }

    private void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= SHOOT_CLOCK)
        {
            _shooterShip.Shoot();
            _elapsedTime -= SHOOT_CLOCK;
        }
    }
}
