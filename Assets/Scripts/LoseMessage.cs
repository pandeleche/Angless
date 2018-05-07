using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMessage : MonoBehaviour {

	public Text Screen_canvas_text;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Player_lose(){
		Screen_canvas_text.text = "YOU LOSE";
		Screen_canvas_text.fontSize = 50;
	}
}
