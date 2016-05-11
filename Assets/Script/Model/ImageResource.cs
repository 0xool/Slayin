using UnityEngine;
using System.Collections.Generic;
using System;

public class ImageResource : MonoBehaviour {

	[Serializable]
	public struct pixelArt {
		public string name;
		public Sprite image;

	}
	public pixelArt[] pictures;




	public Sprite getImageByName(string spriteName){

		foreach(pixelArt px in pictures){

			if (px.name == spriteName) {

				return px.image;

			}

		}

		Application.Quit();
		return null;

	}

	public List<string> getImageNames(){

		List<string> names = new List<string> ();

		foreach (pixelArt px in pictures) {

			names.Add (px.name);

		}

		return names;

	}
}
