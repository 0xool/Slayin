using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

///<summary>
///This is the class which use cal the API's for the user based  API's(such as login and register and ...) 
/// We pass thw json from the network manager to the class calling the UserManager class (with delegates :D)
/// This clas is Singleton which only one object of this class exists\
/// !!!!WARNING!!!!!
/// !!!!DO NOT NEW THIS CLASS!!!!!
/// !!!!THIS IS A SINGLTON CLASS!!!!
///</summray>

public class UserManager   {




	//a singleton object of this class  
	private static UserManager _usermanager;
	//delegate for the function that is the success message
	public delegate void DoneFunctionHandler(String  jsonData);
	//delegate for the function that is the fail message 
	public delegate void FailFunctionHandler(String  message);
	//the event handler for the failfunctionhandler
	public static event FailFunctionHandler FailFunction;
	//the event handler for the donefunction
	public static event DoneFunctionHandler DoneFunction;
	//here we get the user info
	private const String UserFileName = "/Userinfo.txt";

	private const string FileName = "/logedin.txt";




	//===================================================================================================================================================================	
	//the singleton object initialation
	public static UserManager Instance
	{
		get
		{
			if(_usermanager == null)
			{		
				_usermanager = new UserManager();
			}

			return _usermanager;
		}
	}
	//===================================================================================================================================================================	
	//the request for login just call networkmanager and gives it username password and connection success and aconection failed
	public  void loginRequest (string username , string password , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failedfunctionhandler )
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failedfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<string, string> arguments = new Dictionary<string,string>();

		arguments.Add("username", username);
		arguments.Add("password" , password);



		String client = Application.platform.ToString();

		arguments.Add ("client", client);

		String UDID = SystemInfo.deviceUniqueIdentifier.ToString();

		arguments.Add ("UDID", UDID);

		String type = SystemInfo.deviceType.ToString();

		arguments.Add ("device_type", type);
		arguments.Add("app_version" , "1.0.0");
		arguments.Add("assets_version" , "1.0.0");



		//we here call the network to Post
		NeworkManager.Instance.newRequest(arguments , ServerActions.LOGIN , callSuccessBack , callFailedBack );
	}
	//===================================================================================================================================================================	
	//the request for signup just call networkmanager and gives it username password and connection success and aconection failed
	public  void finishedGameRequest (int match_id , int looser_id , int winner_id , int winner_goals , int loser_goals , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failedfunctionhandler )
	{
		Dictionary<string, string> arguments = new Dictionary<string,string> ();

		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failedfunctionhandler;
		DoneFunction += _donefunctionhandler;

		arguments.Add ("game_id", match_id.ToString());
		arguments.Add ("looser_id", looser_id.ToString());
		arguments.Add ("winner_id", winner_id.ToString());
		arguments.Add ("winner_goals", winner_goals.ToString());
		arguments.Add ("looser_goals", loser_goals.ToString());

		NeworkManager.Instance.newRequest (arguments, ServerActions.FINISHEDMATCH, callSuccessBack, callFailedBack);
		//we here call the network to Post

	}
	//===================================================================================================================================================================	
	//the request for signup just call networkmanager and gives it username password and connection success and aconection failed
	public  void signUpRequest (string username , string password , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failedfunctionhandler )
	{
		Dictionary<string, string> arguments = new Dictionary<string,string>();

		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failedfunctionhandler;
		DoneFunction += _donefunctionhandler;

		arguments.Add("username", username);
		arguments.Add("password" , password);

		String client = Application.platform.ToString();

		arguments.Add ("client", client);

		String UDID = SystemInfo.deviceUniqueIdentifier.ToString();

		arguments.Add ("UDID", UDID);

		String type = SystemInfo.deviceType.ToString();

		arguments.Add ("device_type", type);
		arguments.Add("app_version" , "1.0.0");
		arguments.Add("assets_version" , "1.0.0");

		//we here call the network to Post
		NeworkManager.Instance.newRequest(arguments , ServerActions.REGISTER ,callSuccessBack , callFailedBack );
	}
	//===================================================================================================================================================================	
	//here we implement the player load api just simply send username and the rest to the network manager need to see the fail callback and success callback
