using UnityEngine;
using System.Collections;

public class screenSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUI.Box(new Rect(Screen.width/2-100,Screen.height/2-100,200,200),Screen.width + ", "+Screen.height);
	}
}
