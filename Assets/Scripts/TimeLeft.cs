using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeLeft : MonoBehaviour {


	Text textComponent;
	//counter to next level
	//static float counter;
	public static float timeLeft;
	static bool isStartCounter;



	// Use this for initialization
	void Start () {

		timeLeft = 0;
		textComponent = this.GetComponent<Text> ();
	}
		
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0 && timeLeft >= -4) {

			if (GameLogic.result == Results.NONE) {
				if (GameLogic.level == 0)
					textComponent.text = "Slow";
				else if (GameLogic.level == 1)
					textComponent.text = "Faster";
				else if (GameLogic.level == 2)
					textComponent.text = "Insane!";
			} else if (GameLogic.result == Results.VICTORY)
				textComponent.text = "Congratulations!";
			else if (GameLogic.result == Results.GAMEOVER)
				textComponent.text = "Try again...";


		} else {
			if (Mathf.Round (timeLeft) >=10)
				textComponent.text = "00 : " + Mathf.Round (timeLeft).ToString ();
			else 
				textComponent.text = "00 : 0" + Mathf.Round (timeLeft).ToString ();
		}
	}
}
