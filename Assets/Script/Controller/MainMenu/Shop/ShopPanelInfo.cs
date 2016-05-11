using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopPanelInfo  {


	private static ShopPanelInfo _shopPanelInfo;

	public static ShopPanelInfo Instance
	{
		get
		{
			if(_shopPanelInfo == null)
			{		
				_shopPanelInfo = new ShopPanelInfo();
			}

			return _shopPanelInfo;
		}
	}
	//

	private ShopItem shopItem = new ShopItem();

	public ShopItem _shopItem{

		set{
			shopItem = value; 
		}get{
			return shopItem;
		}
	}


	public List<Items> getWeapons(){

		List<Items> tempItemList = new List<Items> ();
		List<Items> itemList = new List<Items> ();

		if (shopItem != null) {

			tempItemList = shopItem.getShopItemsList();

			foreach (Items item in tempItemList) {

				if (item.ITMType == ItemType.WEAPON) {
					itemList.Add (item);
				}
			}
		}

		return itemList;

	}

	public List<Items> getArmors(){

		List<Items> tempItemList = new List<Items> ();
		List<Items> itemList = new List<Items> ();

		if (shopItem != null) {

			tempItemList = shopItem.getShopItemsList();

			foreach (Items item in tempItemList) {

				if (item.ITMType == ItemType.ARMOR) {
					itemList.Add (item);
				}
			}
		}

		return itemList;

	}

	public List<Items> getSpell(){

		List<Items> tempItemList = new List<Items> ();
		List<Items> itemList = new List<Items> ();

		if (shopItem != null) {

			tempItemList = shopItem.getShopItemsList();

			foreach (Items item in tempItemList) {

				if (item.ITMType == ItemType.SPELL) {
					itemList.Add (item);
				}
			}
		}

		return itemList;

	}

	public List<Items> getFood(){

		List<Items> tempItemList = new List<Items> ();
		List<Items> itemList = new List<Items> ();
		if (shopItem != null) {

			tempItemList = shopItem.getShopItemsList();

			foreach (Items item in tempItemList) {
//				Debug.Log (item.Name);
				if (item.ITMType == ItemType.FOOD) {
					
					itemList.Add (item);
				}
			}
		}

		return itemList;

	}
















}
