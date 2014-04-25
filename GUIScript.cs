using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public static int score = 0; // player score
	public int lives = PlayerController.lives; // player health
	public Texture2D heart; // health texture
	public GUIStyle style; // font style
	public GUIText dmg_text;

	void OnGUI() {
		GUI.Label(new Rect(260,5,100,100), "Score: " + score, style);
		GUI.Label(new Rect(360,5,100,100), "Health: ", style);

		if(lives > 0) GUI.DrawTexture(new Rect(190, 8, 20, 20), heart);
		if(lives > 1) GUI.DrawTexture(new Rect(210, 8, 20, 20), heart);
		if(lives > 2) GUI.DrawTexture(new Rect(230, 8, 20, 20), heart);
	}
}
