using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Attachable : MonoBehaviour {
	
	public int interactiveLayer = 10;
	public 	Collider myCollider;
	public Hand controllerScript;
	public GameObject sword;

	private bool attached;
	private GameObject theClosestGO;
	// Use this for initialization
	void Start () {
		attached = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void DoClick()
	{
		if (theClosestGO != null) {
			attached = true;
			controllerScript.AttachObject (sword);
		}
	}
	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.layer == interactiveLayer)
		{
			theClosestGO = collision.gameObject;
		}
	}
	void OnTriggerExit(Collider collision)
	{
		theClosestGO = null;
	}
}
