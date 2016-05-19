using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;



public class playerScript : MonoBehaviour {

	public int numberOfShots;
	public int numberOfTreasures;

	public float shotForce;
	public float playerHealth, maxHealth;

	public Image healthMid;

	public Sprite[] shots;
	public Sprite[] treasures;

	public GameObject shotsUI;
	public GameObject treasureUI;

	public Rigidbody shot;

	public Transform firePoint;

	public AudioClip ammoPU, treasurePU;





	void OnTriggerStay(Collider other)
	{
		if (other.tag == "enemy") {

			playerHealth -= .15f;
			healthMid.fillAmount = playerHealth / maxHealth;

			if (playerHealth <= 0) {

				Application.LoadLevel ("level1");

			}
		}
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "enemy") {

			playerHealth -= 2.5f;
			healthMid.fillAmount = playerHealth / maxHealth;

            //if (playerHealth <= 0) {

            //    Application.LoadLevel ("level1");

            //}
		}
	}



	void OnControllerColliderHit(ControllerColliderHit other)
	{
		if (other.collider.tag == "ammoPU") {

			AudioSource.PlayClipAtPoint (ammoPU, transform.position);
			Destroy (other.gameObject);
			numberOfShots = 10;
		}

		if (other.collider.tag == "treasurePU") {

			AudioSource.PlayClipAtPoint (treasurePU, transform.position);
			Destroy (other.gameObject);
			numberOfTreasures++;
		}
	}



	// Use this for initialization
	void Start () {
	
		shotsUI.GetComponent<Image> ().sprite = shots [numberOfShots];
		treasureUI.GetComponent<Image> ().sprite = treasures [numberOfTreasures];
//		Cursor.visible = false;
	}



	// Update is called once per frame
	void Update () {

		//Cursor.lockState = CursorLockMode.Locked;

		shotsUI.GetComponent<Image> ().sprite = shots [numberOfShots];
		treasureUI.GetComponent<Image> ().sprite = treasures [numberOfTreasures];

		if (InputManager.ActiveDevice.Action2.WasPressed && numberOfShots > 0) {

			numberOfShots--;

			Rigidbody tempBullet = Instantiate (shot, firePoint.position, firePoint.rotation) as Rigidbody;
			tempBullet.velocity = tempBullet.transform.forward * shotForce;

		}
	}
}
