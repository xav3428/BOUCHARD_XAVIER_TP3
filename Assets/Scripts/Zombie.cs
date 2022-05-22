using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour, IDamageable
{
    // Variable for the health of the zombie
    int health;

    // Variable where the player`s position will be stored
    [SerializeField] private Transform player;
    // Variable to store our own mesh agent
    NavMeshAgent agent;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        health = 1 + 1 * WaveSystem.waveSystem.Round - 1;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        SetTarget(player.transform);
    }

    void UpdateDestination()
    {
        // Si le jeu est finit, on ne fait rien
        if (StatClass.statClass.IsGameOver)
            return;
        // Ajuster la cible
        agent.SetDestination(player.position);
    }

    void PlayerProximityCheck()
    {
        // Si le jeu est finit, on ne fait rien
        if (StatClass.statClass.IsGameOver)
            return;

        // R�cup�re tous les colliders � proximit�
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.4f);

        foreach (var item in colliders)
        {

            if (item.tag == "Player")
            {
                StatClass.statClass.RemoveHP();
                animator.SetTrigger("Attack");
            }

        }
    }

    public void Die()
    {
        CancelInvoke("UpdateDestination");
        WaveSystem.waveSystem.RemoveZombieFromList(gameObject);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("ouch");
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void SetTarget(Transform player_t)
    {
        agent = GetComponent<NavMeshAgent>();

        player = player_t;

        // � toutes les secondes, le zombie ajustera la position de sa cible
        InvokeRepeating("UpdateDestination", 0.05f, 1f);

        // � toutes les 0.5s, le zombie v�rifie si le joueur est a proximit� (si oui, c'est game over)
        InvokeRepeating("PlayerProximityCheck", 0.05f, 0.5f);
    }
}
