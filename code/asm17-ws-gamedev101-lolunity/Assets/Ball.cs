using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody rb;
	// Use this for initialization

	public GameController gc;
	void Start () 
	{
		rb = rb ?? GetComponent<Rigidbody>();
		Initialize();
	}

	public void Initialize()
	{
		transform.position = Vector3.zero;
		
		rb.velocity = new Vector3(
			(Random.Range(0, 1) == 0 ? -1 : 1),
			(Random.Range(0, 1) == 0 ? -1 : 1),
			0f) * 2f;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Initialize();
		}	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			Paddle p = other.GetComponent<Paddle>();

			float yDisplacement = Random.Range(0f, 1f);

			rb.velocity = -new Vector3(
				rb.velocity.x, 
				rb.velocity.y + (p.goingUp ? -yDisplacement : yDisplacement),
				0);

			rb.velocity *= Random.Range(0.8f, 1.2f);

			Debug.Log(rb.velocity);
		}
		else if (other.tag == "Bounds")
		{
			rb.velocity = new Vector3(
				rb.velocity.x,
				-rb.velocity.y,
				0f);
		}
		else if (other.tag == "score_left")
		{
			Debug.Log("Colided left");
			
			if(gc.leftpaddle.AddScore("left"))
			{
				Initialize();	
			} 
		}
		else if (other.tag == "score_right")
		{
			Debug.Log("Colided right");
			if(gc.rightpaddle.AddScore("right"))
			{
				Initialize();
			}
		}
	}
}
