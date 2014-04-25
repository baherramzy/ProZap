using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public GameObject laser_prefab; // prefab to instantiate when firing
	public float movementSpeed = 0.1f; // player movement speed
	public KeyCode moveUp = KeyCode.W; // move up key assignment
	public KeyCode moveDown = KeyCode.S; // move down key assignment
	public KeyCode Fire = KeyCode.Space; // fire key assignment
	public AudioClip fire_sound; // audio clip to play when firing weapon
	public static int lives = 3; // player health
	public GUIScript g; // reference to game GUI

	private GameObject gun; // reference to player weapon
	
	void Start () {
		gun = transform.FindChild("gun").gameObject;
	}

	void Update () {
		if(Input.GetKey(moveUp)) {
			transform.Translate(new Vector3(0,movementSpeed,0));
			gun.SetActive(false);
		}

		else if(Input.GetKey(moveDown)) {
			transform.Translate(new Vector3(0,-movementSpeed,0));
			gun.SetActive(false);
		}

		else if(Input.GetKeyDown(Fire) || Input.GetMouseButtonDown(0)) {
			gun.SetActive(true);
			GameObject temp = 
				(GameObject)Instantiate(laser_prefab, gun.transform.position + new Vector3(0.6f,0,0), Quaternion.identity);
			temp.rigidbody2D.AddForce(new Vector2(150f,0));
			audio.pitch = Random.Range(0.8f,1f);
			audio.PlayOneShot(fire_sound);
		}

		else {
			gun.SetActive(true);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log (other.gameObject.tag);
		if(other.gameObject.tag == "Enemy") {
			// Destroy enemy
			Destroy(other.gameObject);

			// indicate life lost
			Destroy(
				Instantiate(g.dmg_text, 
			            Camera.main.WorldToViewportPoint(transform.position) + new Vector3(0.08f,0.1f,0),
			            Quaternion.identity),
				0.7f);

			// Deduct lives
			--lives;
			--g.lives;

			if(lives == 0) // Game Over
				Application.LoadLevel("GameOver");
		}
	}
}
