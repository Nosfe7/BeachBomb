using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;




public enum Results{VICTORY, GAMEOVER, NONE};

public class GameLogic : MonoBehaviour {


	public static int level;
	public static int ballCount;
	public static int maxBalls;
	public static Results result;
	public static bool IsStartGame;
	Queue<float> thrusts;
	Queue<float> times;

	// Use this for initialization
	void Start () {

		level = 0;
		maxBalls = 4;
		ballCount = maxBalls;
		result = Results.NONE;

		thrusts = new Queue<float>(new float[]{15.0f,25.0f,40.0f});
		times = new Queue<float>(new float[]{40.0f,30.0f,20.0f});

	}


	void spawnBalls(float thrust){

		GameObject ball = GameObject.Find("ballCopy");

		GameObject ball1 = (GameObject)Instantiate (ball, new Vector3 (2.6f, 306.4f, -74.1f), Quaternion.identity);
		ball1.GetComponent<Rigidbody> ().isKinematic = false;

		GameObject ball2 = (GameObject)Instantiate (ball, new Vector3 (5.7f, 306.4f, -76.3f), Quaternion.identity);
		ball2.GetComponent<Rigidbody> ().isKinematic = false;

		GameObject ball3 = (GameObject)Instantiate (ball, new Vector3 (2.8f, 306.4f, -79.0f), Quaternion.identity);
		ball3.GetComponent<Rigidbody> ().isKinematic = false;

		GameObject ball4 = (GameObject)Instantiate (ball, new Vector3 (0.4f, 306.4f, -76.3f), Quaternion.identity);
		ball4.GetComponent<Rigidbody> ().isKinematic = false;

		//GameObject ball5 = (GameObject)Instantiate (ball, new Vector3 (1.4f, 306.4f, -75.3f), Quaternion.identity);
		//ball5.GetComponent<Rigidbody> ().isKinematic = false;

		Ball.thrust = thrust;

		ballCount = maxBalls;
	}

	// Update is called once per frame
	void Update () {

		//Level 0 (game loading)
		if (level == 0) {


			if (TimeLeft.timeLeft < -3) {
				spawnBalls (thrusts.Dequeue());
				level++;
				TimeLeft.timeLeft = times.Dequeue();
			}

		}

		//Next levels
		if (level > 0 && level < 3){
			if (TimeLeft.timeLeft > 0 && ballCount == 0) {

					TimeLeft.timeLeft = 0;

					this.GetComponent<AudioSource> ().Play ();
					

			} 
			
				else if (TimeLeft.timeLeft < -3 && ballCount == 0){

						spawnBalls (thrusts.Dequeue());

						level++;

						TimeLeft.timeLeft = times.Dequeue();


			}
				else if (TimeLeft.timeLeft <= 0 && ballCount > 0) {

						result = Results.GAMEOVER;

						if (TimeLeft.timeLeft < - 3)
							SceneManager.LoadScene ("menu");

			}

		}

		
		//Last level
		if (level == 3) {

			if (TimeLeft.timeLeft > 0 && ballCount == 0) {

				result = Results.VICTORY;

				TimeLeft.timeLeft = 0;




			} else if (TimeLeft.timeLeft <= -3 && ballCount == 0) {

				SceneManager.LoadScene ("menu");

			} else if (TimeLeft.timeLeft <= 0 && ballCount > 0) {

				result = Results.GAMEOVER;

				if (TimeLeft.timeLeft < -3)
					SceneManager.LoadScene ("menu");
			}

		}



	}


	public void LoadGame(){

		SceneManager.LoadScene ("main");

	}

	public void QuitGame(){

		Application.Quit ();
	}
}
