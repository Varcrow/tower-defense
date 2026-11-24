using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] Button levelSelectButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button quitButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelSelectButton.onClick.AddListener(LevelSelectClick);
        settingsButton.onClick.AddListener(SettingsClick);
        quitButton.onClick.AddListener(QuitClick);
    }

    void LevelSelectClick(){SceneManager.LoadScene("LevelSelect");}
    void SettingsClick(){SceneManager.LoadScene("Settings");}
    void QuitClick(){Application.Quit();}
}
