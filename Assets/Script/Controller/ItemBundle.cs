using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ItemBundle : MonoBehaviour {


	[Serializable]
	public struct itemBundle {
		
		public string name;
		public string discription;
		public int id;
		public int price;
		public string imageName;
		public int attackPWR;
		public ItemType itemType;



	}

	public itemBundle[] _itemBundle;




	public Items getItemByName(string name){



		foreach (itemBundle IB in _itemBundle) {

			if (IB.name == name) {

				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;
				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

				return tempItem;
			}

		}

		return null;

	}

	public List<Items> getAllItems(){


		List<Items> tempItemList = new List<Items> ();

		foreach (itemBundle IB in _itemBundle) {

				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;
				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

			tempItemList.Add (tempItem);


		}

		return tempItemList;


	}

	public List<Items> getAllWeaponItems(){


		List<Items> tempItemList = new List<Items> ();


		foreach (itemBundle IB in _itemBundle) {



			if (IB.itemType == ItemType.WEAPON) {
				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;
				Debug.Log (IB.name);
				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

				tempItemList.Add (tempItem);
			}


		}

		return tempItemList;

	}

	public List<Items> getAllFoodItems(){


		List<Items> tempItemList = new List<Items> ();



		foreach (itemBundle IB in _itemBundle) {



			if (IB.itemType == ItemType.FOOD) {
				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;

				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

				tempItemList.Add (tempItem);
			}


		}



		return tempItemList;

	}

	public List<Items> getAllArmorItems(){


		List<Items> tempItemList = new List<Items> ();

		foreach (itemBundle IB in _itemBundle) {

			if (IB.itemType == ItemType.ARMOR) {
				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;
				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

				tempItemList.Add (tempItem);
			}

		}

		return tempItemList;

	}

	public List<Items> getAllSpellItems(){


		List<Items> tempItemList = new List<Items> ();

		foreach (itemBundle IB in _itemBundle) {


			if (IB.itemType == ItemType.SPELL) {
				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;
				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

				tempItemList.Add (tempItem);
			}


		}

		return tempItemList;

	}

	public Items getItemById(int id){

		foreach (itemBundle IB in _itemBundle) {

			if (IB.id == id) {

				Items tempItem = new Items();
				tempItem.AttackPWR = IB.attackPWR;
				tempItem.Name = IB.name;
				tempItem.ID = IB.id;
				tempItem.Price = IB.price;
				tempItem.Image = IB.imageName;
				tempItem.ITMType = IB.itemType;
				tempItem.Description = IB.discription;

				return tempItem;
			}

		}

		return null;


	}




}
