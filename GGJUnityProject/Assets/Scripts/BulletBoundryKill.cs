using UnityEngine;
using System.Collections;

public class BulletBoundryKill : MonoBehaviour 
{
	float minXPosition = -16;
	float maxXPosition = 20;
	
	float minYPosition = -18;
	float maxYPosition = 18;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x < minXPosition || transform.position.x > maxXPosition)
		{
			Destroy(gameObject);
		}
		if(transform.position.y < minYPosition || transform.position.y > maxYPosition)
		{
			Destroy(gameObject);
		}
	}
}
