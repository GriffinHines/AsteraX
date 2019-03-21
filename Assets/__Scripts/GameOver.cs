using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public Button restart;
	public GameObject gameOver;
	private HighScore playerPref;
	// can ignore the update, it's just to make the coroutines get called for example
	void Start(){
		restart.gameObject.SetActive(false);
		restart.onClick.AddListener(TaskOnClick);
	}
	void Update()
	{

		if (GameState.jumps <= 0)
		{
			gameOver.SetActive(true);
			restart.gameObject.SetActive(true);
		}			
	}

	void TaskOnClick(){
		gameOver.SetActive(false);
		restart.gameObject.SetActive(false);
		GameState.jumps = 3;
		GameState.score = 0;
		SceneManager.LoadScene(0);
	}
}