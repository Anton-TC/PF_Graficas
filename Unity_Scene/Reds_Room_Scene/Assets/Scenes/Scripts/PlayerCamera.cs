using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
	[SerializeField]
	float sensitivity;
	[SerializeField]
	Transform playerBody;

	float rotX = 0f;
	float rotY = 0f;

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update() {
		rotY += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
		rotX += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -90f, 90f);

		playerBody.localEulerAngles = new Vector3(0, rotY, 0);
		transform.localEulerAngles = new Vector3(-rotX, 0, 0);

		if (Input.GetKeyDown(KeyCode.Escape)) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if (Cursor.visible && Input.GetMouseButtonDown(1)) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}