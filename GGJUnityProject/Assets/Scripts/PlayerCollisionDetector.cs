using UnityEngine;
using System.Collections;

public class PlayerCollisionDetector : MonoBehaviour {
	public int health = 1;
	public int maxHealth = 1;

	void Start() {
	}
	
	void Update() {
		Globals.PlayerLife = (int)((health / (float)maxHealth) * 100);
	}
	
	void OnTriggerEnter(Collider other) {
		// Destroy the object that hit us
    
		if (other.gameObject.layer >= 10 && other.gameObject.layer <= 13) {
			// enemies and their bullets
			if (other.gameObject.layer == 10) {
				// enemy bullets
				Destroy(other.gameObject);
			}
			health -= 1;
			if (health <= 0) {
				// Kill the player
				Destroy(gameObject);
				
				// Fade to menu
				((FadeAndDefeat)(Camera.mainCamera.GetComponent("FadeAndDefeat"))).FadeToBlack();
			}
		}
    
	}
}
