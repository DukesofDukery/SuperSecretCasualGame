using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour {

	//Transform baboon;

	// Use this for initialization
	void Start () {
		//baboon = GameObject.Find("prefabBaboon").transform;
	}
	
	// Update is called once per frame
	void Update () {
		/*Vector3 followBaboon = new Vector3(transform.position.x, baboon.position.y,0);
		transform.position = followBaboon;*/
		transform.Translate(Vector3.right*Time.deltaTime*4.8f);
	}
}
