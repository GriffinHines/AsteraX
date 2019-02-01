using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnPoints : MonoBehaviour {
	public static bool[] _spheres;

	// Use this for initialization
	void Start () {
		Renderer rend = GetComponent<Renderer>();
		rend.enabled = false;
		gameObject.tag = "on";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		gameObject.tag = "off";
		Invoke("Reenable", 3);
	}

	void Reenable(){
		gameObject.tag = "on";
	}
}