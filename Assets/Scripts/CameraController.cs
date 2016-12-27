﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Public
	public Transform playerLocation;
	public float explosionViewTime = 3.0f;

	// Private
	TankController player;
	Vector3 explosionCamVector;
	float timeInExplosionCam = 0.0f;
	bool inProjectileMode = false;
	Rigidbody projectileRB;
	Vector3 chaseCameraSpot;
	Quaternion chaseCameraRot;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<TankController>();
		chaseCameraSpot = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player.liveProjectile != null) {
			// Camera for following projectile
			if (projectileRB == null){
				projectileRB = player.liveProjectile.GetComponent<Rigidbody>();	
			}
			if (projectileRB.velocity.magnitude > 3.0f) {
				chaseCameraSpot = player.liveProjectile.transform.position - projectileRB.velocity.normalized * 7.0f + Vector3.up * 3.0f;
				transform.LookAt(player.liveProjectile.transform.position + projectileRB.velocity.normalized * 7.0f);
			}

			inProjectileMode = true;
		} else {
			if (inProjectileMode) {
				timeInExplosionCam = explosionViewTime;
				explosionCamVector = transform.position;
				inProjectileMode = false;
			} // end if in projectile mode
			if (timeInExplosionCam > 0.0f) {
				timeInExplosionCam -= Time.deltaTime;
//				chaseCameraSpot = transform.position;
//				chaseCameraSpot = explosionCamVector + Vector3.up * 4.0f - player.transform.forward * 4.0f;
//				transform.LookAt (explosionCamVector);
//				chaseCameraRot = Quaternion.LookRotation(explosionCamVector - chaseCameraSpot);
			} else {  // This is standard aiming view
				chaseCameraSpot = playerLocation.position;
				transform.position = chaseCameraSpot; // this is the interrupt the smoothing while aiming
				transform.rotation = playerLocation.rotation;
			} // end if time in explosion cam greater than 0

		} // end if statement for if live projectile doesn't equal null
	} // end LateUpdate

	void FixedUpdate(){
		float springK = 0.94f;
		if (inProjectileMode) {
			transform.position = springK * transform.position + (1.0f - springK) * chaseCameraSpot;
		}


//		transform.rotation = Quaternion.Slerp (transform.rotation, chaseCameraRot, 0.4f);
	} // FixedUpdate
} // end Class
