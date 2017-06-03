using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	public TextMesh tm;
	public int score = 0;
    public float speed = 1f;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

	public bool goingUp = false;

	public GameController gc;
    void Start()
    {
		gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		tm = tm ?? GetComponentInChildren<TextMesh>();
		tm.text = score.ToString();
    }

	public bool AddScore(string _side)
	{
		score++;
		tm.text = score.ToString();
		if (score == gc.winScore)
		{
			gc.gameovertext.gameObject.SetActive(true);
			gc.gameovertext.text = string.Format("{0} player wins!", _side);
			gc.gameOver = true;
			return false;
		}
		else return true;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
        {
            transform.position += (Vector3.up * gc.paddleSpeed) * Time.deltaTime;
            if (Mathf.Max(transform.position.y) > gc.yMax)
            {
                transform.position = new Vector3(transform.position.x, gc.yMax, transform.position.z);
            }
			goingUp = true;
        }
        else if (Input.GetKey(downKey))
        {
            transform.position += (Vector3.down * gc.paddleSpeed) * Time.deltaTime;

            if (Mathf.Max(transform.position.y) > gc.yMax)
            {
                transform.position = new Vector3(transform.position.x, -gc.yMax, transform.position.z);
            }
			goingUp = false;
        }

    }
}
