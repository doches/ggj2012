using UnityEngine;
using System.Collections;

public class CollectablePart : MonoBehaviour {
	public GameObject attachment;
	private Vector3 attachmentPosition;
	private bool asleep;
	private bool attached;
	private bool attachedRotation;
	private float speed;
	public float acceleration = 0.2f;
	public float rotationDuration = 0.75f;
	private float rotationProgress;
	private Quaternion originRotation;
	

	void Start () {
		asleep = true;
		attached = false;
		// The attachment does not need to be a related object, so store its relative position
		attachmentPosition = attachment.transform.position - transform.position;
	}
	
	void Update () {
		GameObject player = GameObject.FindWithTag("Player");
		if (asleep) {
			// Spin in place
			transform.Rotate(new Vector3(10, 60, 60) * Time.deltaTime);
		} else  {
			if (!attached) {
				// Accelerate the object towards the player until its attachment is at the player position
				Vector3 target = player.transform.position;
				Vector3 origin = transform.position + attachmentPosition;
				Vector3 movement = target - origin;
				float distanceToMove = speed * Time.deltaTime;
				if (distanceToMove > movement.magnitude) {
					distanceToMove = movement.magnitude;
					attached = true;
					transform.parent = player.transform;
				}
				movement = movement.normalized * distanceToMove;
				transform.Translate(movement, Space.World);
				speed += acceleration;
			}
			if (!attachedRotation) {
				// Rotate it until it is upright and facing in.
				float rotationDelta = (1.0f / rotationDuration) * Time.deltaTime;
				rotationProgress += rotationDelta;
				if (rotationProgress > 1.0f) {
					rotationProgress = 1.0f;
					attachedRotation = true;
				}
				transform.rotation = Quaternion.Lerp(originRotation, Quaternion.identity, rotationProgress);
			}
		}
		if (attached && attachedRotation) {
			// We are now fully attached!
		}
	}
	
	void OnTriggerEnter(Collider other) {
		GameObject player = GameObject.FindWithTag("Player");
		if (other.gameObject == player) {
			// Wake up and be collected!
			asleep = false;
			originRotation = transform.rotation;
			rotationProgress = 0.0f;
		}
	}
}
