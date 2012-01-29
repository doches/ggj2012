using UnityEngine;
using System.Collections;

public class PlayerExtraControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Globals.GamePaused == false)
            {
                //pauze the game
                Globals.PauseCurrentGame();
            }
            else
            {
                //resume the game
                //Time.timeScale = 1;
                Globals.ContinueCurrentGame();
            }
        }

	}

    

}
