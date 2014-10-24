using UnityEngine;
using System.Collections;

public class killBox : MonoBehaviour {

	bool loss;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(loss){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2,200,100), "No more destruction for you!");
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+50,100,50),"Replay")){
				Time.timeScale = 1;
				Application.LoadLevel("Main");
			}
			if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2+100,100,50),"Main Menu")){
				Time.timeScale = 1;
				Application.LoadLevel("Menu");
			}
		}
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag == "Player"){
			Time.timeScale = 0;
			loss = true;
		}
	}
}
