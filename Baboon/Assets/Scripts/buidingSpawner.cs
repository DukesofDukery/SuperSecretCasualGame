using UnityEngine;
using System.Collections;

public class buidingSpawner : MonoBehaviour {

	public GameObject[] buildings;
	public GameObject ground;
	Transform baboon;

	// Use this for initialization
	void Start () {
		StartCoroutine(spawnBuilding());
		baboon = GameObject.Find("prefabBaboon").transform;
		StartCoroutine(spawnFloor());
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Spawn buildings
	IEnumerator spawnBuilding(){
		yield return new WaitForSeconds (Random.Range(3,5));
		Instantiate(buildings[Random.Range(0,buildings.Length)],baboon.position+transform.right*50+transform.up*5,transform.rotation);
		StartCoroutine(spawnBuilding());
	}

	IEnumerator spawnFloor(){
		Instantiate(ground,new Vector3(baboon.transform.position.x+25f,-2,0),new Quaternion(0,0,0,0));
		yield return new WaitForSeconds (3);
		StartCoroutine(spawnFloor());
	}
}
