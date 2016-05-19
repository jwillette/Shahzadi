using UnityEngine;
using System.Collections;

public class fireScript : MonoBehaviour {

	public float fireDeath;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, fireDeath);	
	}


	void OnCollisionEnter(Collision other) {

		if (other.collider.tag == "terrain") {
		
			Destroy (gameObject);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
