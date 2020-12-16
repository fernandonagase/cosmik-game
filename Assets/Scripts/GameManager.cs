using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; }

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject
            .FindWithTag("HUD")
            .GetComponent<UIManager>();
    }

    public static GameManager GetGameManager()
    {
        return GameObject
            .FindWithTag("GameManager")
            .GetComponent<GameManager>();
    }

    public void FinishGame()
    {
        _uiManager.DisplayGameOverScreen(Score);
    }

    public void IncrementScore(int score)
    {
        Score += score;
        _uiManager.UpdateScore(Score);
    }

    public void UpdateUIHealth(int health)
    {
        _uiManager.UpdateHealth(health);
    }
}
