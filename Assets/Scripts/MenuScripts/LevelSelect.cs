using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    [SerializeField] Button level1;
    [SerializeField] Button level2;
    [SerializeField] Button level3;
    [SerializeField] Button level4;
    [SerializeField] Button backButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level1.onClick.AddListener(level1Click);
        level2.onClick.AddListener(level2Click);
        level3.onClick.AddListener(level3Click);
        level4.onClick.AddListener(level4Click);
        backButton.onClick.AddListener(BackBtnClick);
    }
    void level1Click(){SceneManager.LoadScene("Level1");}
    void level2Click(){SceneManager.LoadScene("Level2");}
    void level3Click(){SceneManager.LoadScene("Level3");}
    void level4Click(){SceneManager.LoadScene("Level4");}
    void BackBtnClick(){SceneManager.LoadScene("MainMenu");}


}
