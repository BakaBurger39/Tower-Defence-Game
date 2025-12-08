using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePaused : MonoBehaviour
{
    public GameObject gamePausedUI;
    public GameObject pauseButton;

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void RetryLvl2()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gamePausedUI.SetActive(true);
        pauseButton.SetActive(false);
    }
    

    public void Unpause()
    {
        Time.timeScale = 1;
        gamePausedUI.SetActive(false);
        pauseButton.SetActive(true);
    }

}
