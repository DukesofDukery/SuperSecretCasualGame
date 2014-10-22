using UnityEngine;
using System.Collections;

public class expireObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Expire());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Expire(){
		yield return new WaitForSeconds(60);
		Destroy(this.gameObject);
	}
}
