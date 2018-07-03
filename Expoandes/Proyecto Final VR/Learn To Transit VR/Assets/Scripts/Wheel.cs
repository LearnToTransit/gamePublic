using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(WheelCollider))]

public class Wheel : MonoBehaviour {
	WheelCollider wc;

	void Awake() {
		wc = GetComponent<WheelCollider> ();

	}
	
	public void Move(float valor){
		wc.motorTorque = valor;


	}

	public void Turn(float valor){
		wc.steerAngle = valor;
	
	}

	public void brake(float valor){
		wc.brakeTorque = valor;
	}
}
