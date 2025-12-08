using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    void OnEnable()
    {
        PlayerStats.Rounds -= 1;
        roundsText.text = PlayerStats.Rounds.ToString();
    }

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

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
