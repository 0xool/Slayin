using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace MainMenu{
	/// <summary>
	/// Score label cotroller.setScore to set the score of the ui score label 
	/// </summary>
	public class ScoreLabelCotroller : MonoBehaviour {

		private int currentScore;
		public Text scorePoints;

	//====================================================================================================================================================================
		public void setScore(int score)
		{
			currentScore = score;
			scorePoints.text = currentScore.ToString ();
		}
	//====================================================================================================================================================================
		void Start(){
			//temporary
			setScore(64080);

		}
	//====================================================================================================================================================================

	}

}
