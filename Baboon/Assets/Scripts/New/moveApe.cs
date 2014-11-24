using UnityEngine;
using System.Collections;

public class moveApe : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(transform.right*0.5f*Time.deltaTime);
	}
}
