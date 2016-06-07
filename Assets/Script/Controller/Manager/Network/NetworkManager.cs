using SimpleJSON;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Net;
using System.Globalization;



public enum ServerActions {
	LOGIN ,
	REGISTER  ,
	LOAD  , 
	FINDMATCH,
	RESETPASSWORD,
	FORGOTPASSWORD,
	SINGOUT,
	RANCKING,
	BUYING,
	ASSETUPDATECHEK,
	ASSETUPDATE,
	INGAMEPURCHASE,
	GETITEMS,
	MYKETAUTHORIZE,
	MYKETTOKEN,
	PAYMENTPACKAGES,
	TEAMRANKING,
	FINISHEDMATCH,
	CANCELFINDMATCH
}

//here we set the cariables delegate are the onse sent to the model
//===================================================================================================================================================================
public  class  NeworkManager :  MonoBehaviour   {
	//singlton object of this class must use this one only!!!!
	private  static NeworkManager instance;  
	//delegate for the function that is the success message 
	public delegate void DoneFunctionHandler(String  jsonData);
	//delegate for the function that is the fail message 
	public delegate void FailFunctionHandler(String  message);

	public delegate void DoneFunctionHandlerDownload(byte[] download);

	public static event DoneFunctionHandlerDownload DownloadDone;

	public delegate void RetryConnection();

	public static event RetryConnection Retry;
	//the event handler for the failfunctionhandler
	public static event FailFunctionHandler FailFunction;
	//the event handler for the donefunction
	public static event DoneFunctionHandler DoneFunction;
	//the cookkie which the data is set on it for later use
	private const String FileName = "/cookie.txt";

	private String address;

	//the login url of the server
	private const String loginAction = "player/login";
	//the signup url for the server 
	private const String registerAction = "player/register";
	//here is for the load url
	private const String loadAction = "player/load";
	//here is for the forgot password url()
	private const String forgotpasswordAction = "/";
	//this is the reset password url
	private const String resetpaswordAction = "player/change_password";
	//here we must set the find match url
	private const String findAction = "game/attend";

	private const string assetUpdatechekAction = "assets/update";

	private const string assetUpdateAction = "player/getBuckets";

	private const string buyingAction = "/";

	private const string ranckingaction = "player/rank"; 
	//this is the url for the singout api
	private const String singoutAction = "player/logout";
	//the host itself which we connect to
	private const String Host = "api.soccerstar.foodproject.ir";
	//for writing
	private StreamWriter write;
	//for reading
	private StreamReader reader;
	//if cookie is saved or not
	private Boolean cook;

	private String url;
	//number of reconnecting attemps
	private const int tryattemps = 2; 
	//these are all for reconecting purposes
	private Dictionary<String , String > reconnectingheaders;
	private ServerActions reconnectingaction;
	private static int tryed = 0;

	private Thread RequestThread;

	//===================================================================================================================================================================
	//simple constructor
	public NeworkManager()
	{



		//		Request = new Thread (Request);
		//		Thread Recconect = new Thread (Request);
		//		Thread Download = new Thread (downloadImage);
		cook = false;
	}
	//===================================================================================================================================================================	
	//here we give the headers to be sent(ar) and the url to sent to (url) , and the success function callback and the fail function call back
	public void  newRequest(Dictionary<String , String> ar , ServerActions action ,DoneFunctionHandler _DoneFunction , FailFunctionHandler _FailFunction )
	{

		Retry = null;		
		DoneFunction = null;
		FailFunction = null;
		DoneFunction += _DoneFunction;
		FailFunction += _FailFunction;

		tryed = 0;
		Retry += retryRequest;

		reconnectingheaders = ar;
		reconnectingaction = action;

		address = Application.persistentDataPath + FileName;

		if(FileManager.Instance.fileExists(address))
			FileManager.Instance.createFile (address);

		switch (action) {

		case ServerActions.LOAD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + loadAction;

				break;
			}
		case ServerActions.LOGIN :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + loginAction;

				break;
			}
		case ServerActions.REGISTER : 
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + registerAction;

