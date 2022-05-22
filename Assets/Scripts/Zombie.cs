using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
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
        health = 1;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        SetTarget(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
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

        // Récupère tous les colliders à proximité
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
        Destroy(gameObject);
    }

    public void ApplyDamage()
    {
        health -= 1;

        if (health <= 0)
        {
            Die();
        }
    }

    public void SetTarget(Transform player_t)
    {
        agent = GetComponent<NavMeshAgent>();

        player = player_t;

        // À toutes les secondes, le zombie ajustera la position de sa cible
        InvokeRepeating("UpdateDestination", 0.1f, 1f);

        // À toutes les 0.5s, le zombie vérifie si le joueur est a proximité (si oui, c'est game over)
        InvokeRepeating("PlayerProximityCheck", 0.1f, 0.5f);
    }
}
