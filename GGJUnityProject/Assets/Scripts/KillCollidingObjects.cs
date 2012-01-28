using UnityEngine;
using System.Collections;

public class KillCollidingObjects : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		Destroy(collision.gameObject);
	}
}
