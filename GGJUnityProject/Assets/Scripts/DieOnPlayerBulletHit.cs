using UnityEngine;
using System.Collections;

public class DieOnPlayerBulletHit : MonoBehaviour {
	void Update() {
		
	}
	
	void Start() {
		
	}
	
	void OnTriggerEnter(Collider other) {
		print("[DieOnPlayerBulletHit] " + other.name);
		Destroy(this.gameObject);
	}
}
