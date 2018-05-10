using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyScript : MonoBehaviour {

	public Image image;
	private float transparency=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Color color = image.material.color;
		color.a = transparency;
		image.material.color = color;
	}
	void DecreaseTransparency(){
		transparency = transparency - 0.2f;
	}
	void IncreaseTransparency(){
		transparency = transparency + 0.2f;
	}
}
