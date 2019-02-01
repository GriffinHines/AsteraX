using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
	// can ignore the update, it's just to make the coroutines get called for example
	void Update()
	{

		if (GameState.jumps <= 0)
		{
			Text i = GetComponent<Text> ();
			i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
			while (i.color.a < 1.0f)
			{
				i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime));
			}
		}			
	}
}