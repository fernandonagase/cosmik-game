using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;

    [SerializeField]
    private GameObject pausePanel = null;

    public void Pause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0.0f : 1.0f;
        pausePanel.SetActive(isPaused);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
