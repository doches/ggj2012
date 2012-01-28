using UnityEngine;
using System.Collections;

public class debug_BounceVertical : MonoBehaviour {
	
	protected float delta = -0.02f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Moving down...
		if (this.transform.position.y > -2.0f && delta < 0.0f) {
			this.transform.position += new Vector3(0, delta, 0);
			if (this.transform.position.y <= -2.0f) {
				delta = -delta;
			}
		} else {
			this.transform.position += new Vector3(0, delta, 0);
			if (this.transform.position.y >= 2.0f) {
				delta = -delta;
			}
		}
	}
}
