using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipExhaustLeftUp : MonoBehaviour {
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
		Vector3 xz = new Vector3(-1.3f,1.3f,0.5f);
		transform.position += xz;

		//Activate on user input
		float aX = CrossPlatformInputManager.GetAxis("Horizontal");
		float aY = CrossPlatformInputManager.GetAxis("Vertical");

		if (aX > 0 && aY < 0) {
			if(!system.isEmitting)
				system.Play ();
		} else {
			system.Stop ();
		}
	}
}
