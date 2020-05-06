using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject spawnObject; // what prefabs to spawn
    public float secondsBetweenSpawning = 0.1f;
    private float nextSpawnTime;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + secondsBetweenSpawning;
    }

	// Update is called once per frame
	void Update()
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm)
		{
			if (GameManager.gm.gameIsOver)
				return;
		}

		// if time to spawn a new game object
		if (Time.time >= nextSpawnTime)
		{
			// Spawn the game object through function below
			MakeThingToSpawn();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time + secondsBetweenSpawning;
		}
	}

	void MakeThingToSpawn()
	{
		position.x = -15.66f;
		position.y = 1.15f;
		position.z = 6.9057e-08f;
		// actually spawn the game object
		GameObject spawnedObject = Instantiate(spawnObject, position, transform.rotation) as GameObject;

		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = gameObject.transform;
	}
}
