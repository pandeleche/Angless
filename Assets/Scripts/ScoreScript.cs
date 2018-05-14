using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text text_score;
	
	// Use this for initialization
	void Start () {
        text_score.text = "Score: " + CutScript.score;
	}

	// Update is called once per frame
	void Update () {
		text_score.text = "Score: " + CutScript.score;
	}
}
