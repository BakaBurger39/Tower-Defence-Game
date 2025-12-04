using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject MenuScreen;
    public GameObject LevelSelectScreen;
    public GameObject ControlsScreen;
    public GameObject ExitLevelScreenButton;

    private void Start()
    {
        LevelSelectScreen.SetActive(false);
        ControlsScreen.SetActive(false);
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
        ControlsScreen.SetActive(false);
    }


    public void StartLevelOne()
    {
        SceneManager.LoadScene(0);
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        ControlsScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }
}
