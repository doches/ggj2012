using UnityEngine;
using System.Collections;

public class TargetingShootingController : ShootingController {
	
	// The player object, to target
	protected GameObject player;
	
	public override void Start() {
		base.Start();
		
		player = GameObject.FindWithTag("Player");
	}
	
	public override void Shoot() {
		GameObject bullet = (GameObject)Instantiate(bulletPrefab,this.transform.position,Quaternion.identity);
		bullet.rigidbody.AddForce(new Vector3(-1.0f, Random.Range(-1.0f, 1.0f), 0.0f)*100);
	}
}
