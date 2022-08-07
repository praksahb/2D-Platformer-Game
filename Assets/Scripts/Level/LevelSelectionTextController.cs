using UnityEngine;
using TMPro;

public class LevelSelectionTextController : MonoBehaviour
{
    private TextMeshProUGUI levelSelectionText;

    private void Awake()
    {
        levelSelectionText = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayLockedText()
    {
        levelSelectionText.text = "Level is Locked. Complete Previous Level to unlock.";
        float invokeTime = 0.5f;
        Invoke("ClearDisplayedText", invokeTime);
    }

    private void ClearDisplayedText()
    {
        levelSelectionText.text = "";
    }
}
