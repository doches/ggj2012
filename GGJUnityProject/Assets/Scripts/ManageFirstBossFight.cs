using UnityEngine;
using System.Collections;

public class ManageFirstBossFight : MonoBehaviour {
	public GameObject MovementPattern;
	public GameObject BossModel;
	
	private bool ongoing;

	// Use this for initialization
	void Start () {
		ongoing = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetupArena()
	{
		Instantiate(MovementPattern,new Vector3(2.2f, 0.0f, 0.0f),Quaternion.identity);
		Instantiate(BossModel);
	}
	
	public bool isOngoing()
	{
		return ongoing;
	}
	
	public void DestroyArena()
	{
		Destroy(MovementPattern);
		Destroy(BossModel);
	}
}
