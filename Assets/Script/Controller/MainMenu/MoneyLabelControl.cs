using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MainMenu{

	public class MoneyLabelControl : MonoBehaviour {

		private int money;

		public int Money {
			set{
				money = value;
			}get{
				return money;
			}
		}

		public Text moneyScore;
		// Use this for initialization
		void Start () {
		
			setMoneyScore (5297);

		}

		public void setMoneyScore(int money){

			this.money = money;
			moneyScore.text = this.money.ToString();

		}
		
		// Update is called once per frame
		void Update () {
		


		}
	}

}
