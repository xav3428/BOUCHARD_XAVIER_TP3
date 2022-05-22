using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatUpdater : MonoBehaviour
{
    [SerializeField] private Text EnemyCountText;
    [SerializeField] private Text WaveText;
    [SerializeField] private Slider HealthSlider;
    
    // Update is called once per frame
    void Update()
    {
        EnemyCountText.text = WaveSystem.waveSystem.ListZombies.Count.ToString();
        HealthSlider.value = StatClass.statClass.Health;
        WaveText.text = "Vague "+ WaveSystem.waveSystem.Round.ToString();
    }
}
