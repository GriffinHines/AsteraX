using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTrail : MonoBehaviour {
	
	ParticleSystem system;
	public float lifeTime = 2;
	// Use this for initialization
	void Start () {
		Invoke("DestroyMe", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void DestroyMe()
	{
		Destroy(gameObject);
	}
}
