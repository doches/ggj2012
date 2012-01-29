using UnityEngine;
using System.Collections;

public class PlayerWeaponControls : MonoBehaviour 
{
	public GameObject currentPlayerWeapon;
	private PlayerWeapon playerWeapon;

	void Start () 
	{
		playerWeapon = ((PlayerWeapon)currentPlayerWeapon.GetComponent("PlayerWeapon"));
	}
	
	void Update () 
	{
		if(Input.GetKey("space") == true && playerWeapon.CanFire())
		{
			playerWeapon.Fire(transform.position, Vector3.right, transform.rotation);
		}
	}
}
