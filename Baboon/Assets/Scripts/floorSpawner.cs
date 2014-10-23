using UnityEngine;
using System.Collections;

public class floorSpawner : MonoBehaviour {
	
	public GameObject ground;
	Transform baboon;

	// Use this for initialization
	void Start () {
		baboon = GameObject.Find("prefabBaboon").transform;
		StartCoroutine(spawnFloor());
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Spawn floor
	IEnumerator spawnFloor(){
		Instantiate(ground,new Vector3(baboon.transform.position.x+25f,-2,0),new Quaternion(0,0,0,0));
		yield return new WaitForSeconds (3);
		StartCoroutine(spawnFloor());
	}
}
