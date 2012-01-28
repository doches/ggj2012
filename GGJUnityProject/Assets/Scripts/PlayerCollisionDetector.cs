using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision) {
		// Destroy the object that hit us
		Destroy(collision.gameObject);
	}
}
