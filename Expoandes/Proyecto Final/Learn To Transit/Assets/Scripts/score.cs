using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
	private float re = 0.0f;

	private int difficultyLevel = 1;
	private int maxDiflvl = 10000;
	private int scoreTonxtlvl= 100;
	private bool isDead=false;
	public DeathMenu deathMenu;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead)
			return;
		if (re >= scoreTonxtlvl)
			LevelUp ();
		
		re += Time.deltaTime * GetComponent<Motor> ().speed;
		scoreText.text = ((int)re).ToString ();
	}
	void LevelUp(){
		if (difficultyLevel == maxDiflvl)
			return;
		scoreTonxtlvl *=2;
		difficultyLevel++;

	}
	public void parar(){
		isDead = true;
		deathMenu.ToggleEndMenu (re);
	}

}
