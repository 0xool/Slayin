using UnityEngine;
using System.Collections.Generic;
using System.Linq;


public class ShopItem  {


	private Dictionary<int , Items> items = new Dictionary<int, Items> ();



	public void addItem(Items items){

		this.items.Add (items.ID, items);

	}

	public void deleteItem(Items item){

		this.items.Remove (item.ID);

	}

	public Items getItemByID(int id){

		Items theItem;

		if (this.items.TryGetValue (id , out theItem)) {

			return theItem;

		} else {
			return null;
		}

	}

	public Dictionary<int , Items> getShopItems(){

		return items;

	}

	public List<Items> getShopItemsList(){

		List<Items> shopItemList = new List<Items> ();

		// Loop over list.
		foreach (KeyValuePair<int , Items> pair in items)
		{
			shopItemList.Add (pair.Value);

		}

		return shopItemList;
	}



}
