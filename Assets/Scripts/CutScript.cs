using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CutScript : MonoBehaviour {

    //This is the material of the cutscript
    public Material capMaterial;

    //This is for the score of the cut
    
    public static int score = 0;
    private float perfect_cut_cos = Mathf.Cos(Mathf.PI / 4);

    AudioSource enemyAudio;                     // Reference to the audio source.

    private void Awake()
    {
        enemyAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        GameObject victim = other.collider.gameObject;

        if (victim.CompareTag("Cutable"))
        {
            enemyAudio.Play();

            GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

            if (!pieces[1].GetComponent<Rigidbody>())
            {
                pieces[1].AddComponent<Rigidbody>();
                pieces[1].AddComponent<BoxCollider>();
            }

            if (!pieces[0].GetComponent<Rigidbody>())
            {
                pieces[0].GetComponent<NavMeshAgent>().enabled = false;
                pieces[0].AddComponent<Rigidbody>();
                pieces[0].AddComponent<BoxCollider>();
            }

            

            Destroy(pieces[1], 3);
            Destroy(pieces[0], 3);

            CutDone(transform.rotation.eulerAngles, 5);
        }
        else if (victim.CompareTag("CutableHacendado"))
        {
            enemyAudio.Play();
            GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

            if (!pieces[1].GetComponent<Rigidbody>())
            {
                pieces[1].AddComponent<Rigidbody>();
                pieces[1].AddComponent<BoxCollider>();
            }

            if (!pieces[0].GetComponent<Rigidbody>())
            {
                pieces[0].GetComponent<NavMeshAgent>().enabled = false;
                pieces[0].AddComponent<Rigidbody>();
                pieces[0].AddComponent<BoxCollider>();
            }
            Destroy(pieces[1], 3);
            Destroy(pieces[0], 3);
        }
        else if (victim.CompareTag("Sfurer"))
        {
            enemyAudio.Play();
            SfuhrerBehaviour.sfuhrerHealth--;
            //SfuhrerBehaviour.sfurerInmunity = !SfuhrerBehaviour.sfurerInmunity;

            if (SfuhrerBehaviour.sfuhrerHealth <= 0)
            {
                GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                if (!pieces[1].GetComponent<Rigidbody>())
                {
                    pieces[1].AddComponent<Rigidbody>();
                    pieces[1].AddComponent<BoxCollider>();
                }

                pieces[0].tag = "Sfurer";
                
                Destroy(pieces[1], 3);
            }
        }
    }

    //Calculates the score of the cut depending on the roll of the sword
    void CutDone(Vector3 rotation, int points)
    {
        //int increasing = Mathf.RoundToInt(Mathf.Abs(Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * rotation.z)) - Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * rotation.z))) * 100);
        //if (increasing > 0)
        //{
        //    score += increasing;
        //}
        //else { score++; }
        score += points;
    }
}

