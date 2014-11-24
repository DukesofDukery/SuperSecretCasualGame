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

	int xOffset = 1061;
	int yOffset = 597;

	// Use this for initialization
	void Start () {
		deadZone = GameObject.Find("Kill Box").transform;
		particles = transform.GetChild(0).particleSystem;
	}
	
	// Update is called once per frame
	void Update () {

		if(speed == 10){
			StartCoroutine(slowDown());
		}

		if(!isGrounded){
			particles.Play();
		}

		transform.Translate(Vector3.right*Time.deltaTime*speed);
		
		score += 0.1f*Time.timeScale;

		//Punch
		if(Input.GetKeyDown(KeyCode.Q)){
			GetComponent<Animator>().Play("punch");
			if(Physics.Raycast(transform.position,Vector3.right,5f,layerMask)){
				AudioSource.PlayClipAtPoint(sfxs[0],transform.position);
				Physics.Raycast(transform.position,Vector3.right,out buildingHit,5f,layerMask);
				if(buildingHit.transform.GetComponent<buildingHealth>().health -1 <= 0 && speed == 5){
					score += 10;
					AudioSource.PlayClipAtPoint(sfxs[1],transform.position);
					speed = 10;
				}
				buildingHit.transform.GetComponent<buildingHealth>().SendMessage("Punch");
			}
		}
		
		//Uppercut
		if(Input.GetKeyDown(KeyCode.W)){
			GetComponent<Animator>().Play("uppercut");
			if(isGrounded){
				isGrounded = false;
				rigidbody.AddForce(Vector3.up*4000);
			}
			
			if(Physics.Raycast(transform.position,Vector3.right,5f,layerMask)){
				AudioSource.PlayClipAtPoint(sfxs[0],transform.position);
				Physics.Raycast(transform.position,Vector3.right,out buildingHit,5f,layerMask);
				if(buildingHit.transform.GetComponent<buildingHealth>().health - 2 <= 0 && speed == 5){
					score += 10;
					AudioSource.PlayClipAtPoint(sfxs[1],transform.position);
					speed = 10;
				}
				buildingHit.transform.GetComponent<buildingHealth>().SendMessage("Uppercut");
			}
		}
		
		//Slam
		if(Input.GetKeyDown(KeyCode.E)){
			GetComponent<Animator>().Play("slam");
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
				}
				buildingHit.transform.GetComponent<buildingHealth>().SendMessage("Slam");
			}
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
			isGrounded = false;
			rigidbody.velocity = new Vector3(0,0,0);
			rigidbody.AddForce(Vector3.up*5000);
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
			GetComponent<Animator>().Play("falling");
		} else {
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