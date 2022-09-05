using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

	private GameObject player;
	
	[SerializeField] private GameObject startButton;

    void Start() {
        player = GameObject.FindWithTag("Player");

    }

	public void OnStartClick() {
		//Allow player to move and pickup objects, then remove start button
		player.GetComponent<PlayerMovement>().enabled = true;
		player.GetComponent<PickupObject>().enabled = true;
		startButton.SetActive(false);

		//Load in trash can and trash
		var trashCan = Resources.Load("Prefabs/TrashCan") as GameObject;
		var cowboyHat = Resources.Load("Prefabs/CowboyHat") as GameObject;
		var car = Resources.Load("Prefabs/Car") as GameObject;
		var volleyBall = Resources.Load("Prefabs/VolleyBall") as GameObject;

		Instantiate(trashCan);
		Instantiate(cowboyHat);
		Instantiate(car);
		Instantiate(volleyBall);
	}

}
