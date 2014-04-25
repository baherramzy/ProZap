using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
	
	public float lifetime = 0.15f;
	public AudioClip score_sound;

	void Awake() { 
		Destroy(this.gameObject, lifetime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy") {
			//spawn particle effect

			//play sound
			audio.PlayOneShot(score_sound);

			this.collider2D.enabled = false;
			this.renderer.enabled = false;

			//increase score
			++GUIScript.score;

			//Destroy both objects
			Destroy(other.gameObject, 0.05f);
			Destroy(this.gameObject, 0.05f);//, 0.1f);
		}
	}
}
