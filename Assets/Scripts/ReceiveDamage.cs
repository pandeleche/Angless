using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveDamage : MonoBehaviour {

	private int Heatlh_Points = 5;
	public LoseMessage lose;
	private float last_damage = 0;
	public TransparencyScript transparency;

	public void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag.Equals("Cutable")) {
			Heatlh_Points--;
			last_damage = UnityEngine.Time.time;
			transparency.Invoke ("IncreaseTransparency", 0.1f);
		}
		if (Heatlh_Points == 0) {
			lose.Invoke ("Player_lose",1);
		}
	}

	public void Update(){
		if(last_damage<=UnityEngine.Time.time-5){
			transparency.Invoke ("DecreaseTransparency", 0.1f);
		}
	}
}
