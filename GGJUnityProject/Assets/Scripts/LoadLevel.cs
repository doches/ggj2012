using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class LoadLevel : MonoBehaviour 
{	
	protected static int levelIndex = 0;
	protected static string[] levelFiles = {
		"Assets/Data/level0.map",
		"Assets/Data/level1.map",
		"Assets/Data/level2.map",
		"Assets/Data/level3.map",
		"Assets/Data/level1.map",
	};
	
	public GameObject SpinnerBall;
	public GameObject Darter;
	public GameObject Dolphin;
	public GameObject Langolier;
	
	public GameObject Part1;
	public GameObject Part2;
	public GameObject Part3;
	public GameObject Part4;
	public GameObject Part5;
	
	protected GameObject[] parts;

	// Use this for initialization
	void Start () 
	{
		parts = new GameObject[8];
		
		// Hook up parts into an accessible list. IHFTP.
		parts[0] = Part1;
		parts[1] = Part2;
		parts[2] = Part3;
		parts[3] = Part4;
		parts[4] = Part5;
		
		levelIndex = 0;
		loadNextLevel();
	}
	
	public void loadNextLevel()
	{
		if (levelIndex > 3) {
			print("[LoadLevel] Cannot load level "+levelIndex);
			return;
		}
		FileInfo theSourceFile = new FileInfo (levelFiles[levelIndex]);
        StreamReader reader = theSourceFile.OpenText();
		
		UnityEngine.Object lastSpawnedEntity = null;
		int countEntitiesSpawned = 0;
		while(true)
		{
			string text = reader.ReadLine();
			if (text != null) 
			{
				lastSpawnedEntity = loadObject(text);
				countEntitiesSpawned++;
	        }	
			else
			{
				break;
			}
		}
		reader.Close();
		
		// Spawn the next part after this wave is over.
		Vector3 partPosition = new Vector3(((GameObject)lastSpawnedEntity).transform.position.x+40, 0, 0);
		if (levelIndex==3) {
			partPosition.y = 3;
		}
		UnityEngine.Object part = Instantiate(parts[levelIndex], partPosition, Quaternion.identity);
		
		if (levelIndex==3) {
			partPosition = new Vector3(partPosition.x+20, -3, 0);
			part = Instantiate(parts[levelIndex+1], partPosition, Quaternion.identity);
		}
		
		// Next time, load the next level. Not this one. We just beat this one, so that would be extremely silly.
		// Unless it's a particularly good one.
		print("[LoadLevel]: Loaded " + levelIndex);
		levelIndex++;
	}
	
	UnityEngine.Object loadObject(string enemyDetails)
	{
		string[] enemyAttributes = enemyDetails.Split(',');
		// Position in the x plane
		Vector3 spawnPosition = new Vector3 (Convert.ToSingle(enemyAttributes[1]), 0.0f, 0.0f);
		
		// Spawn the requested object
		UnityEngine.Object entity = null;
		if (enemyAttributes[0].Equals("enemy1")) {
			entity = Instantiate(SpinnerBall, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("enemy2")) {
			entity = Instantiate(Darter, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("enemy3")) {
			entity = Instantiate(Dolphin, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("enemy4") || true) {
			entity = Instantiate(Langolier, spawnPosition, Quaternion.identity);
		} 
		
		// Assign the specified (OH MY GOD P EEEEEYES) path and speed
		int yEncodedData = (int)(Convert.ToSingle(enemyAttributes[2]));
		int speed = (int)(((yEncodedData % 100)/10.0f) + 3.0f);
		int pathIndex = (yEncodedData / 100);
		
		PrePathPositioningWidget positioningWidget = ((PrePathPositioningWidget)(((GameObject)entity).GetComponent("PrePathPositioningWidget")));
		
		positioningWidget.SpeedOnPath = speed;
		positioningWidget.PathName = GetPathNameForIndex(pathIndex);
		
		return entity;
	}
	
	string GetPathNameForIndex(int index)
	{
		switch(index) 
		{
			case 0: return "SlantMiddle";
			case 1: return "SlantDiagTopLeft";
			case 2: return "SlantFromBehind";
			case 3: return "SlantFromFront";
			case 4: return "SlantDiagBottomLeft";
			case 5: return "StraightTopLeft";
			case 6: return "StraightTopRight";
			case 7: return "SlantDiagTopRight";
			default: 
				return "SlantDiagTopRight";
		}
	}
}
