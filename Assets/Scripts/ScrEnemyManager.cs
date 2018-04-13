using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrEnemyManager : MonoBehaviour {

    public GameObject square;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //saux.AddComponent<EnemyBehaviour>();
        //anim = saux.GetComponent<Animator>();
        //anim.SetFloat(0.3f,)
    }
}

