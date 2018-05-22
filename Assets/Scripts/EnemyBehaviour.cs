using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviour : MonoBehaviour {

    private Transform player;               // Reference to the player's position.
    //PlayerHealth playerHealth;      // Reference to the player's health.
    //EnemyHealth enemyHealth;        // Reference to this enemy's health.
    private NavMeshAgent nav;               // Reference to the nav mesh agent.

    public static bool die = false;
    


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
       // enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        //nav.Warp(player.position);
    }


    void FixedUpdate()
    {
            // ... set the destination of the nav mesh agent to the player.
        nav.SetDestination(player.position);
        if (die)
        {
            Destroy(gameObject);
        }
     
    }
}
