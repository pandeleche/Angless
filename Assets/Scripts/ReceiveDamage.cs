using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamage : MonoBehaviour {

	private int Heatlh_Points = 5;
	public LoseMessage lose;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag.Equals("Cutable")) {
			Heatlh_Points--;
		}
		if (Heatlh_Points == 0) {
			lose.Invoke ("Player_lose",1);
		}
	}
}
