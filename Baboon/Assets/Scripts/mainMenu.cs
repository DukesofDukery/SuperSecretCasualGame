using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	int xOffset = 1061;
	int yOffset = 597;

	public GUISkin skin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up*Time.deltaTime);
	}

	void OnGUI(){
		Matrix4x4 svMat = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity,new Vector3(Screen.width/(float)xOffset,Screen.height/(float)yOffset,1f));

		if(GUI.Button(new Rect (xOffset/2+100,yOffset/2-60,120,84),"Play",skin.button)){
			Application.LoadLevel(1);
		}

		if(GUI.Button(new Rect (xOffset/2+100,yOffset/2+40,120,84),"Quit",skin.button)){
			Application.Quit();
		}

		GUI.matrix = svMat;
	}
}
