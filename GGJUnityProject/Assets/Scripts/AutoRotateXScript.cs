using UnityEngine;
using System.Collections;

public class AutoRotateXScript : MonoBehaviour {
	
	public float RotationSpeed = 2.0f;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Rotate(RotationSpeed * -Time.deltaTime, 0.0f, 0.0f);
	}
}
