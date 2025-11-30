using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private bool gameEnded = false;

    public GameObject gameOverUI;

    private void Start()
    {
        Time.timeScale = 1; // Un-Freezes game at start
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

    }

    void EndGame()
    {
        gameEnded = true;
        
        gameOverUI.SetActive(true);

        Time.timeScale = 0; // Freezes game after losing

    }

}
