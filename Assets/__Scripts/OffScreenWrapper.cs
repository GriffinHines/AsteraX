using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenWrapper : MonoBehaviour {
	Renderer[] renderers;
	bool isWrappingX = false;
	bool isWrappingY = false;
	public float _xMax = 1.015f;
	public float _xMin = -0.015f;
	public float _yMax = 1.025f;
	public float _yMin = -0.025f;
	float objectSize = 0f;

	// Use this for initialization
	void Start () {
		renderers = GetComponentsInChildren<Renderer>();

		//Increase bounds for large asteroids to avoid clipping effect
		if (transform.localScale != new Vector3(1, 1, 1))
			objectSize = 0.1f; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Teleport ();
	}

	//Check if object is off screen
	bool CheckRenderers(){
		foreach (var renderer in renderers) {
			if (renderer.isVisible)
				return true;
	
		}
		return false;
	}

	//Screenwrap object
	void Teleport(){
		var viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
		bool isVisible = CheckRenderers();
		if (isVisible) {
			isWrappingX = false;
			isWrappingY = false;
		}
		if (isWrappingX && isWrappingY)
			return;

		var newPosition = transform.position;
		if (viewportPosition.x > _xMax + objectSize || viewportPosition.x < _xMin - objectSize) {
			newPosition.x = -transform.position.x * 0.99f;
			newPosition.y = -transform.position.y * 0.99f;
			isWrappingX = true;

		} 
		else if (viewportPosition.y > _yMax + objectSize || viewportPosition.y < _yMin - objectSize) {
			newPosition.x = -transform.position.x * 0.99f;
			newPosition.y = -transform.position.y * 0.99f;
			isWrappingY = true;
		}
		transform.position = newPosition;
	}
}
