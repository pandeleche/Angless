using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

	public Text text_score;
	public static int score = 0;
    private int actualScore;
	public static float employed_time=0;
    Color c;


    private static float starting_time;
	// Use this for initialization
	void Start () {
        
        actualScore = score;
		starting_time = Time.time;
        text_score.text = "Score: " + CutScript.score;
        c = text_score.color;

    }

	// Update is called once per frame
	void Update () {
        if (actualScore < score)
        {
            StartCoroutine(MoreScore());
            actualScore = score;
        }else if (actualScore > score)
        {
            StartCoroutine(LessScore());
            actualScore = score;
        }
		score = CutScript.score;
		text_score.text = "Score: " + score;
	}


	public static void WinGame(){
		employed_time = Time.time - starting_time;
		SceneManager.LoadScene("WinningScene", LoadSceneMode.Single);
	}

    IEnumerator LessScore()
    {
        Color red = new Color(1, 0, 0, 1);
        text_score.color = red;
        yield return new WaitForSeconds(1f);
        text_score.color = c;
    }

    IEnumerator MoreScore()
    {
        
        Color green = new Color(0, 1, 0, 1);
        text_score.color = green;
        yield return new WaitForSeconds(1f);
        text_score.color = c;
    }
}
