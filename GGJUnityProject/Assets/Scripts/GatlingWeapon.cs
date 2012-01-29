using UnityEngine;
using System.Collections;

public class GatlingWeapon : PlayerWeapon
{
	public float angle = 15.0f;

	public override void SpawnBullet(Vector3 origin, Vector3 direction, Quaternion rotation) {
		Vector3 bulletPosition = origin + spawnOffset;
		
		// First bullet goes in the indicated direction
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, rotation);
		Rigidbody rigidbody = (Rigidbody)bullet.GetComponent("Rigidbody");
		if (rigidbody) {
			rigidbody.AddForce(direction * speed);
		}
	
		// Second bullet goes up by the indicated angle
		Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
		bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition,
			rotation * quat);
		rigidbody = (Rigidbody)bullet.GetComponent("Rigidbody");
		if (rigidbody) {
			rigidbody.AddForce((quat * direction) * speed);
		}

		// Third bullet goes down by the indicated angle
		quat = Quaternion.AngleAxis(-angle, Vector3.forward);
		bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition,
			rotation * quat);
		rigidbody = (Rigidbody)bullet.GetComponent("Rigidbody");
		if (rigidbody) {
			rigidbody.AddForce((quat * direction) * speed);
		}
	}
}