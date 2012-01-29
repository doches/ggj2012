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
	};
	
	public GameObject SpinnerBall;
	public GameObject Darter;
	public GameObject Dolphin;
	public GameObject Langolier;
	public GameObject LittleChopperOrThePeriscopeThatCould;
	public GameObject FinalBoss;
	public GameObject rhDoor;
	public GameObject lhDoor;
	
	public GameObject[] Weapon;
	
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
	
		levelIndex = 0;
		loadNextLevel(); // <- HACK remove to have first boss fight
	}
	
	public void loadNextLevel()
	{
		print("[LoadLevel] Load level: " + levelIndex);
		if (levelIndex >= 4) {
			// Don't attempt to load a level; load a final boss fight instead.
			FinalBoss.SetActiveRecursively(true);
			
			PlayerBossGates bossGates = (PlayerBossGates)(GameObject.FindWithTag("Player").AddComponent("PlayerBossGates"));
			bossGates.finalBoss = FinalBoss;
			
			GateOpener gateOpener = (GateOpener)(GameObject.FindWithTag("Player").AddComponent("GateOpener"));
			gateOpener.leftGate = lhDoor;
			gateOpener.rightGate = rhDoor;
			
			return;
		}
		FileInfo theSourceFile = new FileInfo (levelFiles[levelIndex]);
        	StreamReader reader = theSourceFile.OpenText();
		
		UnityEngine.Object lastSpawnedEntity = null;
		int countEntitiesSpawned = 0;
		while(true && countEntitiesSpawned < 1) // <- HACK to shorten levels
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
		UnityEngine.Object part = null;
		if (levelIndex != 3) {
			part = Instantiate(parts[levelIndex], partPosition, Quaternion.identity);
		} else {
			part = parts[3];
			parts[3].SetActiveRecursively(true);
		}
		
		// Swap weapons
		((PlayerWeaponControls)(GameObject.FindWithTag("Player").GetComponent("PlayerWeaponControls"))).currentPlayerWeapon = Weapon[levelIndex];
		
		// Next time, load the next level. Not this one. We just beat this one, so that would be extremely silly.
		// Unless it's a particularly good one.
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
		} else if (enemyAttributes[0].Equals("enemy4")) {
			entity = Instantiate(Langolier, spawnPosition, Quaternion.identity);
		} else if (enemyAttributes[0].Equals("enemy5") || true) {
			entity = Instantiate(LittleChopperOrThePeriscopeThatCould, spawnPosition, Quaternion.identity);
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
