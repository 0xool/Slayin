using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopItemHandler : MonoBehaviour {

	private Items item;

	public GameObject shopView;




	void Start () {


	
//		SIM = new ShopItemModel ();
//
//		SIM.Name = this.name;
//
//		SIM.Descriptiom = this.description;
//
//		SIM.ID = this.id;
//
//		SIM.Price = this.price;
//
//		SIM.Image = this.image;


	}

	public void itemClicked(){

		shopView = GameObject.Find("ShopView");
		GameObject.Find ("ShopView").GetComponent<ShopViewHandler> ().setItemLargeIcon (item);

	}

	public void setButtonUp(Items item){

		this.item = item;

		this.gameObject.GetComponentInChildren<Text> ().text = name;

		foreach (Transform Child in this.gameObject.transform) {

			if (Child.name == "ChildImage") {

				Sprite imageSprite = GameObject.Find ("ShopView").GetComponent<ImageResource> ().getImageByName (item.Name);
					
				Child.GetComponent<Image> ().sprite = imageSprite;

			}

			if (Child.name == "Text") {
				Child.GetComponent<Text> ().text = item.Name;
			}


		}


	}


}
