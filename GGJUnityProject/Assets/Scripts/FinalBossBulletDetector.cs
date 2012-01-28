using UnityEngine;
using System.Collections;

public class FinalBossBulletDetector : MonoBehaviour {

	public void OnTriggerEnter(Collider other) {
	((FinalBoss)transform.parent.gameObject.GetComponent("FinalBoss")).BulletDetected(other.gameObject.transform.position - transform.position);
	}

	public void OnTriggerExit(Collider other) {
	((FinalBoss)transform.parent.gameObject.GetComponent("FinalBoss")).BulletDetected(new Vector3(0, 0, 0));
	}

}
