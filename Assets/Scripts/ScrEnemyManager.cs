using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrEnemyManager : MonoBehaviour {

    public GameObject square;
    public float spawnTime = 1f;
    public Transform[] spawnPoints;
    public static int difficult_level;
    int count;                          //its to manage the difficult and control the time spawn

    
    // Use this for initialization
    void Start()
    {
        count = 0;
        difficult_level = 0;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    private void Update()
    {
        //Update de difficulty
        if (CutScript.score >= 10) IncreaseDifficulty();
        else if (CutScript.score >= 20) IncreaseDifficulty();
        else if (CutScript.score >= 30) IncreaseDifficulty();
        else if (CutScript.score >= 40) IncreaseDifficulty();
        else if (CutScript.score >= 50) IncreaseDifficulty();
    }

    //Sawns an enemy in a spawn point chossen randomly
    void Spawn()
    {
        Difficulty(difficult_level);
        /* int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);*/
    }

    void Difficulty(int s)
    {
        int spawnPointIndex; 
        GameObject saux;
        switch (s)
        {
            case 0:
                //All the squares appear in the same place and every three seconds
                if (Count(3))
                {
                    spawnPointIndex = 0;
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                }
                break;
            case 1:
                //1 square every 2 seconds in all spawn points
                if (Count(2))
                {
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                }
                break;
            case 2:
                //2 square every 2 seconds in all spawn points
                if (Count(2))
                {
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                }
                break;
            case 3:
                //3 square every 2 seconds in all spawn points
                if (Count(2))
                {
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                    spawnPointIndex = Random.Range(0, spawnPoints.Length);
                    saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                }
                break;
            case 4:
                //3 square every second in all spawn points
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                break;
            case 5:
                //4 square every second in all spawn points
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawnPointIndex = Random.Range(0, spawnPoints.Length);
                saux = Instantiate(square, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                break;
        }
    }

    void IncreaseDifficulty()
    {
        difficult_level++;
    }

    void DecreaseDifficulty()
    {
        difficult_level--;
    }

    bool Count(int seconds)
    {
        count++;
        return count%seconds==0;
    }
}

