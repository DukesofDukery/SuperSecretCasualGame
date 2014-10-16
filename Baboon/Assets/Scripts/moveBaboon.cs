using UnityEngine;
using System.Collections;

public class moveBaboon : MonoBehaviour {
	
	public float speed;
	public float minPosition;
	public float maxPosition;
	public RaycastHit hit;
	public RaycastHit ground;
	public int attackCooldown;
	public int attackTimer;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//Move and Clamp Movement
		transform.Translate(Vector3.left*Time.deltaTime*speed);

		Vector3 clampPos = new Vector3 (Mathf.Clamp(transform.position.x,minPosition,maxPosition),transform.position.y,transform.position.z);
		transform.position = clampPos;

		//Jump
		Debug.DrawRay(transform.position,-transform.up*1.2f,Color.red);
		if(Input.GetKey(KeyCode.UpArrow) && rigidbody.velocity.y <= 0 && Physics.Raycast (new Ray(transform.position,-transform.up),1.2f)){
			rigidbody.AddForce(Vector3.up*500);
		}

		//Game Over
		if(transform.position.x  <= -8){
			Debug.Log ("Game Over");
		}

		// Attack Mechanic
		if(Input.GetKeyDown(KeyCode.Space) && attackTimer == 0){
			attackTimer = attackCooldown;
			Attack();
		}

		if(attackTimer != 0){
			attackTimer --;
		}

	}

	void OnGUI(){
		GUI.HorizontalSlider (new Rect(20,20,100,20),transform.position.x,minPosition,maxPosition);
		GUI.Box(new Rect(20,40,135,22),"Attack Cooldown: "+attackTimer);
	}

	void OnTriggerEnter(Collider building){
		if(building.gameObject.tag == "Building"){
			speed = building.GetComponent<moveBuilding>().speed;
		}
	}

	void OnTriggerExit(Collider building){
		if(building.gameObject.tag == "Building"){
			speed = 0;
		}
	}

	void Attack(){
		if(Physics.Raycast(transform.position,Vector3.right*2,out hit,2)){
			if(hit.collider.tag == "Building"){
				hit.transform.GetComponent<moveBuilding>().health --;
				if(hit.transform.GetComponent<moveBuilding>().health == 0){
					speed = 0;
				}
			}
		}
	}
}