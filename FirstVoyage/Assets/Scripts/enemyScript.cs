using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour
{

	public int enemyHealth = 75;
	public int enemySpeed;

	public GameObject thePlayer;
	public GameObject explosion;
    public GameObject healthDrop;

	public CharacterController myController;

	public AudioClip hit, hit2;



	void OnCollisionEnter (Collision other)
	{
		if (other.collider.tag == "shot") {

            //int tempNum = Random.Range (1, 3);

            //if (tempNum == 1) {

            //    AudioSource.PlayClipAtPoint (hit, transform.position);
	
            //} else if (tempNum == 2) {

            //    AudioSource.PlayClipAtPoint (hit2, transform.position);

            //}

			Destroy (other.collider.gameObject);

			enemyHealth -= Random.Range (20, 26);

			if (enemyHealth <= 0) {

                Instantiate(healthDrop, transform.position, transform.rotation);

				Destroy (gameObject);

			}
		}
	}



	// Use this for initialization
	void Start ()
	{
		enemyHealth = Random.Range (50, 76);

		thePlayer = GameObject.FindWithTag ("Player");

		myController = GetComponent<CharacterController> ();
	}



	// Update is called once per frame
	void Update ()
	{
		transform.LookAt (thePlayer.transform.position);

		myController.SimpleMove (transform.forward * enemySpeed);
	}
}
