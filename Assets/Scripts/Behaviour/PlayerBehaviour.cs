using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IShooterShip
{
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
    }
}
