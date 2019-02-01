using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	float timeLeft = 1f;
	private int projectileSpeed = 8;

	Vector2 mousePos;
	Vector2 finalMousePos;
	float mousePosY, mousePosX;


	// Use this for initialization
	void Start () {
		mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		mousePosX = mousePos.x - transform.position.x;//gets the distance between ship and mouse position relative to screen
		mousePosY = mousePos.y - transform.position.y;//gets the distance between ship and mouse position relative to screen
		finalMousePos = new Vector2 (mousePosX, mousePosY);
		finalMousePos.Normalize ();
	}
	
	// Update is called once per frame
	void Update () {
		Destructor ();
		Direction ();
	}

	void Direction(){

		transform.Translate (finalMousePos.x * 0.1f * projectileSpeed, finalMousePos.y * 0.1f * projectileSpeed, 0);
	}

	void Destructor(){
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
			Destroy(gameObject);
	}

	void OnCollisionEnter ()
	{
		Destroy (gameObject);
	}
}
