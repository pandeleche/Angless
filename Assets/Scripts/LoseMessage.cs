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
		Transform aux = player;
		aux.position += new Vector3(0.1f,0.0f,0.0f);
		Instantiate (Restart_prefab,aux,true);
		Screen_canvas_text.text = "YOU LOSE";
		Screen_canvas_text.fontSize = 50;
	}
}
