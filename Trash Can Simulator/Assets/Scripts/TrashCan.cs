using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashCan : MonoBehaviour {
	private GameDirector gameDirector;

	void Start() {
		gameDirector = GameObject.FindWithTag("GameScreen").GetComponent<GameDirector>();
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Trash")) { //Handle trash collision
			gameDirector.IncrementTrashCount();
			Destroy(collision.gameObject);
		}
	}
}
