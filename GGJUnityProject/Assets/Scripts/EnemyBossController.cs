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
	private bool firingSecondary;
	public float primaryFireInterval = 2.0f;
	private float primaryFireTimer;
	public float secondaryFireInterval = 1.0f;
	private float secondaryFireTimer;

	public float health = 10.0f;

	public GameObject gateBulletKiller;
	private Collider gateBulletCollider;

	private float timer;
	private GateOpener gateOpener;
	private bool gatesOpening = false;
	private bool gatesOpened = false;
	private bool gatesClosing = false;

	public float gateOpenedTime = 5.0f;
	public float gateClosedTime = 12.0f;
	public float gateAnimateTime = 2.0f;

	void Start () 
	{
		// Set up weapons
		actualPrimaryWeapon1 = ((PlayerWeapon)primaryWeapon1.GetComponent("PlayerWeapon"));
		actualPrimaryWeapon2 = ((PlayerWeapon)primaryWeapon2.GetComponent("PlayerWeapon"));
		actualSecondaryWeapon = ((PlayerWeapon)secondaryWeapon.GetComponent("PlayerWeapon"));
		
		// Set up counters
		primaryFireTimer = 0.0f;
		secondaryFireTimer = 0.0f;
		firingPrimary = true;

		gateOpener = (GateOpener)(gameObject.GetComponent("GateOpener"));

		gateBulletCollider = (Collider)gateBulletKiller.GetComponent("Collider");
	}
	
	void Update () 
	{
		timer += Time.deltaTime;
		if (gatesOpened && timer >= gateOpenedTime) {
			timer -= gateOpenedTime;
			gatesOpened = false;
			gatesClosing = false;
			gateOpener.closeGates();
			gateBulletCollider.enabled = true;
			
			// switch weapon back to cannonballs
			firingPrimary = true;
			firingSecondary = false;
		} else if (gatesOpening && timer >= gateAnimateTime) {
			timer -= gateAnimateTime;
			gatesOpening = false;
			gatesOpened = true;

			// Switch weapon to gatling
			firingPrimary = false;
			firingSecondary = true;
		} else if (gatesClosing && timer >= gateAnimateTime) {
			timer -= gateAnimateTime;
			gatesClosing = false;
			firingPrimary = true;
			firingSecondary = false;
		} else if (timer >= gateClosedTime) {
			timer -= gateClosedTime;
			gatesOpening = true;
			gateOpener.openGates();
			firingPrimary = false;
			firingSecondary = false;
			gateBulletCollider.enabled = false;
		}

		if (firingPrimary) {
			if (primaryFireTimer >= primaryFireInterval) {
				primaryFireTimer -= primaryFireInterval;
				actualPrimaryWeapon1.Fire(transform.position, Vector3.left, transform.rotation);
				actualPrimaryWeapon2.Fire(transform.position, Vector3.left, transform.rotation);
			}
			primaryFireTimer += Time.deltaTime;
		} else {
			if (secondaryFireTimer >= secondaryFireInterval) {
				secondaryFireTimer -= secondaryFireInterval;
				actualSecondaryWeapon.Fire(transform.position, Vector3.left, transform.rotation);
			}
			secondaryFireTimer += Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 9) { // Player bullet
			Destroy(other.gameObject);
			health--;
			if (health <= 0) {
				// Kill the boss!
				Destroy(gameObject);
				((LoadLevel)(Camera.mainCamera.GetComponent("LoadLevel"))).loadNextLevel();
			}
		}
	}
}
