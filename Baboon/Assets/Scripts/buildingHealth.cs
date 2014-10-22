using UnityEngine;
using System.Collections;

public class buildingHealth : MonoBehaviour {

	public float health = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(health == 0){
			Destroy (this.gameObject);
		}
	}

	void Damage(){
		health--;
		if(health == 3){
			animation.Play("buildingDestroy1");
		}
	}
}
