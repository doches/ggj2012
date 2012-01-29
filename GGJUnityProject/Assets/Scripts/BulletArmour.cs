using UnityEngine;
using System.Collections;

public class BulletArmour : MonoBehaviour {
	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.layer == 9) { // Player bullets
			Destroy(other.gameObject);
		} else if (other.gameObject.layer == 14) { // Player
			// Player death
			Destroy(other.gameObject);
		}
	}
}
