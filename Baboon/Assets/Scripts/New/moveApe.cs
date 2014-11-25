using UnityEngine;
using System.Collections;

public class moveApe : MonoBehaviour {
	
	public float speed = 5;
	public float score;
	public GUISkin skin;
	bool isGrounded = true;
	int layerMask = 1 << 8;
	RaycastHit buildingHit;
	public AudioClip[] sfxs;
	public Transform deadZone;
	ParticleSystem particles;
	float qTimer=0f;
	float changeAnimWait=0f;

	int xOffset = 1061;
	int yOffset = 597;

	// Use this for initialization
	void Start () {
		deadZone = GameObject.Find("Kill Box").transform;
		particles = transform.GetChild(0).particleSystem;
		//Increased gravity
		Physics.gravity = new Vector3(0, -100.0F, 0);

	}
	
	// Update is called once per frame
	void Update () {
		print (changeAnimWait);
		qTimer = qTimer - Time.deltaTime;
		changeAnimWait = changeAnimWait - Time.deltaTime;

		if(!isGrounded){
			particles.Play();
		}

		transform.Translate(Vector3.right*Time.deltaTime*speed);
		
		score += 0.1f*Time.timeScale;

		//Punch
		if(Input.GetKeyDown(KeyCode.Q)){
			GetComponent<Animator>().Play("punch");
			changeAnimWait=5f;
			if(Physics.Raycast(transform.position,Vector3.right,5f,layerMask)){
				if(qTimer<=0){
					AudioSource.PlayClipAtPoint(sfxs[0],transform.position);
					Physics.Raycast(transform.position,Vector3.right,out buildingHit,5f,layerMask);
					if(buildingHit.transform.GetComponent<buildingHealth>().health -1 <= 0 && speed == 5){
						score += 10;
						AudioSource.PlayClipAtPoint(sfxs[1],transform.position);
						speed = 10;
						StartCoroutine(slowDown());
					}
					buildingHit.transform.GetComponent<buildingHealth>().SendMessage("Punch");
					qTimer=.15f;

				}
			}
		}
		
		//Uppercut
		if(Input.GetKeyDown(KeyCode.W)){
			GetComponent<Animator>().Play("uppercut");
			changeAnimWait=5f;
			if(isGrounded){
				isGrounded = false;
				rigidbody.AddForce(Vector3.up*12000);
			}
			
			if(Physics.Raycast(transform.position,Vector3.right,5f,layerMask)){
				AudioSource.PlayClipAtPoint(sfxs[0],transform.position);
				Physics.Raycast(transform.position,Vector3.right,out buildingHit,5f,layerMask);
				if(buildingHit.transform.GetComponent<buildingHealth>().health - 2 <= 0 && speed == 5){
					score += 10;
					AudioSource.PlayClipAtPoint(sfxs[1],transform.position);
					speed = 10;
					StartCoroutine(slowDown());
				}
				buildingHit.transform.GetComponent<buildingHealth>().SendMessage("Uppercut");

			}
		}
		
		//Slam
		if(Input.GetKeyDown(KeyCode.E)){

			GetComponent<Animator>().Play("slam");
			changeAnimWait=5f;
			if(!isGrounded){
				rigidbody.AddForce(Vector3.down*5000);
			}
			if(Physics.Raycast(transform.position,Vector3.down,10f,layerMask)){
				AudioSource.PlayClipAtPoint(sfxs[0],transform.position);
				Physics.Raycast(transform.position,Vector3.down,out buildingHit,10f,layerMask);
				if(buildingHit.transform.GetComponent<buildingHealth>().health - 4 <= 0 && speed == 5){
					score += 10;
					AudioSource.PlayClipAtPoint(sfxs[1],transform.position);
					speed = 10;
					StartCoroutine(slowDown());
				}
				buildingHit.transform.GetComponent<buildingHealth>().SendMessage("Slam");

			}
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
			isGrounded = false;
			rigidbody.velocity = new Vector3(0,0,0);
			rigidbody.AddForce(Vector3.up*20000);
		}
		
		if(Physics.Raycast(transform.position,Vector3.down,1.5f,layerMask)){
			isGrounded = true;
		}

		if(!Physics.Raycast(transform.position,Vector3.down,1.5f)){
			isGrounded = false;
		}
		
		if(!Physics.Raycast(transform.position,Vector3.right,5f,layerMask) && buildingHit.normal != null){
			buildingHit.Equals(null);
		}

		if(!isGrounded){
			if(changeAnimWait<=0){
				GetComponent<Animator>().Play("falling");
			}
		} else if(changeAnimWait<=0) {
			GetComponent<Animator>().Play("run");
		}
	}
	
	void OnGUI(){
		Matrix4x4 svMat = GUI.matrix;
		GUI.matrix = Matrix4x4.TRS(new Vector3(0,0,0), Quaternion.identity,new Vector3(Screen.width/(float)xOffset,Screen.height/(float)yOffset,1f));

		GUI.Label(new Rect(xOffset/2-100,30,200,100),((int)score).ToString(),skin.label);
		//GUI.HorizontalSlider(new Rect(20,Screen.height-20,Screen.width-40,20),transform.position.x-deadZone.position.x,3f,40f);

		GUI.matrix = svMat;
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.layer == 9){
			isGrounded = true;
		}
	}

	IEnumerator slowDown(){
		yield return new WaitForSeconds(2);
		speed = 5;
	}
}