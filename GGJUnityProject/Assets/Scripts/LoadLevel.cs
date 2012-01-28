using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class LoadLevel : MonoBehaviour 
{	
	protected static int levelIndex = 0;
	protected static string[] levelNames = {
		"Assets/Data/level1.map",
		"Assets/Data/level1.map"
	};
	
	public GameObject SpinnerBall;
	public GameObject Darter;
	public GameObject Dolphin;

	// Use this for initialization
	void Start () 
	{
		levelIndex = 0;
		loadNextLevel();
	}
	
	void loadNextLevel()
	{
		FileInfo theSourceFile = new FileInfo (levelFiles[levelIndex++]);
        StreamReader reader = theSourceFile.OpenText();
		
		while(true)
		{
			string text = reader.ReadLine();
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
		// Position in the x plane
		Vector3 spawnPosition = new Vector3 (Convert.ToSingle(enemyAttributes[1]), 0.0f, 0.0f);
		
		// Spawn the requested object
		UnityEngine.Object entity = null;
		if (enemyAttributes[0].Equals("enemy1")) {
			entity = Instantiate(SpinnerBall, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("enemy2")) {
			entity = Instantiate(Darter, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("enemy3") || true) {
			entity = Instantiate(Dolphin, spawnPosition, Quaternion.identity);
		} 
		
		// Assign the specified (OH MY GOD MY EEEEEYES) path and speed
		int yEncodedData = (int)(Convert.ToSingle(enemyAttributes[2]));
		int speed = 6;//(int)((yEncodedData % 100)/10.0f + 5.0f);
		int pathIndex = (yEncodedData / 100);
		
		PrePathPositioningWidget positioningWidget = ((PrePathPositioningWidget)(((GameObject)entity).GetComponent("PrePathPositioningWidget")));
		
		positioningWidget.SpeedOnPath = speed;
		positioningWidget.PathName = GetPathNameForIndex(pathIndex);
	}
	
	string GetPathNameForIndex(int index)
	{
		switch(index) {
			case 0: return "SlantMiddle";
			case 1: return "SlantDiagTopLeft";
			case 2: return "SlantFromBehind";
			case 3: return "SlantFromFront";
			case 4: return "SlantDiagBottomLeft";
			case 5: return "StraightTopLeft";
			case 6: return "StraightTopRight";
			case 7: 
			default: 
				return "SlantDiagTopRight";
		}
	}
}
