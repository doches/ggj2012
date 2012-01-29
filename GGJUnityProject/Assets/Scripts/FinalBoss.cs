using UnityEngine;
using System.Collections;

public class FinalBoss : MonoBehaviour {
	public GameObject player;

	public float speed = 10f;
	public float evadeSpeed = 12f;
	public float evadeDuration = 0.3f; 
	public float postEvadeDuration = 0.3f; 

	private Vector3 target; // Relative to player origin
	private bool evading = false;
	private bool postEvading = false;
	private Vector3 evadeDirection = Vector3.zero;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (evading) {
			transform.position += evadeDirection * evadeSpeed * Time.deltaTime;
		} else {
			Vector3 targetDirection = (target + player.transform.position) - transform.position;
			targetDirection = Vector3.up * targetDirection.y;
			transform.position += targetDirection * speed * Time.deltaTime;
		}
		
		if (evading && timer >= evadeDuration) {
			timer -= evadeDuration;
			evading = false;
			postEvading = true;
		}
		if (postEvading && timer >= postEvadeDuration) {
			timer -= postEvadeDuration;
			postEvading = false;
		}
		timer += Time.deltaTime;
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
		if (!evading && !postEvading) {
			if (relativePosition.y > 0) {
				evading = true;
				evadeDirection = Vector3.down;
				timer = 0.0f;
			} else if (relativePosition.y < 0) {
				evading = true;
				evadeDirection = Vector3.up;
				timer = 0.0f;
			}
		}
	}

}
