using UnityEngine;
using System.Collections;

public class buildingHealth : MonoBehaviour {

	public float health = 4f;
	float maxHealth;

	// Use this for initialization
	void Start () {
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 0){
			Destroy (this.gameObject);
		}
	}

	void Damage(){
		health--;
		if(health/maxHealth == 0.75f){
			animation.Play("buildingDestroy1");
		}
		if(health/maxHealth == 0.5f){
			animation.Play("buildingDestroy2");
		}
		if(health/maxHealth == 0.25f){
			animation.Play("buildingDestroy3");
		}

	}
}
