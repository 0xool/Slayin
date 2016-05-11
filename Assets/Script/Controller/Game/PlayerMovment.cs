using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

	private GameObject playerGameObject;

	public float jumpPower;

	public float speed = 3;

	private bool ableToJump;

	bool goleft = false;

	bool goright = false;

	public void ondownMoveLeft()
	{ goleft = true; }

	public void ondownMoveRight()
	{ goright = true; }

	public void onupMoveLeft()
	{ goleft = false;
	}

	public void onupMoveRight()
	{ goright = false; }

	// Use this for initialization
	void Start () {
	
		playerGameObject = GameObject.Find ("Player");

		ableToJump = true;

	}
	
	// Update is called once per frame


		

		void Update()
		{
			if(goright == true)
			{ transform.Translate(Vector3.right * speed * Time.deltaTime); }
			if(goleft == true)
			{ transform.Translate(Vector3.left * speed * Time.deltaTime); }
		}



	public void playerJump(){

		if(ableToJump)
			playerGameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 ( 0 , jumpPower ));
		ableToJump = false;

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("ApplyDamage", 10);

	

		ableToJump = true;

	}


}
