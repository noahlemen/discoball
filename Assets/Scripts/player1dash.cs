﻿using UnityEngine;
using System.Collections;

public class player1dash : MonoBehaviour {
	
	bool dash = true;
	public float dashSpeed = 25f;
	public float dashLength = 0.05f;
	
	void Update(){
		
		GetComponent<controller>().enabled = true;
		
		if (dash) {
			
			if (Input.GetButtonDown("Dash 1")) StartCoroutine("Dash");
			
		}else{
			
			// disable controller if mid-dash
			GetComponent<controller>().enabled = false;
			
		}
		
	}
	
	IEnumerator Dash(){
		rigidbody.velocity = Vector3.zero;
		dash = false;
    	rigidbody.AddForce(transform.forward * dashSpeed, ForceMode.VelocityChange);
    	yield return new WaitForSeconds(dashLength);
		rigidbody.AddForce( -rigidbody.velocity*dashSpeed/2, ForceMode.Acceleration );
		dash = true;
	}
}
