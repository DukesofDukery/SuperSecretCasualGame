using UnityEngine;
using System.Collections;

public class attackBaboon : MonoBehaviour {

	public float speed;
	public RaycastHit hit;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z != 0){
			transform.position = new Vector3(0,0,0);
			
		}
		if(transform.position.y < -10){
			transform.position = new Vector3(0,0,0);
			
		}
		
		print (Mathf.RoundToInt(rigidbody.velocity.y));
		if(Input.GetKeyDown(KeyCode.W) && Mathf.RoundToInt(rigidbody.velocity.y) == 0 /*&& GetComponent<moveBaboon>().attackTimer == 0*/){
			rigidbody.AddForce(Vector3.up*800);
			rigidbody.AddForce(Vector3.right*10);
			//GetComponent<moveBaboon>().attackTimer=GetComponent<moveBaboon>().attackCooldown;
			if(Physics.Raycast(transform.position,Vector3.right*2,out hit,2)){
				if(hit.collider.tag == "Building"){
					hit.transform.GetComponent<buildingHealth>().health = hit.transform.GetComponent<buildingHealth>().health-5;
					//break;
				}
			}
			
		}
		
		if(Input.GetKeyDown(KeyCode.S) && rigidbody.velocity.y <= 0 /*&& GetComponent<moveBaboon>().attackTimer == 0*/){
			
			rigidbody.AddForce(Vector3.down*3000);
			rigidbody.AddForce(Vector3.right*50);
			//GetComponent<moveBaboon>().attackTimer=GetComponent<moveBaboon>().attackCooldown;
			if(Physics.Raycast(transform.position,Vector3.down*10,out hit,10)){
				if(hit.collider.tag == "Building"){
					hit.transform.GetComponent<buildingHealth>().health = hit.transform.GetComponent<buildingHealth>().health-7;
					
				}
			}
		}
	}
}
