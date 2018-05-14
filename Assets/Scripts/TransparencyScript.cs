using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyScript : MonoBehaviour {

	public Image image;
	private float alpha=0.0f;
	// Use this for initialization
	void Start () {
		Color color = image.material.color;
		color.a = alpha;
		image.material.color = color;
	}

	// Update is called once per frame
	void Update () {
		Color color = image.material.color;
		color.a = alpha;
		image.material.color = color;
	}
	void DecreaseTransparency(){
		alpha = alpha + 0.2f;
	}
	void IncreaseTransparency(){
		alpha = alpha - 0.2f;
	}
}
