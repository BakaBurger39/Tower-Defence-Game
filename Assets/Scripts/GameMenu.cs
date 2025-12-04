using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject LevelSelectScreen;
    public GameObject ExitLevelScreenButton;

    private void Start()
    {
        LevelSelectScreen.SetActive(false);
    }


    public void LevelSelect()
    {
        LevelSelectScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }

    public void ExitLevelSelect()
    {
        LevelSelectScreen.SetActive(false);
        MenuScreen.SetActive(true);
    }


    public void StartLevelOne()
    {
        SceneManager.LoadScene(0);
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene(2);
    }
}
