using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour 
{	
	int levelNumber;
	string[] fileNames = new string[9];
	public GameObject enemySMover;
	float lastSpawnTime;

	// Use this for initialization
	void Start () 
	{
		fileNames[0] = "map1.txt";
		loadObject();
	}
	
	void loadObject()
	{
		float yPosition = Random.Range(-2.0f, 10.0f);
		print("spawn " + yPosition);
		Vector3 spawnPosition = new Vector3 (transform.position.x, yPosition, transform.position.z);
		Object enemy = Instantiate(enemySMover, spawnPosition, transform.rotation);
		lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		print(Time.time);
		if (Time.time - lastSpawnTime > 3)
		{			
			loadObject();
		}
	}
}
