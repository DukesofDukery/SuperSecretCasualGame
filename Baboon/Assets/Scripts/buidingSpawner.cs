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
		transform.Translate(transform.right*Time.deltaTime*5);
	}

	//Spawn buildings
	IEnumerator spawnBuilding(){
		yield return new WaitForSeconds (Random.Range(2f,4f));
		Instantiate(buildings[Random.Range(0,buildings.Length)],transform.position,transform.rotation);
		StartCoroutine(spawnBuilding());
	}
}
