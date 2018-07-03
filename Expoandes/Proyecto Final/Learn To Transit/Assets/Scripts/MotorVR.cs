using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class MotorVR : MonoBehaviour {
	// Camilooo(le habla a camilo) el orden de las ruedas es tal que fl fr rl rr fijate en eso porfa :V
	// 10 metros por prefab


	public Wheel[] wheel;
	public Rigidbody rb;
	public float speed = 100f;
	private Vector3 zeroAc;
	private Vector3 curAc;
	private float sensH = 10f;
	private float sensV = 10f;
	private float smooth = 0.5f;
	private float GetAxisH = 0;
	private float GetAxisV = 0;
	public bool frenado = false;
	private bool isDead= false;



	void ResetAxes(){
		zeroAc = Input.acceleration;
		curAc = Vector3.zero;
	
	}

	void start(){
		rb = (Rigidbody)GetComponent(typeof(Rigidbody));
		Vector3 temp = rb.centerOfMass;
		temp.y = -0.900f;
		temp.z = -0.4f;//the f indicates that this is a floating point variable.
		rb.centerOfMass = temp;﻿

		rb.AddForce (Vector3.down * 1000f, ForceMode.Force);
		ResetAxes ();
		Time.timeScale = 1;

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (isDead) {
			return;
		
		}
		Speed ();
		float torque = speed;
		#if UNITY_ANDROID 

		curAc = Vector3.Lerp (curAc, Input.acceleration - zeroAc, Time.deltaTime / smooth);
		GetAxisV= Mathf.Clamp(curAc.x * sensV, -1, 1);
		GetAxisH= Mathf.Clamp(curAc.y * sensV, -1, 1);
		float angle = GetAxisV * sensH;
		#endif

		#if UNITY_EDITOR_WIN
		angle = Input.GetAxis ("Horizontal") * sensH;




		#endif

		if (frenado != true) {
			rb.drag = 0;
			wheel [2].Move (torque);
			wheel [3].Move (torque);
			wheel [0].Move (torque);
			wheel [1].Move (torque);
		} else {
			rb.drag = 0.9f;
		}
		wheel [0].Turn (angle);
		wheel [1].Turn (angle);



	}

	void Speed(){
		if (speed <= 500) {
			speed += 0.09f;
		} else {
			speed = 501;
		}
		if (x > 0) {
			Debug.Log ("Perdiste");
			Death ();
			Time.timeScale = 0;
		}


	}
	public void Braked(){

		frenado = true;
	}
	public void noBraked(){

		frenado = false;
	}

	public void Death (){
		isDead = true;
		GetComponent<score> ().parar ();
		GetComponent<Speedometer> ().parar ();

	}
	private int x = 0;
	void OnCollisionStay(Collision collision){
		Vector3 sdf=new Vector3 (1,0,1);
		if(collision.contacts[0].otherCollider.CompareTag("cols")){
			x++;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			Debug.Log ("++");


		}

	}

}
