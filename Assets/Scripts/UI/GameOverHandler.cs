using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameOverlay;
    [SerializeField] Text KillText;
    [SerializeField] Text TimeText;
    [SerializeField] Text WaveText;
    [SerializeField] Text OverlayTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StatClass.statClass.Health <= 0)
        {
            StatClass.statClass.EndGame();
        }
        
        if (StatClass.statClass.IsGameOver)
        {
            gameOverMenu.SetActive(true);
            KillText.text = StatClass.statClass.Kills.ToString();
            TimeText.text = OverlayTimer.text;
            WaveText.text = WaveSystem.waveSystem.Round.ToString();
            gameOverlay.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
