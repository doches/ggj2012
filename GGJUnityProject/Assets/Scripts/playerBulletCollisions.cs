using UnityEngine;
using System.Collections;

public class playerBulletCollisions : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) 
	{
		
		print(other.gameObject.name);
		if (other.gameObject.name.Equals("SpazBullet(Clone)") == false)
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		
		
	}
}
