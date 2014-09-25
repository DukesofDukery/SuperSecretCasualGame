using UnityEngine;
using System.Collections;

public class moveBuilding : MonoBehaviour {

	public float speed;
	public float health;
	float maxHealth;
	public Material[] destructionMaterial;

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

		updateMaterial();
	}

	void updateMaterial(){
		if(health/maxHealth == 1f){
			renderer.material = destructionMaterial[0];
		}
		if(health/maxHealth == 0.75f){
			renderer.material = destructionMaterial[1];
		}
		if(health/maxHealth == 0.5f){
			renderer.material = destructionMaterial[2];
		}
		if(health/maxHealth == 0f){
			renderer.material = destructionMaterial[3];
		}
	}
}
