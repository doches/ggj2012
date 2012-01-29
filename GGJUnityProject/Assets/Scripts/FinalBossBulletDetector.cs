using UnityEngine;
using System.Collections;

public class FinalBossBulletDetector : MonoBehaviour {

	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 9) { // Player bullets
			((FinalBoss)transform.parent.gameObject.GetComponent("FinalBoss")).BulletDetected(other.gameObject.transform.position - transform.position);
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.gameObject.layer == 9) { // Player bullets
			((FinalBoss)transform.parent.gameObject.GetComponent("FinalBoss")).BulletDetected(new Vector3(0, 0, 0));
		}
	}

}
