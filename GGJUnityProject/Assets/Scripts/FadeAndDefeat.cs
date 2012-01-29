using UnityEngine;
using System.Collections;

public class FadeAndDefeat : MonoBehaviour {

	// Use this for initialization
    //void Start () {
	
    //}

    float alphaFadeValue = 0;

    public Texture BlackTexture;
    public Texture QuitButton;
    public Texture QuitButtonGlow;

    public bool _FadeNow = false;

    public void FadeToBlack()
    {
        _FadeNow = true;



    
    }

    public void OnGUI() {

        if (_FadeNow)
        {

            GUIStyle style = new GUIStyle(); //a blank style to remove default button borders

            alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 5);
            GUI.color = new Color(alphaFadeValue, alphaFadeValue, alphaFadeValue, alphaFadeValue);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), BlackTexture);

            var myStyle = new GUIStyle();
            myStyle.fontSize = 50;
            myStyle.normal.textColor = Color.white;
            myStyle.alignment = TextAnchor.MiddleCenter;

            GUI.Label(new Rect(10, Screen.height / 2 - 30, Screen.width - 20, 60), "You broke the cycle", myStyle);

            myStyle.fontSize = 20;

            GUI.Label(new Rect(10, Screen.height / 2 + 30, Screen.width - 20, 60), "(And lost the game...)", myStyle);


            //quit game button


            Rect QuitButtonRect = new Rect(Screen.width / 2 - 106, Screen.height / 2 + 100, 212, 50);


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
                Globals.QuitCurrentGame();
            }

        }

    }

}
