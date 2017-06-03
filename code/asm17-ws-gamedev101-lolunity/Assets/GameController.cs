using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public TextMesh gameovertext;
	public Paddle leftpaddle;
	public Paddle rightpaddle;
	
	public bool gameOver = false;
	public int winScore = 10;
	public float paddleSpeed = 5;
	public float xMax = 5;
	public float yMax = 5;

	 /// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		gameovertext.gameObject.SetActive(false);
	}

	public void RestartGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (gameOver && Input.GetKeyDown(KeyCode.Space))
		{
			RestartGame();
		}


		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
