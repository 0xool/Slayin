using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace MainMenu{

	public class SettingsButtonHandler : MonoBehaviour {

		public Sprite Setting_Normal_Image;

		public Sprite Settings_Back_Image;

		private bool onPage;


		void Start(){

			onPage = false;

		}

		public void changeSettingsImage(){

			if (!onPage) {
				this.gameObject.GetComponent<Image> ().sprite = Settings_Back_Image;
			} else {
				this.gameObject.GetComponent<Image> ().sprite = Setting_Normal_Image;
			}

			onPage = !onPage;

		}






		public void findGameObjects()
		{





		}




	}

}
