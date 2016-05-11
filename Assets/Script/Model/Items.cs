using UnityEngine;
using System.Collections;

public enum ItemType{
	WEAPON,
	SPELL,
	FOOD,
	ARMOR
}


public class Items  {

	private int id;

	public int ID{

		set{
			id = value;
		}get{
			return id;
		}
	}

	private string description;

	public string Description{
		set{
			description = value;
		}get{
			return description;
		}

	}

	private  string name;

	public string Name{

		set{
			name = value;
		}get{
			return name;
		}
	}

	private int price;

	public int Price{
		set{
			price = value;
		}get{
			return price;
		}

	}

	private string image;

	public string Image{
		set{
			image = value;
		}get{
			return image;
		}

	}

	private int attackPWR;

	public int AttackPWR{
		set{
			attackPWR = value;
		}get{
			return attackPWR;
		}

	}

	private bool owned;

	public bool Owned{

		set{
			owned = value;
		}get{
			return owned;
		}
	}

	private ItemType itemType;

	public ItemType ITMType{
		set{
			itemType = value;
		}get{
			return itemType;
		}
	}





}
