using UnityEngine;
using System.Collections;

public class CannonballBullet : MonoBehaviour 
{
	public static bool CannonballBulletWentUp = false;
	public float magnitude = 1.0f;
	public float frequency = 2.0f;
	public float speed = 200.0f;

	private Vector3 startPosition;
	private float offset;

	void Start() {
		startPosition = transform.position;
		if (CannonballBulletWentUp) {
			offset = 3.14159f;
			CannonballBulletWentUp = false;
		} else {
			offset = 0;
			CannonballBulletWentUp = true;
		}
	}
	
	void Update() {
		transform.position = new Vector3(
			transform.position.x + speed * Time.deltaTime,
			startPosition.y + magnitude * Mathf.Sin(offset + frequency * (transform.position.x - startPosition.x) * 3.1415f / 180f),
			startPosition.z
		);
	}
}