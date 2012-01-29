using UnityEngine;
using System.Collections;

public class EnemyBossController : MonoBehaviour {
	public GameObject primaryWeapon1;
	public GameObject primaryWeapon2;
	public GameObject secondaryWeapon;
	private PlayerWeapon actualPrimaryWeapon1;
	private PlayerWeapon actualPrimaryWeapon2;
	private PlayerWeapon actualSecondaryWeapon;

	private bool firingPrimary;
	public float primaryFireInterval = 2.0f;
	private float primaryFireTimer;
	public int primaryFireCycle = 12;
	private int primaryFireCount;
	public float secondaryFireInterval = 1.0f;
	private float secondaryFireTimer;
	public int secondaryFireCycle = 4;
	private int secondaryFireCount;

	public float health = 10.0f;

	public GameObject gateBulletKiller;
	private Collider gateBulletCollider;

	void Start () 
	{
		// Set up weapons
		actualPrimaryWeapon1 = ((PlayerWeapon)primaryWeapon1.GetComponent("PlayerWeapon"));
		actualPrimaryWeapon2 = ((PlayerWeapon)primaryWeapon2.GetComponent("PlayerWeapon"));
		actualSecondaryWeapon = ((PlayerWeapon)secondaryWeapon.GetComponent("PlayerWeapon"));
		
		// Set up counters
		primaryFireTimer = 0.0f;
		primaryFireCount = 0;
		secondaryFireTimer = 0.0f;
		secondaryFireCount = 0;
		firingPrimary = true;

		gateBulletCollider = (Collider)gateBulletKiller.GetComponent("Collider");
	}
	
	void Update () 
	{
		if (firingPrimary) {
			if (primaryFireTimer >= primaryFireInterval) {
				primaryFireTimer -= primaryFireInterval;
				actualPrimaryWeapon1.Fire(transform.position, Vector3.left, transform.rotation);
				actualPrimaryWeapon2.Fire(transform.position, Vector3.left, transform.rotation);
				primaryFireCount++;
				if (primaryFireCount >= primaryFireCycle) {
					firingPrimary = false;
					primaryFireCount = 0;
					OpenGates();
				}
			}
			primaryFireTimer += Time.deltaTime;
		} else {
			if (secondaryFireTimer >= secondaryFireInterval) {
				secondaryFireTimer -= secondaryFireInterval;
				actualSecondaryWeapon.Fire(transform.position, Vector3.left, transform.rotation);
				secondaryFireCount++;
				if (secondaryFireCount >= secondaryFireCycle) {
					firingPrimary = true;
					secondaryFireCount = 0;
					CloseGates();
				}
			}
			secondaryFireTimer += Time.deltaTime;
		}
	}

	void OpenGates() {
		gateBulletCollider.enabled = false;
	}
	
	void CloseGates() {
		gateBulletCollider.enabled = true;
	}

	void OnTriggerEnter(Collider other) {
		print("Trigger");
		if (other.gameObject.layer == 9) { // Player bullet
			print("Lose health");
			Destroy(other.gameObject);
			health--;
			if (health <= 0) {
				// Kill the boss!
				Destroy(gameObject);
			}
		}
	}
}
