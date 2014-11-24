using UnityEngine;
using System.Collections;

public class moveBaboon : MonoBehaviour {

	public float speed = 5;
	public RaycastHit hit;
	public AudioClip[] punchSound;
	public AudioClip speedUpSound;
	public int speedUpTimer;
	public int jumpTimer;
	bool spedUp;
	float score;
	public GUIStyle style;
	Vector3 groundedSpeed  = new Vector3(0,0,0);
	public int qTimer=0;


	public Transform deadZone;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.right*Time.deltaTime*speed);

		score += 0.1f*Time.timeScale;

		Debug.DrawRay(transform.position,-transform.up*1.3f,Color.red);
		if(Physics.Raycast(new Ray(transform.position,-transform.up),1.3f)){
			if(Input.GetKey(KeyCode.UpArrow) && Mathf.RoundToInt(rigidbody.velocity.y) == 0){
				jumpTimer = 60;

			} else {
				//rigidbody.velocity = groundedSpeed;
			}
		}

		Debug.DrawRay(transform.position,transform.right*2f,Color.blue);
		if (Physics.SphereCast (new Ray(transform.position,transform.right),1.5f,out hit,1.5f)){
			if(hit.transform.tag == "Building"){
				speed = 0;
				speedUpTimer = 0;
				if(Input.GetKeyDown(KeyCode.Q)){
					if(qTimer==0){
						Attack(hit);
						qTimer=10;
					}
				}
			}
		} else if(speedUpTimer == 0) {
			speed = 5;
		}

		//UPPERCUT
		if(Input.GetKeyDown(KeyCode.W) && Mathf.RoundToInt(rigidbody.velocity.y) == 0){
			GetComponent<Animator>().Play("uppercut");
			jumpTimer = 50;
			
			if(Physics.Raycast(transform.position,Vector3.right,out hit,4f)){
				hit.transform.GetComponent<buildingHealth>().health = hit.transform.GetComponent<buildingHealth>().health-2;
				AudioSource.PlayClipAtPoint(punchSound[0],transform.position);
			}
			
		}

		if(speedUpTimer > 0){
			speedUpTimer--;
			speed = 10;
		}

		if (jumpTimer != 0) {
				jumpTimer--;
				transform.Translate (Vector3.up * Time.deltaTime * jumpTimer / 3);
			if(jumpTimer==1){
				//rigidbody.AddForce(Vector3.down*2000);
			}
		}

		if(qTimer>0){
			qTimer--;
		}

	}

	void OnGUI(){
		GUI.Label(new Rect(Screen.width/2-50,30,100,100),((int)score).ToString(),style);
		GUI.HorizontalSlider(new Rect(20,Screen.height-20,Screen.width-40,20),transform.position.x-deadZone.position.x,3f,40f);
	}

	void Attack(RaycastHit building) {
		AudioSource.PlayClipAtPoint(punchSound[Random.Range(0,punchSound.Length)],transform.position);
		GetComponent<Animator>().Play("punch");
		if (building.transform.GetComponent<buildingHealth>().health == 1){
			AudioSource.PlayClipAtPoint(speedUpSound,transform.position);
			score += 20;
			speedUpTimer += 100;
		}
		building.transform.GetComponent<buildingHealth>().SendMessage("Damage");
	}
}