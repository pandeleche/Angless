using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class IntroScript : MonoBehaviour {
	public GameObject obj;
	private int count;
    public Hand hand1, hand2;
	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = obj.transform.position;
		RectTransform r = (RectTransform) obj.transform;
		Vector3 p2 = r.anchoredPosition;
		if (p2.y < 4000) {
			pos.y += 0.005f;
			r.position = pos;
		} else {
			count++;
		}

        if ((hand1.controller != null && hand1.controller.GetHairTriggerDown()) || (hand2.controller != null && hand2.controller.GetHairTriggerDown()) || count > 100)
        {
            SceneManager.LoadScene("City", LoadSceneMode.Single);
        }

    }
}
