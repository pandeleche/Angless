using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMessage : MonoBehaviour {
	
	public Transform player;
	public Text Screen_canvas_text;
	public GameObject Restart_prefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Player_lose(){
		GameObject aux =Instantiate (Restart_prefab,player,true);
		aux.transform.position.x += 0.5;
		Screen_canvas_text.text = "YOU LOSE";
		Screen_canvas_text.fontSize = 50;
	}
}
