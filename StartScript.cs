using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
	
	public GUIStyle style;
	public GUIStyle text_style;

	void OnGUI() {
		GUI.Label(new Rect(Screen.width/2 - 45,140,100,100), "ProZap!", style);
		GUI.Label(new Rect(Screen.width/2 - 140,290,300,150), 
		             "You're a college student having a nightmare about \n" +
		             "your least favorite professor.\n\n" + 
		          	 "Survive for as long as you can by zapping\n" +
		          	 "multiple waves of Professor Clones!", 
		          	 text_style);

		GUI.Label(new Rect(Screen.width/2 - 170, Screen.height/2 + 210, 150, 25),
		          "(W,S = Up, Down)\n" +
		          "(Space, Mouse Button = Fire)",
		          text_style);

		if(GUI.Button(new Rect(Screen.width/2 + 190, Screen.height/2 + 200, 140, 65), "Start"))
			Application.LoadLevel("Main");
	}
}