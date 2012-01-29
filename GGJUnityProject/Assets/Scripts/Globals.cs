using UnityEngine;
using System.Collections;

public static class Globals {

    public static int PlayerLife = 100;

    public static bool GamePaused = false;

    public static System.DateTime GameLostOn;
    public static bool GameLost;

    public static int PlayerScore = 0;

	// Use this for initialization
    //static void Start () {
    //    PlayerLife 
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}

    public static void LostTheGame()
    {
        GameLost = true;
        GameLostOn = System.DateTime.Now;
    }

    public static void StartGame()
    {
        //set globals
        PlayerLife = 100;
        PlayerScore = 0;

        ContinueCurrentGame();

        //switch level
        Application.LoadLevel("JaapScene");
    }

    public static void ContinueCurrentGame()
    {
        Time.timeScale = 1;
        GamePaused = false; 
    }

    public static void PauseCurrentGame()
    {
        Time.timeScale = 0;
        GamePaused = true; 
    }

    public static void QuitCurrentGame()
    {
        Application.LoadLevel("StartScene");
    }

    public static void ExitApplication()
    {
        Application.Quit();
    }

}
