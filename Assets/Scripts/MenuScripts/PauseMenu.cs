using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    [SerializeField] Button quitButton;
    bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);

        resumeButton.onClick.AddListener(ResumeClick);
        mainMenuButton.onClick.AddListener(MainMenuClick);
        quitButton.onClick.AddListener(QuitClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(isPaused)
                Resume();
            else
                Pause();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void ResumeClick(){Resume();}
    void MainMenuClick(){Time.timeScale = 1f; SceneManager.LoadScene("MainMenu");}
    void QuitClick(){Application.Quit();}
}
