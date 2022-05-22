using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatClass : MonoBehaviour
{
    // Variables
    public static StatClass statClass;


    [SerializeField] private int kills = 0;
    [SerializeField] private bool isGameOver;
    [SerializeField] private int health = 100;



    // Accessible properties
    public int Kills { get { return kills; } }
    public bool IsGameOver { get { return isGameOver; } }
    public int Health { get { return health; } }
    
    /// <summary>
    /// Functions
    /// </summary>
    private void Awake()
    {
        statClass = this;
    }

    public void addAKill()
    {
        kills = kills + 1;
    }
    
    public void RemoveHP()
    {
        health -= 10;
    }

    public void EndGame()
    {
        isGameOver = true;
    }

    public void RestartGame()
    {
        isGameOver = false;
        health = 100;
        kills = 0;
        Time.timeScale = 1;
    }
}
