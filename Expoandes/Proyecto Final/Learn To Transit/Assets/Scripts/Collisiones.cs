using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisiones : MonoBehaviour {
	BoxCollider b;
	// Use this for initialization
	void Start () {
		b = GetComponent<BoxCollider> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision){

		if(collision.relativeVelocity.magnitude>0){
			Debug.Log ("Hellou");
		}

	}
}
