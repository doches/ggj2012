using UnityEngine;
using System.Collections;

public class DieAtLeftSideOfScreen : MonoBehaviour {
	
	protected GameObject killer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < -16) {
			Destroy(this.gameObject);
		}
	}
}
