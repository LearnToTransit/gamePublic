using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	private int valor = 0;
	// Use this for initialization
	void Start () {
		
	}


	void Update () {

	}


	public void StartGame1()
	{
		
		if (valor == 0) {
			SceneManager.LoadScene ("1");
			Time.timeScale = 1;
		} else if (valor == 1) {
			SceneManager.LoadScene ("2");
			Time.timeScale = 1;
		}

	}



	public void DropDown(int input){
		Debug.Log ("" + input);
		valor = input;
	
	}
	public void ComoJugar(){
		Debug.Log ("Hellouuu Insertar Aca Como Se Juega");

	}
	public void AprendeMas(){
	
		Application.OpenURL("http://learntotransit.ggitapps.com/aprendemas.html");
	}
}