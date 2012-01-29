using UnityEngine;
using System.Collections;

public class ScrollPartIntoScreen : MonoBehaviour 
{
	public float SpeedBeforePath = 0.05f;
	
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x > 0)
		{
			transform.position = new Vector3(transform.position.x-SpeedBeforePath, transform.position.y, transform.position.z);
		} else {
			Destroy(this);
		}
	}
}

