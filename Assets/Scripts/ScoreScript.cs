using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text text_score;
	private int score;
	private float perfect_cut_cos = Mathf.Cos(Mathf.PI/4);
	// Use this for initialization
	void Start () {
		score = 100;
	}

	void CutDone(Vector3 rotation){
		int increasing = Mathf.RoundToInt(Mathf.Abs(Mathf.Abs(Mathf.Cos(Mathf.Deg2Rad * rotation.z)) - Mathf.Abs(Mathf.Cos (Mathf.Deg2Rad * rotation.z)))*100);
		score += increasing;
	}
	// Update is called once per frame
	void Update () {
		text_score.text = "Score: " + score;
	}
}
