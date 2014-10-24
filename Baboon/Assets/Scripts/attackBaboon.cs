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
		
		
		//UPPERCUT
		if(Input.GetKeyDown(KeyCode.W) && Mathf.RoundToInt(rigidbody.velocity.y) == 0){
			GetComponent<Animator>().Play("uppercut");
			rigidbody.AddForce(Vector3.up*2200);
			rigidbody.AddForce(Vector3.right*10);
			
			if(Physics.Raycast(transform.position,Vector3.right,out hit,4f)){
				
				hit.transform.GetComponent<buildingHealth>().health = hit.transform.GetComponent<buildingHealth>().health-2;

				print ("hit");

			}
			
		}
		//BUTT SLAM
		if(Input.GetKeyDown(KeyCode.S) && rigidbody.velocity.y <= 0){
			GetComponent<Animator>().Play("slam");
			rigidbody.AddForce(Vector3.down*6000);
			rigidbody.AddForce(Vector3.right*50);
			
			if(Physics.Raycast(transform.position,Vector3.down*10,out hit,10)){
				
				hit.transform.GetComponent<buildingHealth>().health = hit.transform.GetComponent<buildingHealth>().health-4;
				
				
			}
		}
	}
}
