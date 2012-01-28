using UnityEngine;
using System.Collections;

public class PlayerWeaponControls : MonoBehaviour 
{
	float weaponReloadTime = 0.25f;
	float weaponIdleTime;
	public GameObject bulletPrefab;
	public float speed = 500.0f;

	// Use this for initialization
	void Start () 
	{
		weaponIdleTime = Time.time;
	}
	
	void fireWeapon()
	{
		Vector3 bulletPosition = new Vector3(transform.position.x + 0.33f, transform.position.y+0.2f, transform.position.z);
		GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletPosition, transform.rotation);
		bullet.rigidbody.AddForce(new Vector3(1.0f, 0.0f, 0.0f) * speed);
	}
	
	void checkToFire()
	{
		if(Time.time - weaponIdleTime > weaponReloadTime)
		{
			fireWeapon();
			weaponIdleTime = Time.time;
		}
	}	
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("space") == true)
		{
			checkToFire();
		}

	}
}
