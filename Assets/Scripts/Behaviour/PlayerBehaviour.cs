using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IShooterShip, IDamageable, IDestructable
{
    private float _health = 3;
    private int _specialAttackCooldown = 10;
    private bool _hasSpecialAttack = true;

    private GameObject _firespot;
    [SerializeField]
    private GameObject _blastPrefab = null;

    private void Start()
    {
        _firespot = GameObject.FindWithTag("PlayerFirespot");
    }

    public void Shoot()
    {
        GameObject newBlast = Instantiate(
            _blastPrefab,
            _firespot.transform.position,
            transform.rotation
        );
        GetComponent<PlayerAudioController>().PlayShoot();
    }

    public void SpecialAttack()
    {
        if (_hasSpecialAttack)
        {
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake(2, 0.6f));
            List<GameObject> enemies = GameObject
            .FindWithTag("EnemySpawner")
            .GetComponent<EnemySpawner>()
            .GetAllEnemiesSpawned();
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<IDestructable>().DestroySelf();
                GameManager.GetGameManager().IncrementScore(150);
            }
            GameObject.FindWithTag("HUD").GetComponent<UIManager>().UpdateSpecialStatus(false);
            _hasSpecialAttack = false;
            StartCoroutine(RechargeSpecialAttack());
        }
        else
        {
            print("The special attack is not recharged yet");
        }
    }

    public void TakeDamage()
    {
        _health--;
        GameManager.GetGameManager().UpdateUIHealth((int)_health);
        if (_health <= 0)
        {
            DestroySelf();   
        }
    }

    private IEnumerator RechargeSpecialAttack()
    {
        yield return new WaitForSeconds(_specialAttackCooldown);
        _hasSpecialAttack = true;
        GameObject.FindWithTag("HUD").GetComponent<UIManager>().UpdateSpecialStatus(true);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
        GameManager.GetGameManager().FinishGame();
    }
}
