using UnityEngine;
using System.Collections;

public class EnemyBoss : AbstractBoss {
	public GameObject[] parts = new GameObject[9];

	// Use this for initialization
	void Start () {
		// The enemy boss starts with all points weak
		foreach (GameObject part in parts) {
			((BossPart)part.GetComponent("BossPart")).SetWeak();
		}
	}
	
	// Update is called once per frame
	void Update () {
		// BOSS MOVEMENT AND ATTACK PATTERNS!!!
	}

	public override void PartBroken(GameObject brokenPart) {
		print("Part broken:");
		print(brokenPart);
		int brokenPartCount = 0;
		foreach (GameObject part in parts) {
			if (((BossPart)part.GetComponent("BossPart")).IsBroken()) {
				brokenPartCount++;
			}
		}
		if (brokenPartCount == 8) {
			// All the breakable parts have been broken
			print("The boss is dead!");
		}
	}
}
