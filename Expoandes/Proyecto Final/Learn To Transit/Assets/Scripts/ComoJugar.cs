using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComoJugar : MonoBehaviour {


	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void ToggleMenu(){
		gameObject.SetActive (true);


	}
	public void UnToggle(){
		gameObject.SetActive (false);
	}
}
