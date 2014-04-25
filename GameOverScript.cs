using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	
	public GUIStyle style;
	public GUIStyle score_style;

	void OnGUI() {

		GUI.Label(new Rect(Screen.width/2 - 60, Screen.height/2 - 95,100,100), "GAME\nOVER", style);

		GUI.Label(new Rect(Screen.width/2 - 45, Screen.height/2 + 10,100,100), 
		          "Score: " + GUIScript.score.ToString(), 
		          score_style);

		if(GUI.Button(new Rect(Screen.width/2 - 75, Screen.height/2 + 120, 150, 25), "Play again?"))
			Application.LoadLevel("Main");
	}
}
