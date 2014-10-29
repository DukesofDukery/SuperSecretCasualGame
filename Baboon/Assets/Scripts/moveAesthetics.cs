using UnityEngine;
using System.Collections;

public class moveAesthetics : MonoBehaviour {

	public float speed;
	public bool isCloud;

	// Use this for initialization
	void Start () {
		StartCoroutine(Die());
		if(isCloud){
			speed = Random.Range(0.01f,0.05f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(-transform.right*speed*Time.timeScale);
	}

	IEnumerator Die(){
		yield return new WaitForSeconds(30);
		Destroy(this.gameObject);
	}
}
