using UnityEngine;
using System.Collections;

public class aestheticSpawner : MonoBehaviour {

	public GameObject[] clouds;
	public GameObject foreground;
	public GameObject background;
	public Transform baboon;
	// Use this for initialization
	void Start () {
		baboon = GameObject.Find("prefabBaboon").transform;
		StartCoroutine(spawnCloud());
		StartCoroutine(spawnBackground());
		StartCoroutine(spawnForeground());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawnCloud(){
		Instantiate(clouds[Random.Range(0,2)],new Vector3(baboon.transform.position.x + 50,clouds[Random.Range(0,2)].transform.position.y + Random.Range(-3,3),0),
		            clouds[Random.Range(0,2)].transform.rotation);
		yield return new WaitForSeconds (Random.Range(2,5));
		StartCoroutine(spawnCloud());
	}

	IEnumerator spawnBackground(){
		Instantiate(background,new Vector3(baboon.transform.position.x + 50,background.transform.position.y,0),background.transform.rotation);
		yield return new WaitForSeconds (10);
		StartCoroutine(spawnBackground());
	}

	IEnumerator spawnForeground(){
		Instantiate(foreground,new Vector3(baboon.transform.position.x + 50,foreground.transform.position.y,0),foreground.transform.rotation);
		yield return new WaitForSeconds (10);
		StartCoroutine(spawnForeground());
	}
}
