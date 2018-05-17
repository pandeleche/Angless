﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SfuhrerBehaviour : MonoBehaviour {
	public Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;      // Reference to the player's health.
	//EnemyHealth enemyHealth;        // Reference to this enemy's health.
	public NavMeshAgent nav;               // Reference to the nav mesh agent.
	
	// Update is called once per frame
	void Update () {
		// If the enemy and the player have health left...
		//if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		// {
		// ... set the destination of the nav mesh agent to the player.
		nav.SetDestination(player.position);
		// }
		// Otherwise...
		//else
		//{
		// ... disable the nav mesh agent.
		//nav.enabled = false;
		//}
	}
}