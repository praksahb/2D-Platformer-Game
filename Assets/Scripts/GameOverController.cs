using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    public void Awake()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void LoadGameOverUI()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        LevelManager.Instance.ReloadLevel();
    }
}
