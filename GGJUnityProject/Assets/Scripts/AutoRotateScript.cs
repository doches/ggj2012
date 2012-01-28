using UnityEngine;
using System.Collections;

public class AutoRotateScript : MonoBehaviour {
	
	public float RotationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		this.transform.Rotate(90.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(0.0f, 0.0f, RotationSpeed * -Time.deltaTime);
	}
}
