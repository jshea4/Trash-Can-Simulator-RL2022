using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
Unfortunately, when a player's Cursor is locked, Unity
prevents them from interacting with UI elements. This 
script gets around that by firing a ray at the UI.
*/

public class WorldUIRaycaster : MonoBehaviour {
    private GraphicRaycaster raycaster;
    private PointerEventData pointerEventData;
    private EventSystem eventSystem;

	[SerializeField] private GameObject startButton; 
	[SerializeField] private GameObject playAgainButton; 
	[SerializeField] private GameObject resetButton; 

    void Start() {
        raycaster = GetComponent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
			//Create new pointer event and set its position to the mouse position
            pointerEventData = new PointerEventData(eventSystem);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse position
            raycaster.Raycast(pointerEventData, results);

            //Loop through list of results
            foreach (RaycastResult result in results) {

				//if the ray hit one of our buttons, invoke their click events.
                if (result.gameObject == startButton)  
					startButton.GetComponent<Button>().onClick.Invoke();
				else if (result.gameObject == playAgainButton) 
					playAgainButton.GetComponent<Button>().onClick.Invoke();
				else if (result.gameObject == resetButton)
					resetButton.GetComponent<Button>().onClick.Invoke();
					
            }
        }
    }
}
