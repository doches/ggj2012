using UnityEngine;
using System.Collections;

public class TempBulletRight : MonoBehaviour {
	public float delay = 0;
	public float speed = 0.5f;
	private float elapsedTime;

	// Use this for initialization
	void Start () {
		elapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (elapsedTime > delay) {
			rigidbody.velocity = new Vector3(1, 0, 0);
			elapsedTime = -1;
		} else if (elapsedTime >= 0) {
			elapsedTime += Time.deltaTime;
		}
	}
}
