using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour {
	
	// Shoot a bullet every N seconds
	public float reloadInterval = 2.0f;
	
	// Bullet to shoot
	public GameObject bulletPrefab;
	
	// How long until we next shoot
	protected float intervalRemaining;
	
	/// <summary>
	/// Backing field for Active property
	/// </summary>
	public bool isActive = false;
	
	/// <summary>
	/// Is this shooter active (shooting)?
	/// </summary>
	public bool Active {
		get { return isActive; }
		set {
			isActive = value;
			intervalRemaining = reloadInterval;
		}
	}

	// Use this for initialization
	public virtual void Start () {
		isActive = false;
		intervalRemaining = reloadInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive||true) {
			if (intervalRemaining > 0.0f) {
				intervalRemaining -= Time.deltaTime;
			} else {
				// Shoot
				Shoot();
				intervalRemaining = this.reloadInterval;
			}
		}
	}
	
	public virtual void Shoot() {
		GameObject bullet = (GameObject)Instantiate(bulletPrefab,this.transform.position,Quaternion.identity);
		bullet.rigidbody.AddForce(new Vector3(-1.0f, 0.0f, 0.0f)*100);
	}
}
