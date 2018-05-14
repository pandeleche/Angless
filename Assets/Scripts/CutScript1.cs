using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CutScript1 : MonoBehaviour {

    //This is the material of the cutscript
    public Material capMaterial;

    //This is for the score of the cut
    public Text text_score;
    private int score = 0;
    private float perfect_cut_cos = Mathf.Cos(Mathf.PI / 4);


    //Changing the face
    public Material hitMaterial;


    private void OnCollisionEnter(Collision other)
    {
        GameObject victim = other.collider.gameObject;

        if (victim.tag.Equals("Cutable"))
        {
            if (victim.GetComponent<EnemyHealth>().currentHealth != 0)
            {
                victim.GetComponent<EnemyHealth>().currentHealth = 0;
                victim.GetComponent<Renderer>().material = hitMaterial;
            }else
            {
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
                CutDone(transform.rotation.eulerAngles);
            }
            if (victim.tag.Equals("CutableHacendado"))
            {
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
                CutDone(transform.rotation.eulerAngles);
            }


        }
    }

    //Calculates the score of the cut depending on the roll of the sword
    void CutDone(Vector3 rotation)
    {
        int increasing = Mathf.RoundToInt(Mathf.Abs(Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * rotation.z)) - Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * rotation.z))) * 100);
        if (increasing > 0)
        {
            score += increasing;
        }
        else { score++; }
        text_score.text = "Score: " + score;
    }
}

