using UnityEngine;
using System.Collections;

public class KillCollidingObjects : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}
