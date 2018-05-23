using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
		SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
		/*
        EnemyBehaviour.die = true;
        ScrEnemyManager.difficult_level = -1;
		Vector3 aux = player.position;
        Quaternion aux2 = player.rotation;
		aux += new Vector3(0.1f,0.0f,0.0f);
		Instantiate (Restart_prefab, aux, aux2);
		Screen_canvas_text.text = "YOU LOSE";
		Screen_canvas_text.fontSize = 50;
		*/
	}
}
