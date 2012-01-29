using UnityEngine;
using System.Collections;

public class PrePathPositioningWidget : MonoBehaviour 
{
	public string PathName = "SlantMiddle";
	public float SpeedOnPath = 5.0f;
	
	protected bool isOnPath = false;
	protected float SpeedBeforePath = 0.1f;
	
	// Initialises the pre-path scrolling vector
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < 20)
		{
			if (!isOnPath) {
				// Attach to a path.
				isOnPath = true;
				FollowPath pathFollower = (FollowPath)(this.gameObject.AddComponent("FollowPath"));
				pathFollower.KillOnEnd = true;
				pathFollower.pathName = PathName;
				pathFollower.speed = SpeedOnPath;
				pathFollower.autostart = true;
				if (gameObject.name.Equals("Dolphin(Clone)")) {
					pathFollower.lookWhereYoureGoing = true;
				}
				if (gameObject.name.Equals("LittleChopperOrThePeriscopeThatCould(Clone)")) 
				{
					transform.Rotate(0, 180, 0);
				}
			}
		} else {
			transform.position = new Vector3(transform.position.x-SpeedBeforePath, transform.position.y, transform.position.z);
		}
	}
}

