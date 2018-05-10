using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroductionStory : MonoBehaviour {

	public Text story_text;
	public Button next_button;

	private int count = 0;
	private string[] story = {
		"Long ago, the world was full of happy polygons.\nThey lived in peace and harmony.",
		"But one terrible day, a malevolent figure appeared...\nThe Sführer...",
		"The Sführer claimed that the perfect shape was\nthat of a square.",
		"At the beginning nobody cared about it,\nbut soon the squares started to think in the same way",
		"A war started and they stormed houses of all\nnon-square polygons and took them away",
		"Glue camps were created, in which the adepts of the\nSführer glued polygons in order to create\nsquare monstrosities",
		"The triangles were the most affected polygon,\nbecause they were the polygon with less angles",
		"They were called with a name that soon became the name\nof the resistance",
		"You are one of them. You have to fight the squares\nand try to defeat the evil Sführer",
		"You are one of the...",
		"\"Angless\""
	};

	// Use this for initialization
	void Start () {
		story_text.text = story[count];
	}
	
	// Update is called once per frame
	void Update () {
		story_text.text = story[count];
		story_text.fontSize = 32;
	}
	public void Clicked(){
		if (count < story.Length - 1) {
			count++;
			story_text.text = story[count];
			story_text.fontSize = 32;
			if (count == story.Length - 1) {
				story_text.fontSize = 64;
			}
		} else {
			SceneManager.LoadScene("City", LoadSceneMode.Single);
		}
	}
}
