using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Camera cam;	
	private CharacterController controller;

	[SerializeField] private float mouseSensitivity = 200f;
	[SerializeField] private float walkSpeed = 4;
	
	private float totalCamXRotation = 0f; //X rotation controls looking up/down
	

    void Start() {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		controller = GetComponent<CharacterController>();
		Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
		//~~~~~~~LOOK AROUND~~~~~~~
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		
		totalCamXRotation -= mouseY;
		totalCamXRotation = Mathf.Clamp(totalCamXRotation, -90f, 90f); //Prevent player from looking too high or too low
		
		transform.Rotate(Vector3.up * mouseX); //rotate player left/right
		cam.transform.localEulerAngles = new Vector3(totalCamXRotation, 0f, 0f); //rotate cam up/down

		//~~~~~~~MOVE AROUND~~~~~~~
		float movementX = Input.GetAxisRaw("Horizontal") * walkSpeed * Time.deltaTime;
		float movementZ = Input.GetAxisRaw("Vertical")   * walkSpeed * Time.deltaTime;

		//Construct vector using local x and z axes.
		Vector3 moveVector = (transform.right * movementX) + (transform.forward * movementZ);
		controller.Move(moveVector);	
    }
}
