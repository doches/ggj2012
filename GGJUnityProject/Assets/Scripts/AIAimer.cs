using UnityEngine;
using System.Collections;

public class AIAimer : MonoBehaviour 
{
	public string direction;
	public float scrollSpeedX;
	
	// Use this for initialization
	void Start () 
	{
		scrollSpeedX = 0.03f;	
	}
	
	void scroll()
	{
		float xPosition = transform.position.x;
		xPosition -= scrollSpeedX;
		transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
	}
	
    public float calculateAngle()
    {
		float angle = 0;
		Vector3 playersPosition = new Vector3(GameObject.FindWithTag("Player").transform.position.x, 
		                      GameObject.FindWithTag("Player").transform.position.y, 
		                      GameObject.FindWithTag("Player").transform.position.z);

		
		angle = Vector3.Angle(transform.position, playersPosition);
        return angle;
		
    }
	
    public float calculateRelativeAngle(float angle)
    {	
        float relativeAngle;
		float orientation = transform.eulerAngles.z;

        //find the relative angle
        relativeAngle = angle - orientation;
   
        if(relativeAngle < 0)
        {
	        while(relativeAngle < 0)
	        {
		        relativeAngle = relativeAngle + 360;
	        }
        }
        else if(relativeAngle > 360)
        {
	        while(relativeAngle > 360)
	        {
		        relativeAngle = relativeAngle - 360;
	        }
        }
		
        return relativeAngle;
		
    }
	
	void aim()
	{
		float angle = calculateAngle();
		
		/*if(relativeAngle > 5 && relativeAngle <= 180)
		{
			transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - 5);
		}
		else if(relativeAngle > 180 && relativeAngle < 355)
		{
			transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + 5);
		}*/
		
		if (transform.eulerAngles.z > angle)
		{
			//transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z - Time.deltaTime);
		}
		else if (transform.eulerAngles.z < angle)
		{
			//transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Time.deltaTime);
		}
		
		//print (transform.eulerAngles.z + " a n " + angle);
		transform.eulerAngles = new Vector3(0, 0, angle - 11.25f);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		aim();
		//scroll();
	}
}