				break;
			}
		case  ServerActions.FINDMATCH :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + ConstModel.findAction;
			}	
			break;

		case  ServerActions.RESETPASSWORD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + resetpaswordAction;
			}	
			break;

		case  ServerActions.FORGOTPASSWORD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + forgotpasswordAction;
			}	
			break;
		case  ServerActions.SINGOUT :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + singoutAction;
			}	
			break;
		case  ServerActions.RANCKING :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + ranckingaction;
			}	
			break;
		case ServerActions.BUYING :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + buyingAction;
			break;

		case ServerActions.ASSETUPDATECHEK :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + assetUpdatechekAction;
			break;

		case ServerActions.ASSETUPDATE :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + assetUpdateAction;
			break;


		default :
			break;

		}
		Debug.Log (url);	
		StartCoroutine(Request (ar, url ));

	}
	//===================================================================================================================================================================	
	public void  newDownload( string DownloadUrl   ,DoneFunctionHandlerDownload _DoneFunction , FailFunctionHandler _FailFunction )
	{
		DoneFunction = null;
		DownloadDone = null;
		FailFunction = null;

		DownloadDone += _DoneFunction;
		FailFunction += _FailFunction;

		Debug.Log (DownloadUrl);
		StartCoroutine(downloadImage (DownloadUrl));
	}
	//===================================================================================================================================================================	
	public void retryRequest()
	{
		//		StopAllCoroutines ();
		address = Application.persistentDataPath + FileName;
		Debug.Log (address);
		Debug.Log (this.gameObject.GetInstanceID());
		if(FileManager.Instance.fileExists(address))
			FileManager.Instance.createFile (address);

		switch (reconnectingaction) {

		case ServerActions.LOAD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + loadAction;

				break;
			}
		case ServerActions.LOGIN :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + loginAction;

				break;
			}
		case ServerActions.REGISTER : 
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + registerAction;

				break;
			}
		case  ServerActions.FINDMATCH :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + findAction;
			}	
			break;

		case  ServerActions.RESETPASSWORD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + resetpaswordAction;
			}	
			break;

		case  ServerActions.FORGOTPASSWORD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + forgotpasswordAction;
			}	
			break;
		case  ServerActions.SINGOUT :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + singoutAction;
			}	
			break;

		case  ServerActions.RANCKING :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + ranckingaction;
			}	
			break;
		case ServerActions.BUYING :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + buyingAction;
			break;

		case ServerActions.ASSETUPDATECHEK :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + assetUpdatechekAction;
			break;

		case ServerActions.ASSETUPDATE :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + assetUpdateAction;
			break;



		default :
			Debug.Log("");
			break;

		}
		Debug.Log (url);
		StartCoroutine(Request (reconnectingheaders , url ));

	}


	//===================================================================================================================================================================	
	//the single ton object of this calss named instance	
	public static NeworkManager Instance { 		
		get 
		{ 			
			if (instance == null){
				instance = GameObject.FindObjectOfType (typeof(NeworkManager)) as  NeworkManager; 			
				DontDestroyOnLoad(instance.gameObject);
			}

			return instance; 		
		}  

	}
	//===================================================================================================================================================================	
	//here we call the function which we have pointed  to in newRequest
	public static void CallFailFunction(string message) {

		if (FailFunction != null)
		{
			if(tryed < tryattemps){
				Debug.Log("was here tryed:" + tryed);
				tryed++;
				Retry();
			}else{

				FailFunction(message);
			}
		}

	}
	//===================================================================================================================================================================
	//here we call the function which we have pointed  to in newRequest
	public static void CallDoneFunction(string data) {

		if (DoneFunction != null) 
		{
			DoneFunction(data);

		}
	}
	//===================================================================================================================================================================
	//here we call the function which we have pointed  to in newRequest
	public static void CallDoneDownload(byte[] data) {

		if (DownloadDone != null) 
		{
			DownloadDone(data);	

		}
	}
	//===================================================================================================================================================================
	//the coroutin that runs behind the scene  and sends a request to server and then recieves a message depending on the results and also saves cookie from session id and if it exists it sends cookie for fast access
	IEnumerator Request( Dictionary<String , String> arguments , String Url )
	{
		String cookie;
		Dictionary<string, string> headers;


		headers = getHeaders();

		WWWForm form = makeArguments (arguments);

		WWW www = new WWW(Url, form.data , headers);

		yield return www;

		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			String  JSON_string = www.text;
			String n = JSON.Parse(JSON_string)["status"].Value;

			if(www.responseHeaders.Count > 0 && n == "true") {

				foreach(KeyValuePair<string, string> entry in www.responseHeaders) {
					Debug.Log(entry.Value + "=" + entry.Key);
					if(entry.Key == "SET-COOKIE")
						cook = true;
				}
				CallDoneFunction(www.text);
				//Debug.Log(www.text);
			}
			if(cook){
				cookie = www.responseHeaders["SET-COOKIE"];	
				try
				{
					FileManager.Instance.writeFile(address , cookie);
				}
				catch(Exception e)
				{
					Console.WriteLine("exeptio" + e.Message);
				}
				//here we must send mesage that the login scene that it must be changed  to the next scene
			}
		} else {
			Debug.Log("ERROR : " + www.error);


			foreach(KeyValuePair<string, string> entry in www.responseHeaders) 
				Debug.Log(entry.Value + "=" + entry.Key);
			Debug.Log(www.text);
			if(www.text.Contains("message"))
				CallFailFunction(JSON.Parse(www.text)["message"].Value);
			else
				CallFailFunction(www.error);


		} 

	}
	//===================================================================================================================================================================
	IEnumerator downloadImage(String durl)
	{

		WWW www = new WWW(durl);

		//		yield return www;
		//Debug.Log ("@#$%^&*" + www.text);
		while (!www.isDone) {

			//this might be used later to show proggress
			//string progress = (www.progress * 100).ToString() + ""; 
			yield return null;
		}


		if (www.error == null)
		{
			CallDoneDownload(www.bytes);
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("or even here");
			foreach(KeyValuePair<string, string> entry in www.responseHeaders) 
				Debug.Log(entry.Value + "=" + entry.Key);
			if(www.text.Length > 2)
				Debug.Log("-----------" + www.text);
			//				CallFailFunction(JSON.Parse(www.text)["message"].Value);
			else
				CallFailFunction("network problems");
			Debug.Log(www.text);	
		} 
	}
	//here we set the action for the url 
	//===================================================================================================================================================================
	public void getUrlForAction(ServerActions action)
	{

		switch (action) {

		case ServerActions.LOAD :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + loadAction;

				break;
			}
		case ServerActions.LOGIN :
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + loginAction;

				break;
			}
		case ServerActions.REGISTER : 
			{
				url = ConstModel.protocol + Host + ConstModel.ServerVersion + registerAction;

				break;
			}
		case  ServerActions.FINDMATCH :
			url = ConstModel.protocol + Host + ConstModel.ServerVersion + registerAction;

			break;

		default :
			Debug.Log("");
			break;

		}
	}
	//here we make key values of the user name password device type and UDID and ....)(
	//===================================================================================================================================================================
	private WWWForm makeArguments(Dictionary<string, string> arguments)
	{
		WWWForm form = new WWWForm();

		foreach (KeyValuePair<string, string> entry in arguments)
		{
			form.AddField(entry.Key, entry.Value);
		}

		return form;
	}
	//here we get the headers for the wwwform if we have cookies form the last session we send them if not we send the main host
	//===================================================================================================================================================================
	private Dictionary<string, string> getHeaders()
	{
		//		Application.persistentDataPath;
		String temp = null;
		Dictionary<string, string> headers = new Dictionary<string, string>();
		if(FileManager.Instance.fileExists(address))
			temp = FileManager.Instance.readFile (address);


		if(temp != null){
			headers.Add("Cookie" , temp);
			cook = false;
		}
		else
			headers.Add("Host", Host);
		return headers;
	}
}

//===================================================================================================================================================================	




