using UnityEngine;
using System.Collections;

public class moveCivi : MonoBehaviour {

	public int move;

	// Use this for initialization
	void Start () {
		move = Random.Range(0,2);
		StartCoroutine(changeDirection());
		Physics.IgnoreCollision(gameObject.collider,GameObject.Find("Baboon").collider);
	}
	
	// Update is called once per frame
	void Update () {
		switch (move){
			case 1:
			transform.Translate(transform.right*0.5f*Time.deltaTime);
			break;
			case 2:
			transform.Translate(-transform.right*0.5f*Time.deltaTime);
			break;
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			StartCoroutine(Die ());
		}
	}

	IEnumerator Die(){
		renderer.enabled = false;
		particleSystem.Emit(10);
		yield return new WaitForSeconds(2);
		Destroy(this.gameObject);
	}

	IEnumerator changeDirection(){
		yield return new WaitForSeconds(Random.Range(1,3));
		if(move == 1){
			move = 2;
		} else {
			move = 1;
		}
		StartCoroutine(changeDirection());
	}
}