//	public void PlayerLoad(String userame ,DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler )
//	{
//		Dictionary<String , String> arguments = new Dictionary<String,String > ();
//
//		DoneFunction = null;
//		FailFunction = null;
//		FailFunction += _failfunctionhandler;
//		DoneFunction += _donefunctionhandler;
//
//		arguments.Add ("username", userame);
//		arguments.Add ("coin", Soomla.Store.StoreInfo.GetItemByItemId ("0001").GetBalance ().ToString());
//		arguments.Add ("cash", Soomla.Store.StoreInfo.GetItemByItemId ("0002").GetBalance ().ToString());
//
//		String client = Application.platform.ToString ();
//
//		arguments.Add ("client", client);
//
//		String UDID = SystemInfo.deviceUniqueIdentifier.ToString ();
//
//		arguments.Add ("UDID", UDID);
//
//		String type = SystemInfo.deviceType.ToString ();
//		//				|
//		//				|
//		//				|
//		//			  \   /
//		//			   \ /
//		//MUST CHECK LATER
//		//need to add it later 
//		arguments.Add ("game_count", "0");
//		arguments.Add ("coin_changes", "0");
//		arguments.Add ("cash_changes", "0");
//
//
//		arguments.Add ("device_type", type);
//		arguments.Add("app_version" , "1.0.0");
//		arguments.Add("assets_version" , "1.0.0");
//
//
//		//we here call the network to Post
//		NeworkManager.Instance.newRequest (arguments, ServerActions.LOAD, callSuccessBack, callFailedBack);
//
//	}
	//===================================================================================================================================================================	
	///<summary>
	///The findmatch api requires the match_id and the texture_id and formation_id and room_id
	///</summray>

