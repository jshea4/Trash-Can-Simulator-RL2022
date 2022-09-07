using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

	private GameObject player;
	
	[SerializeField] private GameObject startButton;
	[SerializeField] private TextMeshProUGUI counterText;
	[SerializeField] private TextMeshProUGUI timerText;
	[SerializeField] private GameObject youWinUi;

	private int trashCount = 0;
	private const int TOTAL_TRASH = 3;
	
	private bool timerOn = false;
	private float currentTime = 0;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

	//~~~~~~GAME SETUP FUNCTIONS~~~~~~
	public void LoadObjects(bool loadTrashCan = true) {
		//Remove start button
		startButton.SetActive(false);
		
		//Load in trash
		var cowboyHat = Resources.Load("Prefabs/CowboyHat") as GameObject;
		var car = Resources.Load("Prefabs/Car") as GameObject;
		var volleyBall = Resources.Load("Prefabs/VolleyBall") as GameObject;

		Instantiate(cowboyHat);
		Instantiate(car);
		Instantiate(volleyBall);

		if (loadTrashCan) { //load in trash can, if flash is true
			var trashCan = Resources.Load("Prefabs/TrashCan") as GameObject;
			Instantiate(trashCan);
		}

		counterText.enabled = true; //enable the proper ui elements
		timerText.enabled = true;
		timerOn = true; //start the timer
	}

	public void ResetScene() {
		SceneManager.LoadScene("MainScene");
	}

	public void Restart() { //Restart the game without resetting the scene.
		youWinUi.SetActive(false);
		trashCount = 0;
		currentTime = 0;
		counterText.SetText("Trash Collected: " + trashCount);
		timerText.SetText("Time: " + currentTime.ToString("0.00"));
		timerOn = true;
		LoadObjects(false);
	}

	//~~~~~~GAME FUNCTIONALITY FUNCTIONS~~~~~~
	public void IncrementTrashCount() {
		
		++trashCount;
		counterText.SetText("Trash Collected: " + trashCount);

		//When the user has collected enough trash, end the game
		if (trashCount >= TOTAL_TRASH) { 
			timerOn = false;
			youWinUi.SetActive(true);
		}
		
	}

	void Update() { //Timer control
		if (timerOn) { 
			currentTime += Time.deltaTime;
			timerText.SetText("Time: " + currentTime.ToString("0.00"));
		}
	}

}
