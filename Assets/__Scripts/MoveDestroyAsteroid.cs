using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDestroyAsteroid : MonoBehaviour {
	Vector2 direction;
	public GameObject[] spawnPrefabs;
	public GameObject[] prefabClone;
	public GameObject explosion1;
	public GameObject explosion2;

	Vector3 scale1 = new Vector3 (3.5f, 3.5f, 3.5f);
	Vector3 scale2 = new Vector3 (2f, 2f, 2f);
	float speed = 0.1f;
	// Use this for initialization
	void Start () {
		if (transform.localScale == scale1)
			speed = 0.1f;
		else if (transform.localScale == scale2)
			speed = 0.15f;
		else
			speed = 0.2f;

		float x = Random.Range(0, 10);
		float y = Random.Range(0, 10);
		direction = new Vector2 (x, y);
		direction.Normalize();
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		transform.Translate(direction.x * speed, direction.y * speed, 0);
		transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
		transform.Rotate (direction * speed * 8);
	}

	void Rotate(){
		transform.Rotate (direction);
	}

	void Spawn(){
		//Small asteroids are worth 200 points
		GameState.score += 100;
		Vector3 position = new Vector3 (transform.position.x, transform.position.y, 0);
		prefabClone [0] = Instantiate (spawnPrefabs [0], position, Quaternion.Euler (0, 0, 0)) as GameObject;
		prefabClone [1] = Instantiate (spawnPrefabs [1], position, Quaternion.Euler (0, 0, 0)) as GameObject;
		prefabClone [2] = Instantiate (spawnPrefabs [2], position, Quaternion.Euler (0, 0, 0)) as GameObject;

		if(transform.localScale == new Vector3(3.5f, 3.5f, 3.5f)){
			//Medium asteroids are worth 150 points
			GameState.score -= 50;
			prefabClone [0].transform.localScale += new Vector3(1f, 1f, 1f);
			prefabClone [1].transform.localScale += new Vector3(1, 1, 1);
			prefabClone [2].transform.localScale += new Vector3(1, 1, 1);
		}
	}

	void OnCollisionEnter (Collision col)
	{
		float random = Random.Range (0.0f, 1.0f);
		//Increment score when bullet destroys asteroid
		if(col.gameObject.name == "Bullet(Clone)")
		{
			if(random <.5)
				explosion1 = Instantiate (explosion1, transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			else
				explosion2 = Instantiate (explosion2, transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			//Large asteroids are worth 100 points
			GameState.score += 100;
			Destroy(gameObject);
			if (transform.localScale == scale1 || transform.localScale == scale2) {
				Destroy (gameObject);
				Spawn ();
			}
		}
		//Score remains the same when ship hits asteroid
		else if(col.gameObject.name == "PlayerShip" )
		{
			if(random <.5)
				explosion1 = Instantiate (explosion1, transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			else
				explosion2 = Instantiate (explosion2, transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			int score = GameState.score;
			Destroy(gameObject);
			if (transform.localScale == scale1 || transform.localScale == scale2) {
				Destroy (gameObject);
				Spawn ();
				GameState.score = score; // score remains unaffected
			}
		}
	}
}