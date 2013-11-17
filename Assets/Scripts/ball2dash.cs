﻿using UnityEngine;
using System.Collections;

public class ball2dash : MonoBehaviour {
	
	bool dash = true;
	public float dashSpeed = 25f;
	public float dashLength = 0.05f;
	public Transform ball;
	Vector3 ballDirection;
	
	void Update(){
		
		ballDirection = ball.position - transform.position;
		ballDirection = ballDirection.normalized;
		
		GetComponent<P2Controller>().enabled = true;
		
		if (dash) {
			
			if (Input.GetButtonDown("Dash 2")) StartCoroutine("Dash");
			
		}else{
			
			// disable controller if mid-dash
			GetComponent<P2Controller>().enabled = false;
			
		}
		
	}
	
	IEnumerator Dash(){
		rigidbody.velocity = Vector3.zero;
		dash = false;
		rigidbody.AddForce(ballDirection * dashSpeed, ForceMode.VelocityChange);
		yield return new WaitForSeconds(dashLength);
		rigidbody.AddForce( -rigidbody.velocity*dashSpeed/2, ForceMode.Acceleration );
		dash = true;
	}
}
