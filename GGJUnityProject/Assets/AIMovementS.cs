using UnityEngine;
using System.Collections;

public class AIMovementS : MonoBehaviour 
{
	public float scrollSpeedY;
	public float scrollSpeedX;
	public float maxDistance;
	public float initialPosition;
	public string direction;
	
	
	// Use this for initialization
	void Start () 
	{
		scrollSpeedX = 0.1f;
		scrollSpeedY = 0.2f;
		maxDistance = 3;
		initialPosition = transform.position.y;
		direction = "down";	
	}
	
	void scroll()
	{
		float xPosition = transform.position.x;
		xPosition -= scrollSpeedX;
		transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
	}
	
	void doSMovment()
	{
		float yPosition = transform.position.y;
		
		if (direction == "down")
		{
			if(transform.position.y >= initialPosition - maxDistance)
			{
				yPosition -= scrollSpeedY;
				transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
			}
			else
			{
				direction = "up";
			}
		}
		else if (direction == "up")
		{
			if(transform.position.y <= initialPosition + maxDistance)
			{
				yPosition += scrollSpeedY;
				transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
			}
			else
			{
				direction = "down";
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//GameObject.FindWithTag("Player").transform.position;
		scroll();
		doSMovment();
	}
}

