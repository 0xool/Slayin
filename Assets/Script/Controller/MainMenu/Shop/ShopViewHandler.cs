using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopViewHandler : MonoBehaviour {

	private string currentItemName;
	private string currentItemDescription;
	private int currentItemID;

	private int currentPrice;
 	private Sprite currentItemSprite;
	private bool instantiated;


	public GameObject itemImage;
	public GameObject descriptionPanel;
	public GameObject nameLabel;
	public GameObject PriceLabel;
	public GameObject Button;



	// Use this for initialization
	void Start () {

		instantiated = true;

	}
	
	// Update is called once per frame
	void Update () {
	



	}

	public void setItemLargeIcon(Items item){


		foreach(Transform child in transform){

			checkChangeInInfo (item.Name, item.Description, item.ID, item.Price, item.Image, child);

		}


	}

	public void checkChangeInInfo(string itemName , string itemDescription , int itemID , int itemPrice , string itemImageName  , Transform child){

		Sprite itemSprite = GameObject.Find ("ShopView").GetComponent<ImageResource> ().getImageByName (itemImageName);

		if (instantiated) {


			instantiated = false;
			itemImage.SetActive (true);
			descriptionPanel.SetActive (true);
			nameLabel.SetActive (true);
			PriceLabel.SetActive (true);
			Button.SetActive (true);

			if (currentPrice != itemPrice) {
				currentPrice = itemPrice;
			}

			if (currentItemID != itemID) {
				currentItemID = itemID;
			}

			if (currentItemName != itemName) {
				currentItemName = itemName;
			}

			if (currentItemSprite = itemSprite) {
				currentItemSprite = itemSprite;
			}

			if (currentItemDescription != itemDescription) {
				currentItemDescription = itemDescription;
			}

		}

		if (child.name == "PriceLabel") {


				child.GetComponent<Text> ().text = itemPrice.ToString ();


		}

		if (child.name == "ItemImage") {


			child.GetComponent<Image> ().sprite = itemSprite;

		}

		if (child.name == "NameLabel") {


				child.GetComponent<Text> ().text = itemName;
		}
			

		if(child.name == "Discription"){


			child.GetComponentInChildren<Text> ().text = itemDescription;

			}




	}



}
