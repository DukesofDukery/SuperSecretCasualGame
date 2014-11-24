using UnityEngine;
using System.Collections;

public class killBox : MonoBehaviour {

	bool loss;
	bool pause;

	public GUISkin skin;

	int xOffset = 1061;
	int yOffset = 597;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(pause){
				Time.timeScale = 1;
				pause = false;
			} else {
				pause = true;
			}
		}
	}

	void OnGUI(){
		Matrix4x4 svMat = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity,new Vector3(Screen.width/(float)xOffset,Screen.height/(float)yOffset,1f));

		if(loss){
			GUI.Label(new Rect(xOffset/2-400,yOffset/2-150,800,150), "No more destruction for you!",skin.label);
			if(GUI.Button(new Rect(xOffset/2-75,yOffset/2,150,50),"Replay",skin.button)){
				Time.timeScale = 1;
				Application.LoadLevel("Main");
			}
			if(GUI.Button(new Rect(xOffset/2-75,yOffset/2+100,150,50),"Main Menu",skin.button)){
				Time.timeScale = 1;
				Application.LoadLevel("Menu");
			}
		}

		if(pause){
			Time.timeScale = 0;
			GUI.Label(new Rect(xOffset/2-125,yOffset/2-100,250,100), "Paused",skin.label);
			if(GUI.Button(new Rect(xOffset/2-75,yOffset/2,150,50),"Replay",skin.button)){
				Time.timeScale = 1;
				Application.LoadLevel("Main");
			}
			if(GUI.Button(new Rect(xOffset/2-75,yOffset/2+100,150,50),"Main Menu",skin.button)){
				Time.timeScale = 1;
				Application.LoadLevel("Menu");
			}
		}

		GUI.matrix = svMat;
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			Time.timeScale = 0;
			loss = true;
		}
	}
}
