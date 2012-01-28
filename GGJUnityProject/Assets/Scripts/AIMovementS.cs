using UnityEngine;
using System.Collections;

public class AIMovementS : MonoBehaviour 
{
	public float scrollSpeedX = 0.1f;
	
	protected bool hasAttachedShootingBehaviour = false;
	
	void scroll()
	{
		float xPosition = transform.position.x;
		xPosition -= scrollSpeedX;
		transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < 20)
		{
			if (!hasAttachedShootingBehaviour) {
				hasAttachedShootingBehaviour = true;
				FollowPath path = (FollowPath)(this.gameObject.AddComponent("FollowPath"));
				path.pathName = "SlantMiddle";
				path.speed = 12.5f;
				path.autostart = true;
				((ShootingController)(this.gameObject.GetComponent("ShootingController"))).Active = true;
			}
		} else {
			scroll();
		}
	}
}

