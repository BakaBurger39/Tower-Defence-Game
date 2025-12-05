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

    public AudioSource source;
    public AudioClip pop;

    private void Start()
    {
        LevelSelectScreen.SetActive(false);
        ControlsScreen.SetActive(false);
    }

    public void ButtonPopSound()
    {
        if(source != null)
        {
            source.PlayOneShot(pop);
        }
        //source.PlayOneShot(pop);
    }


    public void LevelSelect()
    {
        source.PlayOneShot(pop);
        LevelSelectScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }

    public void ExitLevelSelect()
    {
        source.PlayOneShot(pop);
        LevelSelectScreen.SetActive(false);
        MenuScreen.SetActive(true);
        ControlsScreen.SetActive(false);
    }


    public void StartLevelOne()
    {
        source.PlayOneShot(pop);
        SceneManager.LoadScene(0);
    }

    public void StartLevelTwo()
    {
        source.PlayOneShot(pop);
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        source.PlayOneShot(pop);
        ControlsScreen.SetActive(true);
        MenuScreen.SetActive(false);
    }

}
