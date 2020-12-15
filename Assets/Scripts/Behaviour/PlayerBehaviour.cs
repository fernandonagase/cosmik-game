using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IShooterShip, IDamageable, IDestructable
{
    private float _health = 3;

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

    public void TakeDamage()
    {
        _health--;
        GameManager.GetGameManager().UpdateUIHealth((int)_health);
        if (_health <= 0)
        {
            DestroySelf();   
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
