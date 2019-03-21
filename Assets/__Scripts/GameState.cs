using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
	public static float jumps = 3f;
	public static int score = 0;
	public static int highScore = 0;
	public Text textRight;
	public Text textLeft;
	public Text textMiddle;

	// Use this for initialization
	void Start () {
		textLeft = GameObject.Find("Jumps").GetComponent<Text>();
		textRight = GameObject.Find("Score").GetComponent<Text>();
		textMiddle = GameObject.Find("HighScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (score > highScore) {
			highScore = score;
		}
		textRight.text = score.ToString();
		textLeft.text = jumps.ToString();
		textMiddle.text = highScore.ToString ();
	}
}