using UnityEngine;
using System.Collections;

public class aestheticSpawner : MonoBehaviour {
	
	public GameObject[] foreground;
	public GameObject foliage;
	public GameObject[] civis;
	public Transform baboon;

	// Use this for initialization
	void Start () {
		baboon = GameObject.Find("Baboon").transform;
		StartCoroutine(spawnForeground());
		StartCoroutine(spawnFoliage());
		StartCoroutine(spawnCivi());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator spawnForeground(){
		Instantiate(foreground[Random.Range(0,foreground.Length)],new Vector3(baboon.transform.position.x + 50,foreground[Random.Range(0,foreground.Length)].transform.position.y,0),
		            foreground[Random.Range(0,foreground.Length)].transform.rotation);
		yield return new WaitForSeconds (5);
		StartCoroutine(spawnForeground());
	}

	IEnumerator spawnFoliage(){
		Instantiate(foliage,new Vector3(baboon.transform.position.x + 50,foliage.transform.position.y,0), foliage.transform.rotation);
		yield return new WaitForSeconds (3.9f);
		StartCoroutine(spawnFoliage());
	}

	IEnumerator spawnCivi(){
		Instantiate(civis[Random.Range(0,civis.Length)],new Vector3(baboon.transform.position.x + 50,civis[Random.Range(0,civis.Length)].transform.position.y,0), civis[Random.Range(0,civis.Length)].transform.rotation);
		yield return new WaitForSeconds (Random.Range(1,3));
		StartCoroutine(spawnCivi());
	}
}
