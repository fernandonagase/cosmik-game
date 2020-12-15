using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image _healthBarFill = null;
    private int _maxHealth = 3;

    public void UpdateHealth(int health)
    {
        _healthBarFill.fillAmount = (float)health / _maxHealth;
    }
}
