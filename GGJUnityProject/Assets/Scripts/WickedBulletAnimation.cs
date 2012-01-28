using UnityEngine;
using System.Collections;

public class WickedBulletAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.rigidbody.AddTorque(30.0f, 50.0f, 40.0f);
	}
}
