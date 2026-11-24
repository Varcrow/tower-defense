using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField] Button backButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        backButton.onClick.AddListener(BackBtnClick);
    }

    // Update is called once per frame
    void BackBtnClick(){SceneManager.LoadScene("MainMenu");}
}
