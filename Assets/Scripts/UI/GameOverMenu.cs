using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        StatClass.statClass.RestartGame();
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Accueil");
    }
}
