using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardManager : MonoBehaviour {

	[SerializeField] private List<TextMeshProUGUI> timeDisplays; //list of leaderboard slots

	private List<float> times = new List<float>(); //list of submitted times

	//Add a time to the leaderboard
	public void AddTime(float time) {
		times.Add(time);
		times.Sort();
		//if there are fewer times than spots on the leaderboard, don't try to display them
		int numTimes = times.Count < timeDisplays.Count ? times.Count : timeDisplays.Count;
		for (int i = 0; i < numTimes; ++i)
			timeDisplays[i].SetText(times[i].ToString("0.00"));
	}
}
