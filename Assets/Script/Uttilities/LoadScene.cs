using UnityEngine;
using System.Collections;



public class LoadScene : MonoBehaviour {


	public void LoadTheScene (string Scene){
		
		UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
	
	}

	public void LoadTheScene(string Scene , int Delay){

		DelayComponent dc = new DelayComponent ();
		dc.CreateDelay (Delay);
		UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);



	}

}
