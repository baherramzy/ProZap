using UnityEngine;
using System.Collections;

public class BackgroundScrollScript : MonoBehaviour {

	public float speed = 0f;
	
	void Update () {
		renderer.material.mainTextureOffset = new Vector2((Time.time * speed)%1, 0f);
	}
}
