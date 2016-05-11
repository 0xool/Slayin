using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public enum ButtonNames{
	FoodButton,
	WeaponButton,
	ArmorButton,
	SpellButton
}

public class ShopMenuBarButtonController : MonoBehaviour {

	public ButtonNames buttonName;

	void Start(){

		buttonName = ButtonNames.FoodButton;

	}

	public void changeButton(ButtonNames btnName){

		Debug.Log (btnName.ToString ());

		if(btnName != buttonName){


			hidePanels ();
			showPanel (btnName);

			if (buttonName == ButtonNames.SpellButton) {
				GameObject.Find ("SpellButton").GetComponent<ShopMenuBarButton> ().resetImage ();

			}

			if (buttonName == ButtonNames.ArmorButton) {
				GameObject.Find ("ArmorButton").GetComponent<ShopMenuBarButton> ().resetImage ();

			}

			if (buttonName == ButtonNames.WeaponButton) {
				GameObject.Find ("WeaponButton").GetComponent<ShopMenuBarButton> ().resetImage ();

			}

			if (buttonName == ButtonNames.FoodButton) {
				GameObject.Find ("FoodButton").GetComponent<ShopMenuBarButton> ().resetImage ();
			}
				

			


			buttonName = btnName;

		}



	}

	public void hidePanels(){

		GameObject.Find ("ShopView").transform.Find("FoodPanel").gameObject.SetActive(false);
		GameObject.Find ("ShopView").transform.Find("WeaponPanel").gameObject.SetActive(false);
		GameObject.Find ("ShopView").transform.Find("SpellPanel").gameObject.SetActive(false);
		GameObject.Find ("ShopView").transform.Find("ArmorPanel").gameObject.SetActive(false);

	}

	public void showPanel(ButtonNames BTNames){

		if (BTNames == ButtonNames.FoodButton) {
			GameObject.Find ("ShopView").transform.Find("FoodPanel").gameObject.SetActive(true);
		}

		if (BTNames == ButtonNames.WeaponButton) {
			GameObject.Find ("ShopView").transform.Find("WeaponPanel").gameObject.SetActive(true);
		}

		if (BTNames == ButtonNames.SpellButton) {
			GameObject.Find ("ShopView").transform.Find("SpellPanel").gameObject.SetActive(true);
		}

		if (BTNames == ButtonNames.ArmorButton) {
			GameObject.Find ("ShopView").transform.Find("ArmorPanel").gameObject.SetActive(true);
		}



	}













}
