﻿using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ExampleUseof_MeshCut : MonoBehaviour {

	public Material capMaterial;

	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){

		if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;

			if(Physics.Raycast(transform.position, transform.forward, out hit)){

				GameObject victim = hit.collider.gameObject;

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

	void OnDrawGizmosSelected() {

		Gizmos.color = Color.green;

		Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 5.0f);
		Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 5.0f);

		Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);
		Gizmos.DrawLine(transform.position,  transform.position + -transform.up * 0.5f);

	}

}