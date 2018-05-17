using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {
	public GameObject obj;
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = obj.transform.position;
		RectTransform r = (RectTransform) obj.transform;
		Vector3 p2 = r.anchoredPosition;
		if (p2.y < 2300) {
			pos.y += 0.0002f;
			r.position = pos;
		} else {
			count++;
			if (count > 100) {
				SceneManager.LoadScene("City", LoadSceneMode.Single);
			}
		}
	}
}
