using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent(typeof(CharacterController))]

public class SimpleMoveScript : MonoBehaviour {

	public GameObject moveObj;
	
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;

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

		}
	}
}