﻿using UnityEngine;
using System.Collections;

public class moveBaboon : MonoBehaviour {

	public float speed = 5;
	public RaycastHit hit;
	public AudioClip[] punchSound;
	public AudioClip speedUpSound;
	public int speedUpTimer;
	bool spedUp;
	float score;
	public GUIStyle style;
	Vector3 groundedSpeed  = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right*Time.deltaTime*speed);

		score += 0.1f;

		Debug.DrawRay(transform.position,-transform.up*1.3f,Color.red);
		if(Physics.Raycast(new Ray(transform.position,-transform.up),1.3f)){
			if(Input.GetKey(KeyCode.UpArrow) && Mathf.RoundToInt(rigidbody.velocity.y) == 0){

				rigidbody.AddForce(Vector3.up*1700);

			} else {
				rigidbody.velocity = groundedSpeed;
			}
		}

		Debug.DrawRay(transform.position,transform.right*2f,Color.blue);
		if (Physics.SphereCast (new Ray(transform.position,transform.right),1.5f,out hit,1.5f)){
			if(hit.transform.tag == "Building"){
				speed = 0;
				speedUpTimer = 0;
				if(Input.GetKeyDown(KeyCode.Space)){
					Attack(hit);
				}
			}
		} else if(speedUpTimer == 0) {
			speed = 5;
		}

		if(speedUpTimer > 0){
			speedUpTimer--;
			speed = 10;
		}
	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2-50,30,100,100),((int)score).ToString(),style);
	}

	void Attack(RaycastHit building) {
		AudioSource.PlayClipAtPoint(punchSound[Random.Range(0,punchSound.Length)],transform.position);
		if (building.transform.GetComponent<buildingHealth>().health == 1){
			AudioSource.PlayClipAtPoint(speedUpSound,transform.position);
			score += 20;
			speedUpTimer += 100;
		}
		building.transform.GetComponent<buildingHealth>().SendMessage("Damage");
	}

	/*void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag == "Building"){
			if(collider.transform.tag == "Building"){
				speed = 0;
				speedUpTimer = 0;
				if(Input.GetKeyDown(KeyCode.Space)){
					Attack(hit);
				}
			}
		} else if(speedUpTimer == 0) {
			speed = 5;
		}
	}*/
}