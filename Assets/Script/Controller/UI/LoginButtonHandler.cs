using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public enum LoginButtonState{

	LOGIN,
	REGISTER

}

public class LoginButtonHandler : MonoBehaviour {

	public string username;

	public string password;

	public string repeatPassword;



	public LoginButtonState _loginButtonState;

	void Start(){
		_loginButtonState = LoginButtonState.LOGIN;
	}

	public void LoginDone(string msg){


	}

	public void LoginFailed(string msg){


	}

	public void RegisterFailed(string msg){


	}

	public void RegisterDone(string msg){



	}

	public void loginStateAction(){

		username = GameObject.Find ("UsernameInputField").GetComponent<InputField> ().text;
		password = GameObject.Find ("PasswordInputField").GetComponent<InputField> ().text;

		if(username != null && username != ""  && password != null  && password != ""){

		//	UserManager.Instance.loginRequest(username , password , LoginDone , LoginFailed);
		
		}else{

			if (username == "" || username == null) {
				Debug.Log ("Plz Enter Username.");
			} else if (password == "" || password == null) {
				Debug.Log ("Plz Enter Password.");
			}
		}

	}

	public void registerStateAction(){

		username = GameObject.Find ("UsernameInputField").GetComponent<InputField> ().text;
		password = GameObject.Find ("PasswordInputField").GetComponent<InputField> ().text;
		repeatPassword = GameObject.Find ("RepeatPasswordField").GetComponent<InputField> ().text;

		if (repeatPassword == password && repeatPassword != null && repeatPassword != "") {
			if (username != null && username != "" && password != null && password != "" ) {

			//	UserManager.Instance.signUpRequest (username, password, RegisterDone, RegisterFailed);

			} else {

				if (username == "" || username == null) {
					Debug.Log ("Plz Enter Username.");
				} else if (password == "" || password == null) {
					Debug.Log ("Plz Enter Password.");
				}else if(repeatPassword == "" || repeatPassword == null){
					Debug.Log ("Plz Repeat Password.");
				}


			}
		} else {
			if (repeatPassword == "" || repeatPassword == null) {
				Debug.Log ("Plz Repeat Password.");
			} else {
				Debug.Log ("Password entered is not the same as repeat password");
			}

		}

	}

	public void loginClicked(){

		if(_loginButtonState == LoginButtonState.LOGIN)
			loginStateAction ();


		if (_loginButtonState == LoginButtonState.REGISTER)
			registerStateAction ();

	}

	public void changeState(){

		if (_loginButtonState == LoginButtonState.LOGIN) {
			_loginButtonState = LoginButtonState.REGISTER;
		} else {
			_loginButtonState = LoginButtonState.LOGIN;
		}

	}


}
