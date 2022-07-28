using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button LoadButton;

    public string LevelName;

    private void Awake()
    {
        LoadButton = GetComponent<Button>();
        LoadButton.onClick.AddListener(LoadLevel);
    }

    public void LoadLevel()
    {
        SoundManager.Instance.PlayEffect(Sounds.ButtonClick);
        LevelManager.Instance.LoadAnyLevel(LevelName);
    }
}