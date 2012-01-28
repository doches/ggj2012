using UnityEngine;
using System.Collections;

public class ParallaxRings : MonoBehaviour {

	public GameObject middleground;
	public GameObject foreground;
	public GameObject background;
	public float fullRotationSeconds = 360f;
	public float backgroundSpeedMultiple = 0.25f;
	public float foregroundSpeedMultiple = 4.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float angle = -360.0f * (Time.deltaTime / fullRotationSeconds);
	 	foreground.transform.Rotate(Vector3.forward * angle * foregroundSpeedMultiple);
		middleground.transform.Rotate(Vector3.forward * angle);
		background.transform.Rotate(Vector3.forward * angle * backgroundSpeedMultiple);
	}
}
