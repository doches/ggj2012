using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		// Destroy the object that hit us
		//Destroy(other.gameObject);
	}
}
