﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SfuhrerRocket : MonoBehaviour {
	public Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;      // Reference to the player's health.
	//EnemyHealth enemyHealth;        // Reference to this enemy's health.
    public GameObject bullet;
    public Transform spawnPoints;

    public int damp = 2;
    public int  velocidadePerseguidor = 4;
    public Rigidbody projectile;
    public int speed = 20;

    public static int sfurerHealth = 5;
    public static int life = 5;
    int cnt = 0;
    public static bool sfurerInmunity = true;

    public Material damagedMaterial;
    public Material normalMaterial;

    // Update is called once per frame
    void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
    }
    void Update()
    {
		if (cnt < 150)
        {
            FinalShoot();
            cnt++;
        }
    }
            

    void Shoot()
    {
        if (player != null)
        {

            if (Vector3.Distance(player.transform.position, transform.position) < 200)
            {
               
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), instantiatedProjectile.GetComponent<Collider>());
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 0 - speed));
                
            }
        }
       
    }

    void Sneeze()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 200)
            {

                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), instantiatedProjectile.GetComponent<Collider>());
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 0 - speed));

            }
        }
    }

    void FinalShoot()
    {
        GameObject saux = Instantiate(bullet, spawnPoints.position, spawnPoints.rotation);
        
    }

    public void DecreaseLife()
    {
        sfurerHealth--;
    }

    //Change the color
    IEnumerator Damage()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = damagedMaterial;
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
    }
	IEnumerator WinScreen(){
		yield return new WaitForSeconds(4f);
		ScoreScript.WinGame ();
	}
}