//	public void FindMatch(int matchitem_id , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler )
//	{
//		DoneFunction = null;
//		FailFunction = null;
//
//		FailFunction += _failfunctionhandler;
//		DoneFunction += _donefunctionhandler;
//		Dictionary<String , String> arguments = new Dictionary<String,String > ();
//
//		arguments.Add ("texture_id", User.Currentuser.GetTeam().getUniform().ID.ToString());
//		arguments.Add ("formation_id", User.Currentuser.GetTeam ().GetFormation ().GetId ().ToString());
//		arguments.Add ("room_id", matchitem_id.ToString ());
//
//		NeworkManager.Instance.newRequest(arguments ,  ServerActions.FINDMATCH , callSuccessBack , callFailedBack);
//	}
	//===================================================================================================================================================================	
	public void resetPassword(String newpassword , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String> arguments = new Dictionary<String,String > ();

		if (FileManager.Instance.fileExists (Application.persistentDataPath + UserFileName)) {
			String json = FileManager.Instance.readFile (Application.persistentDataPath + UserFileName);
			arguments.Add ("current_password", JSON.Parse (json) ["data"] ["player"] ["name"]);
		}

		arguments.Add("new_password" , newpassword);

		NeworkManager.Instance.newRequest(arguments ,  ServerActions.RESETPASSWORD , callSuccessBack , callFailedBack);

	}
	//===================================================================================================================================================================	
	///<summary>
	///This API is the forgot password and only needs the Email as the input 
	///</summray>

	public void forgotPassword(String email , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String> arguments = new Dictionary<String,String > ();

		arguments.Add ("email", email);

		NeworkManager.Instance.newRequest (arguments ,ServerActions.FORGOTPASSWORD ,callSuccessBack, callFailedBack);

	}
	//===================================================================================================================================================================	
	///<summary>
	///This is the SingOut API for signing out to tell the server this user has signed out
	///</summray>

	public void singOut(string userid , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String> arguments = new Dictionary<String,String > ();

		//here we must put the arguments foe the sign out api :D
		if (FileManager.Instance.fileExists (Application.persistentDataPath + FileName)) {
			String json = FileManager.Instance.readFile (Application.persistentDataPath + FileName );
			Debug.LogError	(json);
			arguments.Add ("username", json);
		}
		//arguments.Add ("username", userid);
		NeworkManager.Instance.newRequest (arguments , ServerActions.SINGOUT ,callSuccessBack, callFailedBack);

	}
	//===================================================================================================================================================================	
	///<summary>
	///STILL WORK IN PROGRESS
	/// UPDATE AFTER FINISH
	///</summray>

	public void matchFinished(string winner , int matchid , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String>  arguments  = new Dictionary<string , string>();




		NeworkManager.Instance.newRequest (arguments ,ServerActions.FORGOTPASSWORD ,callSuccessBack, callFailedBack);
	}
	//===================================================================================================================================================================	
	///<summary>
	///After the success of the API the json is sent through the socket
	///The json only contains the the timestamp of the finding
	///</summray>

	public void attendMatch(int matchid , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String>  arguments  = new Dictionary<string , string>();



		NeworkManager.Instance.newRequest (arguments ,ServerActions.FORGOTPASSWORD ,callSuccessBack, callFailedBack);
	}
	//===================================================================================================================================================================	
	///<summary>
	///The json ranking API contains the top player of the ranking and the near of the player 
	///</summray>

	public void RanckingAPI( DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String>  arguments  = new Dictionary<string , string>();

		if (FileManager.Instance.fileExists (Application.persistentDataPath + UserFileName)) {
			String json = FileManager.Instance.readFile (Application.persistentDataPath + UserFileName);
			arguments.Add ("username", JSON.Parse (json) ["data"] ["player"] ["name"]);
			Debug.Log(JSON.Parse (json) ["data"] ["player"] ["name"]);
			NeworkManager.Instance.newRequest (arguments ,ServerActions.RANCKING ,callSuccessBack, callFailedBack);
		}



	}
	//===================================================================================================================================================================	
	///<summary>
	///WORK IN PROGGRESS WAITING FOR THE GAME DESIGN OF THIS PART
	///</summray>

	public void TeamRanckingAPI( DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String>  arguments  = new Dictionary<string , string>();
		//				|
		//				|
		//				|
		//			  \   /
		//			   \ /
		//MUST CHECK LATER
		//		arguments.Add ("number", numberOfTopAndDown.ToString());
		if (FileManager.Instance.fileExists (Application.persistentDataPath + UserFileName)) {
			String json = FileManager.Instance.readFile (Application.persistentDataPath + UserFileName);
			arguments.Add ("username", JSON.Parse (json) ["data"] ["player"] ["name"]);
			Debug.Log(JSON.Parse (json) ["data"] ["player"] ["name"]);
		}


		NeworkManager.Instance.newRequest (arguments ,ServerActions.TEAMRANKING ,callSuccessBack, callFailedBack);
	}
	//===================================================================================================================================================================	
	///<summary>
	///this function is for the IAP recipt sending to the server for validation
	///</summray>

	public void inGamePurchaseAPI(string type , int id , DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String>  arguments  = new Dictionary<string , string>();

		if (FileManager.Instance.fileExists (Application.persistentDataPath + UserFileName)) {
			String json = FileManager.Instance.readFile (Application.persistentDataPath + UserFileName);
			arguments.Add ("username", JSON.Parse (json) ["data"] ["player"] ["name"]);
			Debug.Log(JSON.Parse (json) ["data"] ["player"] ["name"]);
		}

		Debug.Log (type);

		arguments.Add ("item_type", type);
		arguments.Add ("item_id", id.ToString());

		NeworkManager.Instance.newRequest (arguments ,ServerActions.INGAMEPURCHASE ,callSuccessBack, callFailedBack);
	}
	//===================================================================================================================================================================	
	public void cancelFindMatch(DoneFunctionHandler _donefunctionhandler , FailFunctionHandler _failfunctionhandler)
	{
		DoneFunction = null;
		FailFunction = null;
		FailFunction += _failfunctionhandler;
		DoneFunction += _donefunctionhandler;

		Dictionary<String , String>  arguments  = new Dictionary<string , string>();

		if (FileManager.Instance.fileExists (Application.persistentDataPath + UserFileName)) {
			String json = FileManager.Instance.readFile (Application.persistentDataPath + UserFileName);
			arguments.Add ("username", JSON.Parse (json) ["data"] ["player"] ["name"]);
			Debug.Log(JSON.Parse (json) ["data"] ["player"] ["name"]);
		}


		NeworkManager.Instance.newRequest (arguments ,ServerActions.CANCELFINDMATCH ,callSuccessBack, callFailedBack);
	}


	//===================================================================================================================================================================	
	//callsuccessback here we call the callbacksuccess function set from the input
	public void callSuccessBack(String msg)
	{

		if (DoneFunction != null) 
			DoneFunction (msg);




	}
	//===================================================================================================================================================================	
	public void callFailedBack(string message)
	{
		if (FailFunction != null)
			FailFunction (message);


	}
	//===================================================================================================================================================================	


}
