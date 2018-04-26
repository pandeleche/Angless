using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Cutable"))
        {
            other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(other.gameObject,2f);
        }
    }
}
