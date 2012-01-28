using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class LoadLevel : MonoBehaviour 
{	
	int levelNumber;
	string[] fileNames = new string[9];
	float lastSpawnTime;
    string text = " ";
	
	public GameObject SpinnerBall;
	public GameObject Darter;
	public GameObject Dolphin;

	// Use this for initialization
	void Start () 
	{
		fileNames[0] = "map1.txt";
		FileInfo theSourceFile = new FileInfo ("Assets/data/level2.txt");
        StreamReader reader = theSourceFile.OpenText();
		
		while(true)
		{
			text = reader.ReadLine();
			if (text != null) 
			{
				loadObject(text);
	        }	
			else
			{
				break;
			}
		}
		reader.Close();
	}
	
	void loadObject(string enemyDetails)
	{
		string[] enemyAttributes = enemyDetails.Split(',');
		Vector3 spawnPosition = new Vector3 (Convert.ToSingle(enemyAttributes[1]), Convert.ToSingle(enemyAttributes[2]), 0.0f);
		UnityEngine.Object entity = null;
		if (enemyAttributes[0].Equals("SpinnerBall")) {
			entity = Instantiate(SpinnerBall, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("Darter")) {
			entity = Instantiate(Darter, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("Dolphin")) {
			entity = Instantiate(Dolphin, spawnPosition, Quaternion.identity);
		}
	}
}
