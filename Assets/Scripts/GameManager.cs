using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; private set; }

    public static GameManager GetGameManager()
    {
        return GameObject
            .FindWithTag("GameManager")
            .GetComponent<GameManager>();
    }

    public void IncrementScore(int score)
    {
        Score += score;
    }
}
