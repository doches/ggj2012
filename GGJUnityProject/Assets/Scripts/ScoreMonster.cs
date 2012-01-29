using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//the big bad ScoreMonster! it will do horrible things such as eating up your score and barfing it up later on

public static class ScoreMonster {

    public static void SaveScore(int score, string name)
    {
        
    }

    public static List<ScoreObject> ScoreList()
    {
        
        //return a list of strings and scores
        List<ScoreObject> objReturn = new List<ScoreObject>();

        objReturn.Add(new ScoreObject() { Name = "eggs", Score = 8 });
        objReturn.Add(new ScoreObject() { Name = "eggsAgain", Score = 20 });
        objReturn.Add(new ScoreObject() { Name = "eggsOnceMore", Score = 9 });

        objReturn.Sort();

        return objReturn;

    }



    //// Use this for initialization
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}
}
