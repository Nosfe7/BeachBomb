using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeManager : MonoBehaviour
{
	public static float timeLeft; //time left to next level

    Text textComponent;
    bool isCounterStarted;


	// Use this for initialization
	void Start ()
    {
		timeLeft = 0;
		textComponent = GetComponent<Text> ();
	}
		
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0 && timeLeft >= -4)
        {

			if (GameManager.Instance.result == Results.NONE)
            {
				if (GameManager.Instance.currentLevel == 0)
					textComponent.text = "Slow";
				else if (GameManager.Instance.currentLevel == 1)
					textComponent.text = "Faster";
				else if (GameManager.Instance.currentLevel == 2)
					textComponent.text = "Insane!";
			}
            else if (GameManager.Instance.result == Results.VICTORY)
				textComponent.text = "Congratulations!";
			else if (GameManager.Instance.result == Results.GAMEOVER)
				textComponent.text = "Try again...";


		}
        else
        {
			if (Mathf.Round (timeLeft) >=10)
				textComponent.text = "00 : " + Mathf.Round (timeLeft).ToString ();
			else 
				textComponent.text = "00 : 0" + Mathf.Round (timeLeft).ToString ();
		}
	}
}
