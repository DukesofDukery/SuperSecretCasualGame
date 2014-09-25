using UnityEngine;
using System.Collections;

public class buidingSpawner : MonoBehaviour {

	public GameObject[] buildings;

	// Use this for initialization
	void Start () {
		StartCoroutine(spawnBuilding());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Spawn buildings
	IEnumerator spawnBuilding(){
		yield return new WaitForSeconds (5);
		Instantiate(buildings[Random.Range(0,4)],transform.position,transform.rotation);
		StartCoroutine(spawnBuilding());
	}
}
