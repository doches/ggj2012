using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartSceneScript : MonoBehaviour {

	// Use this for initialization
    //void Start () {

    //    //this 
    //    Time.timeScale = 0;

    //}

    public Texture StartButton;
    public Texture StartButtonGlow;

    public Texture QuitButton;
    public Texture QuitButtonGlow;

    public Texture Cogs;

    private List<ScoreObject> _scoreCache;

   // AudioSource MainMenuMusic;

    void Start()
    {
        //MainMenuMusic.Play();
        _scoreCache = ScoreMonster.ScoreList();
    }

	void OnGUI () {

        
        //GUI.backgroundColor = Color.black;

        //GUI.color = Color.black;

        //GUI.Label(new Rect(10, 10, 200, 200), "Hello der");

        //GUISkin skin = new GUISkin();
        //skin.b

        GUIStyle style = new GUIStyle(); //a blank style to remove default button borders

        GUI.backgroundColor = Color.black;
       
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
       // GUI.backgroundColor = bgcolor;


        //cogs
        GUI.DrawTexture(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 215, 255, 382), Cogs);


        //start button
        Rect StartButtonRect = new Rect(Screen.width / 2 - 106, Screen.height / 2 - 95, 212, 50);

  
        Texture startTexture;
        if (StartButtonRect.Contains(Event.current.mousePosition))
        {
           // Debug.Log("I see you");
            startTexture = StartButtonGlow;
        }
        else
        {
            startTexture = StartButton;          
        }

        if (GUI.Button(StartButtonRect, startTexture, style))
        {
            Globals.StartGame();
        }


        //quit game button

        Rect QuitButtonRect = new Rect(Screen.width / 2 - 106, Screen.height / 2 + 25, 212, 50);


        Texture quitTexture;
        if (QuitButtonRect.Contains(Event.current.mousePosition))
        {
            // Debug.Log("I see you");
            quitTexture = QuitButtonGlow;
        }
        else
        {
            quitTexture = QuitButton;

        }

        if (GUI.Button(QuitButtonRect, quitTexture, style))
        {
            Globals.ExitApplication();
        }


       // GUI.Button(,, new GUIStyle().
	}



}
