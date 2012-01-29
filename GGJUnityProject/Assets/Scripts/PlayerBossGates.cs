using UnityEngine;
using System.Collections;

public class PlayerBossGates : MonoBehaviour {
	public GameObject finalBoss;
	private FinalBoss finalBossController;
	private float timer;
	private GateOpener gateOpener;
	private bool gatesOpening = false;
	private bool gatesOpened = false;
	private bool gatesClosing = false;

	public float gateOpenedTime = 5.0f;
	public float gateClosedTime = 12.0f;
	public float gateAnimateTime = 2.0f;

	private GameObject gatlingWeapon;
	private GameObject doubleCannonballWeapon;

	void Start () {
		finalBossController = (FinalBoss)finalBoss.GetComponent("FinalBossController");
		gateOpener = (GateOpener)(gameObject.GetComponent("GateOpener"));
		gatlingWeapon = GameObject.Find("GatlingWeapon");
		doubleCannonballWeapon = GameObject.Find("DoubleCannonballWeapon");
	}
	
	void Update () {
		timer += Time.deltaTime;
		if (gatesOpened && timer >= gateOpenedTime) {
			timer -= gateOpenedTime;
			gatesOpened = false;
			gatesClosing = true;
			gateOpener.closeGates();
			
			// switch weapon back to cannonballs
			((PlayerWeaponControls)gameObject.GetComponent("PlayerWeaponControls")).currentPlayerWeapon = doubleCannonballWeapon;
		} else if (gatesOpening && timer >= gateAnimateTime) {
			timer -= gateAnimateTime;
			gatesOpening = false;
			gatesOpened = true;

			// Switch weapon to gatling
			((PlayerWeaponControls)gameObject.GetComponent("PlayerWeaponControls")).currentPlayerWeapon = gatlingWeapon;
		} else if (gatesClosing && timer >= gateAnimateTime) {
			timer -= gateAnimateTime;
			gatesClosing = false;
		} else if (timer >= gateClosedTime) {
			timer -= gateClosedTime;
			gatesOpening = true;
			gateOpener.openGates();
		}
	}
}
