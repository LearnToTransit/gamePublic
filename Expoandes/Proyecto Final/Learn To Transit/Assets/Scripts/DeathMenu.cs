using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
	public Text scoreText;

	private float transition = 0.0f;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ToggleEndMenu(float score){
		gameObject.SetActive (true);
		scoreText.text = "" + (int)score;

	}
}
