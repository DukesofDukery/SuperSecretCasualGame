using UnityEngine;
using System.Collections;

public class textControl : MonoBehaviour {

	public bool isQuit = false;
	public int levelToBeLoaded;

	void Start () {
		renderer.material.color = Color.white;
	}

	void OnMouseEnter(){
		//change the color of the text
		renderer.material.color = Color.black;
	}

	void OnMouseExit(){
		//change the color of the text
		renderer.material.color = Color.white;
	}

	void OnMouseUp(){
		if (isQuit) {
			Application.Quit();
		} else {
			Application.LoadLevel(levelToBeLoaded);
		}
	}
}
