using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent(typeof(CharacterController))]

public class SimpleMoveScript : MonoBehaviour {

	public GameObject moveObj;
	
	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 14.0f;

	private Vector3 moveDirection = Vector3.zero;

	public float rotateSpeed = 3.0f;



	void Update() {

		InputDevice device = InputManager.ActiveDevice;

		CharacterController controller = GetComponent<CharacterController>();

		//if (moveObj.tag == "MainCamera") {

			transform.Rotate(0, device.RightStickX * rotateSpeed, 0);

		//}

		if (moveObj.tag == "Player") {

			//transform.Rotate(0, device.LeftStickX * -rotateSpeed, 0);

			Vector3 forward = transform.TransformDirection (Vector3.forward);

			float curSpeed = speed * device.LeftStickY;

			controller.SimpleMove(forward * curSpeed);

//			moveDirection = new Vector3 (0, 0, device.LeftStickY);
//
//			moveDirection = transform.TransformDirection (moveDirection);
//
//			moveDirection *= speed;

			if (InputManager.ActiveDevice.Action1.WasPressed) {

				moveDirection.y = jumpSpeed;
			}

			moveDirection.y -= gravity * Time.deltaTime;
			controller.Move (moveDirection * Time.deltaTime);

		}
	}
}