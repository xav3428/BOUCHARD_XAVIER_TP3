using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    // Variables
    public static WaveSystem waveSystem;
    int round = 0;
    public int numberToSpawn = 4;
    public int numberToAddEachRound = 4;
    bool waveQueued = false;
    public GameObject zombie;
    private System.Random random = new System.Random();
    private List<GameObject> listZombies = new List<GameObject>();
    [SerializeField] private List<GameObject> listSpawnpoint = new List<GameObject>();
    Transform spawnPoint;


    // Accessible properties
    public List<GameObject> ListZombies { get { return this.listZombies; } }
    public int Round { get { return this.round; } }

    /// <summary>
    /// Functions
    /// </summary>
    private void Awake()
    {
        waveSystem = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (waveQueued == false && listZombies.Count == 0)
        {
            round += 1;
            Invoke("startNextWave", 5f);
            Debug.Log("round queued");
            waveQueued = true;
        }
    }

    void startNextWave()
    {
        spawnMonsters();
        Debug.Log("Round" + round + "spawned");
        waveQueued = false;
    }

    void spawnMonsters()
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            // The Invoke here makes it that every enemy spawns at an interval of 0.5f
            Invoke("spawnEnemy", 0.5f*i);
        }
        numberToSpawn += numberToAddEachRound;
    }

    int generateRandomIndex()
    {
        // We roll an index of the list of spawns to randomly spawn the zombies at different places
        return random.Next(listSpawnpoint.Count);
    }

    Vector3 selectRandomSpawnPoint()
    {
        return listSpawnpoint[generateRandomIndex()].transform.position;
    }

    void spawnEnemy()
    {
        instantiateEnemy(zombie, selectRandomSpawnPoint());
    }

    void addEnemyToList(GameObject enemy)
    {
        listZombies.Add(enemy);
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        listZombies.Remove(enemy);
    }
    void instantiateEnemy(GameObject monster, Vector3 appearanceTransform)
    {
        // We add the enemy to the monster list to easily have access to all monster later in the game
        GameObject enemy = Instantiate(monster, appearanceTransform, Quaternion.identity);
        addEnemyToList(enemy);
    }
}
