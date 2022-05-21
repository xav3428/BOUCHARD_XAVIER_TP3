using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAccueil : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject InstructionMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void MainMenuButton()
    {
        // Show MainMenu
        MainMenu.SetActive(true);
        InstructionMenu.SetActive(false);
    }

    public void InstructionButton()
    {
        // Show MainMenu
        MainMenu.SetActive(false);
        InstructionMenu.SetActive(true);
    }
}
