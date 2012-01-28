using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {

    //public Texture _GuiTexture;
    public Texture GaugePlaceholder;
    public Texture ArrowPlaceholder;

   // private Texture _ArrowPlaceholderMod;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //_ArrowPlaceholderMod = (Texture)Texture.Instantiate(Resources.Load("arrowPlaceholder"), new Vector3(), new Quaternion());
	}

    void OnGUI() {

       

        GUI.Label(new Rect(10, 10, 300, 200), Globals.PlayerLife.ToString());
       
        GUI.DrawTexture(new Rect(Screen.width - 120, Screen.height -120, 100, 100), GaugePlaceholder);

         Matrix4x4 matrixBackup = GUI.matrix;

         int iAngle = -90;

         if (Globals.PlayerLife < 40)
         {
             iAngle += Globals.PlayerLife;
         }

         GUIUtility.RotateAroundPivot(iAngle, new Vector2(Screen.width - 120 + 50, Screen.height - 120 + 50));

        GUI.DrawTexture(new Rect(Screen.width - 120, Screen.height - 120, 100, 100), ArrowPlaceholder);

        GUI.matrix = matrixBackup;
      //' GUI.DrawTexture(new Rect(Screen.width - 120, Screen.height - 120, 100, 100), );
    }
}
