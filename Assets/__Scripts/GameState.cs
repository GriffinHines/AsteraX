using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
	public static float jumps = 3f;
	public static int score = 0;
	public Text textRight;
	public Text textLeft;

	// Use this for initialization
	void Start () {
		textLeft = GameObject.Find("Jumps").GetComponent<Text>();
		textRight = GameObject.Find("Score").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		textRight.text = score.ToString();
		textLeft.text = jumps.ToString();
	}
}