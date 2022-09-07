using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupObject : MonoBehaviour {
	[SerializeField] private Transform holdLocation;
	[SerializeField] private int pickupRange = 2;
	private Transform heldObject;
	private Camera cam;
	[SerializeField] private Text crosshairUi;

	void Start() {
		cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}

    void Update() {
		crosshairUi.color = Color.black; //Default crosshair to black

		RaycastHit hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, pickupRange)) {
			
			if (hit.transform.CompareTag("Trash") && heldObject == null) { //when mousing over trash
				crosshairUi.color = Color.green; //change crosshair to green
				if (Input.GetMouseButtonDown(0)) { //hold trash on click
					heldObject = hit.transform;
					heldObject.SetParent(holdLocation);
					heldObject.localPosition = Vector3.zero;
					Destroy(heldObject.Find("Light").gameObject); //remove point light
				}
			}

		}
    }
}
