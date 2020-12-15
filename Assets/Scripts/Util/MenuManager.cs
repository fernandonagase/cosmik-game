using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _creditsPanel = null;

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        _creditsPanel.SetActive(!_creditsPanel.activeSelf);
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