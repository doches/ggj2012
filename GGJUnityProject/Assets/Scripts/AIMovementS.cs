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
				
				// I know it's not a weapons officer, but imagine a tiny dude riding along inside the enemy, 
				// or even better, the entire crew of the Kirk-era Starship Enterprise. Weapons Officer dude's
				// functionality (in a Starfleet sense) is clearly encapsulated by the ShootingController class.
				//
				// K?
				ShootingController weaponsOfficer = (ShootingController)(this.gameObject.GetComponent("ShootingController"));
				if (weaponsOfficer != null) {
					weaponsOfficer.Active = true;
				}
			}
		} else {
			scroll();
		}
	}
}

