using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopPanelController : MonoBehaviour {

	public ItemType panelType;

	public GameObject shopItemPrefab;

	private Sprite imageSprite;

	public GameObject MCU;

	// Use this for initialization
	void Awake () {

		shopItemPrefab = Resources.Load ("ShopItem" , typeof(GameObject)) as GameObject;

		MCU = GameObject.Find ("MCU");

		List<Items> tempList = new List<Items> ();

		switch (panelType) {

		case ItemType.ARMOR: 
			tempList = MCU.GetComponent<ItemBundle> ().getAllArmorItems ();
			foreach (Items item in tempList) {
				ShopPanelInfo.Instance._shopItem.addItem (item);
			}
			break;
		case ItemType.FOOD:

			tempList = MCU.GetComponent<ItemBundle> ().getAllFoodItems ();
			foreach (Items item in tempList) {
//				Debug.Log(item.Name);
				ShopPanelInfo.Instance._shopItem.addItem (item);
			}
			break;

		case ItemType.SPELL:
			tempList = MCU.GetComponent<ItemBundle> ().getAllSpellItems ();
			foreach (Items item in tempList) {
				ShopPanelInfo.Instance._shopItem.addItem (item);
			}
			break;

		case ItemType.WEAPON:
			tempList = MCU.GetComponent<ItemBundle> ().getAllWeaponItems ();
			foreach (Items item in tempList) {
				ShopPanelInfo.Instance._shopItem.addItem (item);
			}
			break;

		default :

			break;
				
		
			
		}

		drawPanel ();


	}


	public void drawPanel(){


		if (panelType == ItemType.WEAPON) {

			List<Items> items = new List<Items> ();
			items = ShopPanelInfo.Instance.getWeapons ();

			foreach (Items item in items) {

				GameObject GO = Instantiate(shopItemPrefab);
				GO.name = item.Name;
				GO.transform.SetParent(this.gameObject.transform , false);
				GO.GetComponent<ShopItemHandler> ().setButtonUp (item);
			
			}
		}
			
	
		if (panelType == ItemType.FOOD) {

			List<Items> items = new List<Items> ();
			items = ShopPanelInfo.Instance.getFood ();

			foreach (Items item in items) {

				GameObject GO = Instantiate (shopItemPrefab);
				GO.name = item.Name;
//				Debug.Log ("FUCK YOU :D" + item.Name);
				GO.transform.SetParent(this.gameObject.transform , false);
				GO.GetComponent<ShopItemHandler> ().setButtonUp (item);

			}

		}
		if (panelType == ItemType.ARMOR) {

			List<Items> items = new List<Items> ();
			items = ShopPanelInfo.Instance.getArmors ();

			foreach (Items item in items) {

				GameObject GO = Instantiate (shopItemPrefab);
				GO.transform.SetParent(this.gameObject.transform , false);
				GO.GetComponent<ShopItemHandler> ().setButtonUp (item);
			}

		}
		if (panelType == ItemType.SPELL) {

			List<Items> items = new List<Items> ();
			items = ShopPanelInfo.Instance.getSpell ();

			foreach (Items item in items) {

				GameObject GO = Instantiate (shopItemPrefab);
				GO.transform.SetParent(this.gameObject.transform , false);
				GO.GetComponent<ShopItemHandler> ().setButtonUp (item);


			}

		}
	}
}