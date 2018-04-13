using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachable : MonoBehaviour {
	public GameObject AttachPoint;
	public GameObject Scimitar;
	// Use this for initialization
	void Start () {
		Transform trans = AttachPoint.transform;
		Scimitar.transform.position = trans.position;
		Scimitar.transform.rotation = trans.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		Transform trans = AttachPoint.transform;
		Scimitar.transform.position = trans.position;
		Scimitar.transform.rotation = trans.rotation;
	}
}
