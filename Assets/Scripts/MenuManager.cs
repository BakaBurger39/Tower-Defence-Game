using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private bool gameEnded = false;

    private bool gameWon = false;

    public GameObject gameOverUI;
    public GameObject gameWonUI;

    public int roundsToWin;

    public GameObject talkingScreen;

    public AudioSource source;
    public AudioClip Win;
    public AudioClip Lose;


    private void Start()
    {
        talkingScreen.SetActive(true);

        Time.timeScale = 1; // Un-Freezes game at start
        gameWon = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (PlayerStats.Rounds >= roundsToWin)
        {
            WinGame();
        }

    }

    void EndGame()
    {
        source.PlayOneShot(Lose);

        gameEnded = true;
        
        gameOverUI.SetActive(true);

        Time.timeScale = 0; // Freezes game after losing

    }

    void WinGame()
    {
        source.PlayOneShot(Win);

        gameWonUI.SetActive(true);

        Time.timeScale = 0;
    }


    public void CloseText()
    {
        talkingScreen.SetActive(false);
    }


}
