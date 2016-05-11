using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ButtonClickImageUpdate : MonoBehaviour {

	public Sprite newSprite;

	public Sprite oldSprite;

	private Image image;

	// Use this for initialization
	void Start () {
	
		image = this.gameObject.GetComponent<Image> ();



	}

	public void onCickChangeImage(){



		image.sprite = newSprite;	

		if (this.gameObject.activeSelf)
			StartCoroutine (createNewDelay (0.1f));
		else
			image.sprite = oldSprite;
	
	}

	public int parseImageName(string name){

		string[] temp = name.Split ('_');


			
		return  Int32.Parse(temp [1]);

	}

	IEnumerator createNewDelay(float seconds) {

		yield return new WaitForSeconds(seconds);

		image.sprite = oldSprite;
	}
	

}
