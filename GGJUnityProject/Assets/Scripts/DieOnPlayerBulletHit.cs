using UnityEngine;
using System.Collections;

public class DieOnPlayerBulletHit : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name.Equals("Bullet(Clone)")) {
			// Die
			Destroy(this.gameObject);
			// Also destroy the player's bullet
			Destroy(other.gameObject);
		}
	}
}
