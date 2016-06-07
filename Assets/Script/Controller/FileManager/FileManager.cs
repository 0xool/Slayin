using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


public class FileManager  {

	private StreamWriter sw;
	private StreamReader sr;
	public static FileManager _filemanager;

	//===================================================================================================================================================================	
	public FileManager()
	{




	}
	//===================================================================================================================================================================	
	public static FileManager Instance
	{
		get
		{
			if(_filemanager == null)
			{		
				_filemanager = new FileManager();
			}

			return _filemanager;
		}
	}
	//===================================================================================================================================================================	
	//here we read from the file 
	public String readFile(string address)
	{
		sr = new StreamReader (address);
		String temp = sr.ReadLine ();
		sr.Close ();
		return temp.ToString();

	}
	//===================================================================================================================================================================	
	//here we write to a file
	public  void writeFile(String address ,  String write)
	{

		sw = new StreamWriter(address);
		sw.WriteLine(write);
		sw.Close();

	}
	//===================================================================================================================================================================	
	//here we create file if it doesnt exits
	public  void createFile(String address)
	{

		if (!File.Exists (address)) {
			File.Create (address).Close ();
		}
	}
	//===================================================================================================================================================================	
	//here we delete the files in the application.persistant
	public void deleteFile(String address)
	{
		if (File.Exists (address)) {
			File.Delete (address);

		}
	}
	//===================================================================================================================================================================	
	//this functoin checks if the file exists or not
	public bool fileExists(String address)
	{
		if (File.Exists (address))
			return true;
		else
			return false;
	}
	//===================================================================================================================================================================	
	//here we create a texture from the file with the size of the texture we want
	public Texture2D getPNGTexture(string address , int sizeX , int sizeY)
	{
		Texture2D tex = new Texture2D(sizeX , sizeY , TextureFormat.RGBA32 , false);
		//if(fileExists(Application.persistentDataPath + address)){
		if (fileExists(address))
		{
			//data coontains the png from file in bytes
			byte[] data;
			//here we read it from the file
			//data = File.ReadAllBytes(Application.persistentDataPath + address);
			data = File.ReadAllBytes(address);
			//here we conver it to a texture to use it in the sprite
			tex.LoadImage(data);
			//the sprite which we create from the texture we create from the png
		}
		return tex;
	}
	//===================================================================================================================================================================	
	//here we get the png from file and create a sprite from it we give it the addres and the texture size which we want and thw sprite size which we want it to be
	public Sprite getPNGSprite(string address , int texturesizeX , int texturesizeY , int spritesizeX , int spritesizeY)
	{
		Sprite sprite = new Sprite ();
		Texture2D tex = new Texture2D(texturesizeY , texturesizeY , TextureFormat.RGBA32 , false);
		if (fileExists ( address)) {
			//data coontains the png from file in bytes
			tex.filterMode = FilterMode.Trilinear;
			byte[] data;
			//here we read it from the file
			data = File.ReadAllBytes ( address);
			//here we conver it to a texture to use it in the sprite
			tex.LoadImage (data);
			//the sprite which we create from the texture we create from the png
			sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2 (0.5f, 0.0f), 1.0f);
		}
		return sprite;
	}


}
