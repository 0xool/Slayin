using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ShopMenuBarButton : MonoBehaviour {

	public ButtonNames BTName;

	public Sprite oldImage;

	public Sprite newImage;

	public GameObject GO;

	void Start(){

		GO = GameObject.Find("ShopMenuBar");

	}

	public void ButtonClicked(){


		GO.GetComponent<ShopMenuBarButtonController> ().changeButton(BTName);

		this.gameObject.GetComponent<Image> ().sprite = newImage;

	}


	public void resetImage(){

		this.gameObject.GetComponent<Image> ().sprite = oldImage;

		}



}
