using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ChangeText : MonoBehaviour {

	private Text text;

	public string firstText;

	public string secondaryText;

	private bool textSetter = true;



	// Use this for initialization
	void Start () {
	

		text = this.gameObject.GetComponent<Text> ();

	}

	public void changeText(){

		if (textSetter) {
			text.text = secondaryText;
		} else {
			text.text = firstText;
		}

		textSetter = !textSetter;

	}

}
