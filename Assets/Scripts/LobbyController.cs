using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Button resumeGameButton;
    public Button resetGameButton;

    public GameObject levelSelection;

    private void Awake()
    {
        resumeGameButton.onClick.AddListener(ResumeGame);
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
        resetGameButton.onClick.AddListener(ResetGame);
    }

    public void QuitGame()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private void PlayGame()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        levelSelection.SetActive(true);
        //Resets TotalScore
        PlayerPrefs.SetInt("totalScore", 0);
    }

    private void ResumeGame()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        string cLevel = "currentLevelBeforeExiting";
        LevelManager.Instance.ResumeLastLevelPlayed(cLevel);
    }

    private void ResetGame()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        LevelManager.Instance.ResetGameValues();
    }
}
