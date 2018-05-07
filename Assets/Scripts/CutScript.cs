using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutScript : MonoBehaviour {

    public Material capMaterial;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)
    {
        GameObject victim = other.collider.gameObject;

        if (victim.tag.Equals("Cutable"))
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
        }
    }
}
