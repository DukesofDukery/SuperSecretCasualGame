using UnityEngine;
using System.Collections;

public class moveBuilding : MonoBehaviour {

	public float speed;
	public float health;
	float maxHealth;

	// Use this for initialization
	void Start () {
		maxHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left*speed*Time.deltaTime);

		if(transform.position.x < -10){
			Destroy(this.gameObject);
		}

		if(health == 0){
			Destroy(gameObject);
		}
	}
}
