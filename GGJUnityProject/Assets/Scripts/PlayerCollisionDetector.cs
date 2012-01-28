using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider collide) {
		// Destroy the object that hit us
		Destroy(collide.gameObject);
	}
}
