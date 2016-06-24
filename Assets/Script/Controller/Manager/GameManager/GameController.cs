using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	/// <summary>The GameSparks Manager singleton</summary>
	private static GameController instance = null;
	void Awake() {
		if (instance == null) // check to see if the instance has a reference
		{
			instance = this; // if not, give it a reference to this class...
			DontDestroyOnLoad(this.gameObject); // and make this object persistent as we load new scenes
		} else // if we already have a reference then remove the extra manager from the scene
		{
			Destroy(this.gameObject);
		}
	}


	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
