using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public GameObject Path_In;

	public GameObject Path_Out;

	public float Time;

	public bool Inside_Panel;



	// Use this for initialization
	void Start () {
	
		Inside_Panel = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveIn()
	{
		iTween.MoveTo (this.gameObject, Path_In.transform.position , Time);
	}

	public void MoveOut()
	{
		iTween.MoveTo (this.gameObject, Path_Out.transform.position , Time);
	}

	public void Move(){

		if (Inside_Panel) {

			iTween.MoveTo (this.gameObject, Path_Out.transform.position , Time);

		} else {

			iTween.MoveTo (this.gameObject, Path_In.transform.position , Time);

		}

		Inside_Panel = !Inside_Panel;


	}


}
