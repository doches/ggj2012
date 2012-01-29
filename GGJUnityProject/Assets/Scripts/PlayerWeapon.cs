using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour 
{
	public Vector3 spawnOffset;
	public float speed = 500.0f;
	public float reloadTime = 0.25f;
	private float idleTime;
	private bool weaponCanFire;
	public GameObject bulletPrefab;

	void Start()
	{
		weaponCanFire = true;
		idleTime = 0.0f;
	}

	void Update() {
		idleTime += Time.deltaTime;
		if (!weaponCanFire && idleTime >= reloadTime) {
			weaponCanFire = true;
		}
	}
	
	public bool CanFire()
	{
		return weaponCanFire;
	}

	public virtual void SpawnBullet(Vector3 origin, Vector3 direction, Quaternion rotation) {
		Vector3 bulletPosition = origin + spawnOffset;
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, rotation);
		Rigidbody rigidbody = (Rigidbody)bullet.GetComponent("Rigidbody");
		if (rigidbody) {
			rigidbody.AddForce(direction * speed);
		}
	}

	public void Fire(Vector3 origin, Vector3 direction, Quaternion rotation)
	{
		if (weaponCanFire) {
			SpawnBullet(origin, direction, rotation);

			weaponCanFire = false;
			idleTime = 0.0f;
		}
	}

}