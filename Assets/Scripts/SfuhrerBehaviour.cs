using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SfuhrerBehaviour : MonoBehaviour {
	public Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;      // Reference to the player's health.
	//EnemyHealth enemyHealth;        // Reference to this enemy's health.
	public NavMeshAgent nav;               // Reference to the nav mesh agent.
    public GameObject bullet;
    public Transform spawnPoints;

    public int damp = 2;
    public int  velocidadePerseguidor = 4;
    public Rigidbody projectile;
    public int speed = 20;

    public static int sfurerHealth = 5;

    // Update is called once per frame

    private void Start()
    {
       InvokeRepeating("Shoot", 1f, 1f);
        //InvokeRepeating("FinalShoot", 5f, 5f);
    }
    void Update()
    {

        if (Vector3.Distance(player.transform.position, transform.position) < 20)
        {
            // aqui podes poner animaciones
            var rotate = Quaternion.LookRotation(-player.transform.position + transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, damp * Time.deltaTime);
            var newVelocity = 0 - velocidadePerseguidor;
            transform.Translate(0, 0, newVelocity * Time.deltaTime);

        }
        if (sfurerHealth <= 0)
        {
            FinalShoot();
        }
    }
            

    void Shoot()
    {
        if (player != null)
        {

            if (Vector3.Distance(player.transform.position, transform.position) < 20)
            {
                // aqui podes poner animaciones
                
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), instantiatedProjectile.GetComponent<Collider>());
                instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, 0 - speed));
                
            }
        }
        //for (int i = 0; i < 10; i++)
        //{
        //    GameObject saux = Instantiate(bullet, spawnPoints.position, spawnPoints.rotation);
        //}
    }

    void FinalShoot()
    {
        GameObject saux = Instantiate(bullet, spawnPoints.position, spawnPoints.rotation);
        
    }

    void DecreaseLife()
    {
        sfurerHealth--;
    }
}
