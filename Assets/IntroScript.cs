using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {
	public Canvas introtext;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = introtext.transform.position;
		if (pos.y < 1300) {
			pos.y += 1;
			introtext.transform.SetPositionAndRotation (pos, introtext.transform.rotation);
		} else {
			waiter();
			SceneManager.LoadScene("City", LoadSceneMode.Single);
		}
	}

	private IEnumerator waiter(){
		yield return new WaitForSeconds (10);
	}
}
