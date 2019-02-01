using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSpriteToFitOthoCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		float camHeight = Camera.main.orthographicSize * 2;
		Vector2 camSize = new Vector2 (Camera.main.aspect * camHeight, camHeight);
		Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

		Vector2 scale = transform.localScale;
		if (camSize.x >= camSize.y)
			scale *= camSize.x / spriteSize.x;
		else 
			scale *= camSize.y / spriteSize.y;

		transform.position = new Vector3(0, 0, 3);
		transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
