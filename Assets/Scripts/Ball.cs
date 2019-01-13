using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


	public float thrust;

	// Use this for initialization
	void Start ()
    {
		GetComponent<Rigidbody> ().AddForce (new Vector3(0.5f,0,0.5f)*thrust, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
    {
		RaycastHit hitInfo = new RaycastHit ();


		bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo, Mathf.Infinity);

		if (Input.GetMouseButton(0) && hit && hitInfo.collider == GetComponent<SphereCollider>() && TimeManager.timeLeft >=0)
        {
            //decrement balls counter
            GameManager.Instance.ballCount -= 1;

			//play explosion animation
			GameObject effect = GameObject.Find("Explosion");

			Instantiate(effect,this.gameObject.transform.position,Quaternion.identity);

			effect.GetComponentInChildren<Animator> ().Play (0);

            //Play sound
            effect.GetComponent<AudioSource>().Play();

            //destroy object
            Destroy(gameObject);
		}


		//If object is not moving, apply new force to move it
		Vector3 velocity = this.gameObject.GetComponent<Rigidbody> ().velocity;

		if (velocity.x >=0 && velocity.x<=0.05 || velocity.z>=0 && velocity.z<=0.05)
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(Random.Range(0.5f,1),0,Random.Range(0.5f,1))*thrust, ForceMode.Impulse);
	}
		
		
}
