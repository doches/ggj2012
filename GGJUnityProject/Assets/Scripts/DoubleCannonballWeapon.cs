using UnityEngine;
using System.Collections;

public class DoubleCannonballWeapon : PlayerWeapon
{
	public Vector3 spawnOffset2;

	public override void SpawnBullet(Vector3 origin, Vector3 direction, Quaternion rotation) {
		Vector3 bulletPosition = origin + spawnOffset;
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, rotation);
		Rigidbody rigidbody = (Rigidbody)bullet.GetComponent("Rigidbody");
		if (rigidbody) {
			rigidbody.AddForce(direction * speed);
		}

		bulletPosition = origin + spawnOffset2;
		bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, rotation);
		rigidbody = (Rigidbody)bullet.GetComponent("Rigidbody");
		if (rigidbody) {
			rigidbody.AddForce(direction * speed);
		}
	}
}