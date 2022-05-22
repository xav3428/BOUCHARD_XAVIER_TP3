using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Accueil");
        Time.timeScale = 1;
    }
}
