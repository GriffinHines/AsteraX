using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {
    private int speed = 9;
	private bool invincible = false;
	public GameObject[] spawnPrefab;
	public GameObject[] prefabClone;
    // Use this for initialization
    void Start () {
		transform.rotation = Quaternion.identity;
    }
    
    // Update is called once per frame
    void FixedUpdate () {
        Move();
    }
	void Update(){
		Fire();
	}

	void OnCollisionEnter (Collision col){
		if (col.gameObject.name != "Bullet(Clone)" && !invincible) {
			GameState.jumps -= 1;
			gameObject.SetActive(false);
			if(GameState.jumps > 0)
				Invoke("Respawn", 3);
		}
	}

	private void Respawn(){
		invincible = true;
		if (GameObject.Find ("Sphere7").tag == "on")
			transform.position = GameObject.Find ("Sphere7").transform.position;
		else if (GameObject.Find ("Sphere6").tag == "on")
			transform.position = GameObject.Find ("Sphere6").transform.position;
		else if (GameObject.Find ("Sphere11").tag == "on")
			transform.position = GameObject.Find ("Sphere11").transform.position;
		else if (GameObject.Find ("Sphere10").tag == "on")
			transform.position = GameObject.Find ("Sphere10").transform.position;
		else if (GameObject.Find ("Sphere3").tag == "on")
			transform.position = GameObject.Find ("Sphere3").transform.position;
		else if (GameObject.Find ("Sphere2").tag == "on")
			transform.position = GameObject.Find ("Sphere2").transform.position;
		else if (GameObject.Find ("Sphere8").tag == "on")
			transform.position = GameObject.Find ("Sphere8").transform.position;
		else if (GameObject.Find ("Sphere5").tag == "on")
			transform.position = GameObject.Find ("Sphere5").transform.position;
		else if (GameObject.Find ("Sphere12").tag == "on")
			transform.position = GameObject.Find ("Sphere12").transform.position;
		else if (GameObject.Find ("Sphere9").tag == "on")
			transform.position = GameObject.Find ("Sphere9").transform.position;
		else if (GameObject.Find ("Sphere1").tag == "on")
			transform.position = GameObject.Find ("Sphere1").transform.position;
		else {
			Respawn ();
			return;
		}
		gameObject.SetActive (true);
		Invoke ("NotInvincible", 1.5f);
	}

	private void Fire(){

		if (Input.GetMouseButtonDown(0)) {
			prefabClone [0] = Instantiate (spawnPrefab [0], transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
		}
	}

    private void Move()
    {
        //X axis movement
        var deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var newXPos = transform.position.x + deltaX;

        //Y axis movement
        var deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(newXPos, newYPos);

        int ySpeed = 10;
        int xSpeed = 10;

        //ROTATION RULES UP AND DOWN
  
		//limit up
        if (transform.localEulerAngles.x >= 29 && Input.GetKey("up"))
            ySpeed = 0;

		//limit down
        else if ((transform.localEulerAngles.x <= 330 && transform.localEulerAngles.x > 1) && Input.GetKey("down"))
            ySpeed = 0;
		
		//tilt back up
		else if (!Input.GetKey("down") && (transform.localEulerAngles.x >= 300))
        {
            transform.Rotate(10, 0, 0, Space.Self);
            if (transform.localEulerAngles.x < 30 && transform.localEulerAngles.x >= 0) { 
                ySpeed = 10;
            }
        }

		//tilt back down
		else if (!Input.GetKey("up") && transform.localEulerAngles.x <= 31 && !(transform.localEulerAngles.x < 1) )
		{
			transform.Rotate(-10, 0, 0, Space.Self);
			if (transform.localEulerAngles.x < 8 && transform.localEulerAngles.x >= 0) { 	
				//transform.Rotate(10, 0, 0, Space.Self);
				ySpeed = 10;
			}
		}

		//reenable tilt down if up and down are pressed at the same time
		if (Input.GetKey ("down") && transform.localEulerAngles.x >= 29 && transform.localEulerAngles.x <= 31) {
			transform.Rotate(-30, 0, 0, Space.Self);
			ySpeed = 10;
		}
		//reenable tilt up if up and down are pressed at the same time
		else if (Input.GetKey ("up") && transform.localEulerAngles.x >= 300) {
			transform.Rotate(30, 0, 0, Space.Self);
			ySpeed = 10;
		}
		//ROTATION RULES LEFT AND RIGHT

		//limit left
		if (transform.localEulerAngles.y >= 29 && Input.GetKey("left"))
			xSpeed = 0;

		//limit right
		else if ((transform.localEulerAngles.y <= 330 && transform.localEulerAngles.y > 1) && Input.GetKey("right"))
			xSpeed = 0;

		//tilt back left
		else if (!Input.GetKey("right") && (transform.localEulerAngles.y >= 300))
		{
			transform.Rotate(0, 10, 0, Space.World);
			if (transform.localEulerAngles.y < 30 && transform.localEulerAngles.y >= 0) { 
				xSpeed = 10;
			}
		}

		//tilt back right
		else if (!Input.GetKey("left") && transform.localEulerAngles.y <= 31 && !(transform.localEulerAngles.y < 1) )
		{
			transform.Rotate(0, -10, 0, Space.World);
			if (transform.localEulerAngles.y < 8 && transform.localEulerAngles.y >= 0) { 	
				xSpeed = 10;
			}
		}

		//reenable tilt right if right and left are pressed at the same time
		if (Input.GetKey ("right") && transform.localEulerAngles.y >= 29 && transform.localEulerAngles.y <= 31) {
			transform.Rotate(0, -30, 0, Space.World);
			xSpeed = 10;
		}
		//reenable tilt left if right and left are pressed at the same time
		else if (Input.GetKey ("left") && transform.localEulerAngles.y >= 300) {
			transform.Rotate(0, 30, 0, Space.World);
			xSpeed = 10;
		}
			
		if(!Input.GetKey ("left") && !Input.GetKey ("right") && !Input.GetKey ("up") && !Input.GetKey ("down"))
			transform.rotation = Quaternion.identity;

        transform.Rotate(0, -Input.GetAxisRaw("Horizontal") * xSpeed, 0, Space.World);

        transform.Rotate(Input.GetAxisRaw("Vertical") * ySpeed, 0, 0, Space.Self);

    }
	void NotInvincible(){
		invincible = false;
	}
  
}
