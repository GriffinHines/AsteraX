using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipExhaustDown : MonoBehaviour {
	// Use this for initialization
	ParticleSystem system;
	Vector3 lastPosition;
	void Start () {
		system = GetComponent<ParticleSystem> ();
	}

	// Update is called once per frame
	void Update () {
		//Pin emitter to ship
		if(GameObject.Find("PlayerShip") != null)
			transform.position = GameObject.Find ("PlayerShip").transform.position;
		Vector3 yz = new Vector3(0f,-1.5f,0.5f);
		transform.position += yz;

		//Activate on user input
		float aX = CrossPlatformInputManager.GetAxis("Horizontal");
		float aY = CrossPlatformInputManager.GetAxis("Vertical");

		if (aX == 0 && aY > 0) {
			if(!system.isEmitting)
				system.Play ();
		} else {
			system.Stop ();
		}
	}
}
