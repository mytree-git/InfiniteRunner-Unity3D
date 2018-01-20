using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {

	public GameObject[] coins;
	public GameObject[] walls;
	public GameObject player;

	private float coinsSpawnTime = 5.0f; 
	private float wallsSpawnTime = 3.0f;
	private float wallsLife = 10.0f;



	// Use this for initialization
	void Start () {

	}


	//spawn red and blue coins randomly
	void spawnCoins() {
		
		Instantiate (coins [(Random.Range (0, coins.Length))], new Vector3 (player.transform.position.x, player.transform.position.y, player.			  transform.position.z + 4), Quaternion.identity);
		coinsSpawnTime = Random.Range (3.0f,8.0f);
	}


	//spawn vertical and horizontal walls randomly
	void spawnWalls() {
		
		int buildingnumber = (Random.Range (0, walls.Length));
		Destroy(Instantiate (walls [buildingnumber], new Vector3 (walls[buildingnumber].transform.position.x, walls[buildingnumber].transform.		  position.y, player.transform.position.z + 10), Quaternion.identity),wallsLife);
	    wallsSpawnTime = Random.Range (2.0f, 4.0f);
	}

	public void ObjectSpawnerUpdate() {
	
		coinsSpawnTime -= Time.deltaTime;
		wallsSpawnTime -= Time.deltaTime;

		if (coinsSpawnTime < 0.01) {
			spawnCoins ();
		}
		if (wallsSpawnTime < 0.01) {
			spawnWalls ();
		}
	}

	// Update is called once per frame
	void Update () {
		
		ObjectSpawnerUpdate ();

	}
}
