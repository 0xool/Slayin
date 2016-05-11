using UnityEngine;
using System.Collections;
using System.Threading;

public class DelayComponent : MonoBehaviour {



		void Start() {
			
		}

	public void CreateDelay(float seconds){

		StartCoroutine(createNewDelay(seconds));

	}

	IEnumerator createNewDelay(float seconds) {
			
		yield return new WaitForSeconds(seconds);
			
		}


}
