using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScripts : MonoBehaviour {

	public bool pausado;
	public Component x;

	void Start () {
		pausado = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void Pausa(){

		pausado = !pausado;
		if (pausado) {
			Time.timeScale = 0;
		} else if (!pausado) {
			Time.timeScale = 1;
		}
	}

	public void Reiniciar(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		Time.timeScale = 1;
	
	}
	public void Home(){
	
		SceneManager.LoadScene ("Main Menu");
	}
	public void Frenar(){
		x.GetComponent<Motor> ().Braked();

	}
	public void PararFrenar(){
		x.GetComponent<Motor> ().noBraked();
	}
}
