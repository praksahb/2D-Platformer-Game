using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameWonController : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public TextMeshProUGUI scoreText;

    private TextMeshProUGUI totalScoreText;
    private int totalScore;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayNextLevel);
        quitButton.onClick.AddListener(QuitGame);

        CloneTotalScoreTextUI();
    }

    private void CloneTotalScoreTextUI()
    {
        Vector3 scoreTextPosition = scoreText.rectTransform.position;
        scoreTextPosition.y -= 50;
        totalScoreText = Instantiate(scoreText, scoreTextPosition, Quaternion.identity, gameObject.transform);
    }

    public void QuitGame()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void PlayNextLevel()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        LevelManager.Instance.PlayNextLevel();
    }

    public void LoadGameWonUI(int levelScore)
    {
        gameObject.SetActive(true);
        scoreText.text = "Level Score: " + levelScore;
        ModifyTotalScore(levelScore);
    }

    //Reset total score in LobbyController: line 32 
    private void ModifyTotalScore(int levelScore)
    {
        totalScore = PlayerPrefs.GetInt("totalScore", 0);
        totalScore += levelScore;
        PlayerPrefs.SetInt("totalScore", totalScore);
        totalScoreText.text = "Total Score: " + totalScore;
    }
}
