using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

	public Text text_score;
	public static int score = 0;
	public static float employed_time=0;


	private float starting_time;
	// Use this for initialization
	void Start () {
		starting_time = Time.time;
        text_score.text = "Score: " + CutScript.score;
	}

	// Update is called once per frame
	void Update () {
		score = CutScript.score;
		text_score.text = "Score: " + score;
	}


	void WinGame(){
		employed_time = Time.time - starting_time;
		SceneManager.LoadScene("WinningScene", LoadSceneMode.Single);
	}
}
