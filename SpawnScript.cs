using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject obj_prefab;
	public float movementSpeed = 150f;
	public float spawnMin = 3f;
	public float spawnMax = 5f;
	GameObject individual;
	Animator anim;
	
	void Start () {
		Invoke("Spawn", Random.Range(spawnMin, spawnMax));
	}

	void Spawn() {
		individual = (GameObject)Instantiate(obj_prefab, transform.position, Quaternion.identity);

		anim = individual.GetComponent<Animator>();
		anim.SetBool("move", true);

		individual.rigidbody2D.AddForce(new Vector2(-movementSpeed,0)); //(enemies only move horizontally)

		Invoke ("IncreaseFrequency", 5f); // increase spawn frequency every 5 seconds
		Invoke ("Spawn", Random.Range(spawnMin, spawnMax));
	}

	void IncreaseFrequency() {
		if(spawnMax - 0.5f <= spawnMin) {
			spawnMax = spawnMin;
			if(spawnMin - 0.5f <= 1) {
				spawnMin = 1f;
				movementSpeed += 2f;
			}
			else spawnMin -= 0.5f;
		}
		else spawnMax -= 0.5f;
	}
}