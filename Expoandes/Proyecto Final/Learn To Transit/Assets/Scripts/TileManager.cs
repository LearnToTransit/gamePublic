using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	public GameObject[] prefabs;

	private Transform playerTransform;
	private float spawnZ = 0.0f;
	private float tileLength = 117.0f;
	private int amnTilesOnScreen = 3;
	private float safeZone = 122.0f;
	private int lastPrefabIndex = 0;

	private List<GameObject> activeTiles;

	// Use this for initialization
	private void Start () {
		activeTiles = new List<GameObject>();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for (int i = 0; i < amnTilesOnScreen; i++) {
			if (i < 1)	
				SpawnTile (0);
			else
				SpawnTile ();
		}
	}
	

	private void Update () {
		if (playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength)) {
			SpawnTile ();
			DeleteTile ();
		}


	}

	private void SpawnTile(int prefabIndex = -1){

		GameObject go;
		if(prefabIndex == -1)
			go = Instantiate (prefabs [RandomPrefabIndex()])as GameObject;
		else
			go = Instantiate(prefabs[prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);
	}
	private void DeleteTile(){
		Destroy (activeTiles [0]);
		activeTiles.RemoveAt (0);
	
	}

	private int RandomPrefabIndex (){
		if (prefabs.Length <= 1)
			return 0;

		int randomIndex = lastPrefabIndex;

		while (randomIndex == lastPrefabIndex) {
			randomIndex = Random.Range (0, prefabs.Length);
		
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;

	}
}
