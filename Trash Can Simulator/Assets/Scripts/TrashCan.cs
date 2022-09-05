using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashCan : MonoBehaviour
{
	private TextMeshProUGUI counterText;
	private TextMeshProUGUI timerText;

	private int trashCount = 0;
	private const int TOTAL_TRASH = 3;
	
	private bool timerOn = false;
	private float currentTime = 0;

	void Start() {
		counterText = GameObject.FindWithTag("TrashCounter").GetComponent<TextMeshProUGUI>();
		timerText = GameObject.FindWithTag("Timer").GetComponent<TextMeshProUGUI>();
		counterText.enabled = true;
		timerText.enabled = true;
		timerOn = true;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Trash")) {
			++trashCount;
			counterText.SetText("Trash Collected: " + trashCount);
			Destroy(collision.gameObject);

			if (trashCount >= TOTAL_TRASH) {
				timerOn = false;
			}
		}
	}

	void Update() {
		if (timerOn) {
			currentTime += Time.deltaTime;
			timerText.SetText("Time: " + currentTime.ToString("0.00"));
		}
	}
}
