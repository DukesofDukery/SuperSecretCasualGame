using UnityEngine;
using System.Collections;

public class buildingHealth : MonoBehaviour {

	public float health = 4f;
	public float maxHealth;
	Animator anim;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		anim = transform.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 keepGrounded = new Vector3(transform.position.x,collider.bounds.size.y/2-1.5f,0);
		transform.position = keepGrounded;

		if(health <= 0){
			Destroy (this.gameObject);
		}

		anim.SetInteger("health",(int)(health/maxHealth*100));
	}

	void Punch(){
		health -= 1;
		particleSystem.Emit(5);
	}

	void Uppercut(){
		health -= 2;
		particleSystem.Emit(10);
	}

	void Slam(){
		health -= 4;
		particleSystem.Emit(15);
	}
}