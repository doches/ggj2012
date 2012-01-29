using UnityEngine;
using System.Collections;

<<<<<<< HEAD

public class DieOnPlayerBulletHit : MonoBehaviour {
	public GameObject ExplosionPrefab;
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 9) { // player bullets
=======
public class DieOnPlayerBulletHit : MonoBehaviour 
{
	public GameObject ExplosionPrefab;
	public GameObject soundObject;
	
	void OnTriggerEnter(Collider other) 
	{
		print (this.gameObject.name);
		if (other.gameObject.layer == 9) 
		{ // player bullets
>>>>>>> 7d5b4b840adf73cfe27ada8fce1c5752f017d39b
			// Die
			Destroy(this.gameObject);
			// Also destroy the player's bullet
			Destroy(other.gameObject);
			Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
			soundObject.audio.Play();
		}
	}
}
