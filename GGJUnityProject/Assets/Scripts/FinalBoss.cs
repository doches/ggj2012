using UnityEngine;
using System.Collections;

public class FinalBoss : MonoBehaviour {

	public FinalBossCheat finalBossCheatComponent;
	public GameObject player;

	public float speed = 0;
	public float evadeSpeed = 0;

	private Vector3 target; // Relative to player origin
	private bool evade = false;
	private Vector3 evadeDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		// FIXME: Think every few seconds
		if (evade) {
			transform.position += evadeDirection * evadeSpeed * Time.deltaTime;
		} else {
			Vector3 targetDirection = (target + player.transform.position) - transform.position;
			targetDirection = Vector3.up * targetDirection.y;
			transform.position += targetDirection * speed * Time.deltaTime;
		}
	}
	
	void StayOnTarget() {
		// Pick an accessible target to shoot at (hard code the list of accessible targets--as returned by the BossCheat component)
		if (target == null) {
			// FIXME: pick a target that's not the middle
			target = new Vector3(0, 0, 0);
		}
		
		// big wide collider looking to the left of the enemy
		// tall, triggering on contact with player bullets and play. On trigger with bullets,
		// take evasive action up or down.
	}
	
	public void BulletDetected(Vector3 relativePosition) {
		if (relativePosition.y > 0) {
			evade = true;
			print("Evading downwards");
			evadeDirection = Vector3.down;
		} else if (relativePosition.y < 0) {
			evade = true;
			evadeDirection = Vector3.up;
			print("Evading upwards");
		} else {
			evade = false;
			print("Not downwards");
		}
	}

}
