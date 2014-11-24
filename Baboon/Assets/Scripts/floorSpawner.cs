using UnityEngine;
using System.Collections;

public class floorSpawner : MonoBehaviour {
	
	public GameObject[] ground;
	Transform baboon;
	Transform camera;

	// Use this for initialization
	void Start () {
		baboon = GameObject.Find("Baboon").transform;
		camera = GameObject.Find("Main Camera").transform;
		StartCoroutine(spawnFloor());
	}
	
	// Update is called once per frame
	void Update () {
	}

	//Spawn floor
	IEnumerator spawnFloor(){
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+45f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+45.15f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+50f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+59.85f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+64.7f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+69.55f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+74.4f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+79.25f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+84.1f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+88.95f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+93.8f,-3,0),new Quaternion(0,0,0,0));
		Instantiate(ground[Random.Range(0,ground.Length-1)],new Vector3(camera.transform.position.x+98.65f,-3,0),new Quaternion(0,0,0,0));
		yield return new WaitForSeconds (2f);
		StartCoroutine(spawnFloor());
	}
}
