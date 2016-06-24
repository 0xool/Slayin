using UnityEngine;
using System.Collections.Generic;

public class Armor  {

	private List<string> weapon = new List<string>();

	public List<string> Weapon{

		get{
			return weapon;
		}set{
			weapon = value;
		}
	}

	public void addWeapon(string weapon){

		if(!this.weapon.Contains(weapon))
			this.weapon.Add (weapon);

	}

	public bool removeWeapon(string weapon){

		if (this.weapon.Contains (weapon)) {
			if (this.weapon.Remove (weapon))
				return true;
		} 

		return false;

	}

	private List<string> spell = new List<string>();

	public List<string> Spell{

		set{
			spell = value;
		}get{
			return spell;
		}

	}

	public void addSpell(string spell){

		if(!this.spell.Contains(spell))
			this.spell.Add (spell);

	}

	public bool removeSpell(string spell){
		if (this.spell.Contains (spell)) {
			if (this.spell.Remove (spell))
				return true;
			
		}

		return false;

	}
		

	private List<Food>  food = new List<Food>();

	public List<Food> _food{

		get{
			return food;
		}set{
			food = value;
		}

	}

	public void addToFood(Food food){

		if (this.food.Exists (x => x.FoodName == food.FoodName))
			this.food.Find (x => x.FoodName == food.FoodName).Amount++;
		else
			this.food.Add (food);
		
	}

	public void removeFood(Food food){

		if (this.food.Exists (x => x.FoodName == food.FoodName) ){
			if(this.food.Find (x => x.FoodName == food.FoodName).Amount > 0)
				this.food.Find (x => x.FoodName == food.FoodName).Amount--;
			else
				this.food.Remove (food);
		}

	}
		

	private List<Potion> potion = new List<Potion>();

	public List<Potion> _potion{

		get{
			return potion;
		}set{
			potion = value;
		}

	}

	public void AddPotion(Potion potion){

		if (this.potion.Exists (x => x.PotionName == potion.PotionName)){

			this.potion.Find (x => x.PotionName == potion.PotionName).Amount++;

		} else {

			this.potion.Add(potion);

		}
			

	}

	public void removePotion(Potion potion){

		if (this.potion.Exists (x => x.PotionName == potion.PotionName) ){
			if(this.potion.Find (x => x.PotionName == potion.PotionName).Amount > 0)
				this.potion.Find (x => x.PotionName == potion.PotionName).Amount--;
			else
				this.potion.Remove (potion);
		}

	}







}
