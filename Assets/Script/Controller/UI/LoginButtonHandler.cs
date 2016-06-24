using UnityEngine;
using SimpleJSON;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum LoginButtonState{

	LOGIN,
	REGISTER

}

public class LoginButtonHandler : MonoBehaviour {

	public string username;

	public string password;

	public string repeatPassword;

	public GameObject messagePanel;
	public Text errorTitle;
	public Text errorDesc;



	public LoginButtonState _loginButtonState;

	void Start(){
		_loginButtonState = LoginButtonState.LOGIN;
		messagePanel = GameObject.Find ("MessagePanel");
		errorDesc = GameObject.Find ("ErrorDescription").GetComponent<Text>();
		errorTitle = GameObject.Find ("ErrorTitle").GetComponent<Text>();

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
			Debug.Log (username + password);
			new GameSparks.Api.Requests.AuthenticationRequest().SetUserName(username).SetPassword(password).Send((response) => {
				if (!response.HasErrors) {
					Debug.Log("Player Authenticated...");
					errorTitle.text = "Error Authenticating";
					errorDesc.text = "Welcome" + username;
					SceneManager.LoadScene("MainMenu" , LoadSceneMode.Single);
				} else {
					Debug.Log("Error Authenticating Player...");
					errorTitle.text = "Error Authenticating";
					errorDesc.text =  response.Errors.GetString("DETAILS");
					messagePanel.GetComponent<Movement> ().Move ();
				}
			});
		
		}else{

			if (username == "" || username == null) {
				errorTitle.text = "Username Field empty";
				errorDesc.text = "Plz Enter Username.";
				messagePanel.GetComponent<Movement> ().Move ();
			} else if (password == "" || password == null) {
				errorTitle.text = "Password Field empty";
				errorDesc.text = "Plz Enter Password.";
				messagePanel.GetComponent<Movement> ().Move ();
			}
		}

	}

	public void registerStateAction(){

		username = GameObject.Find ("UsernameInputField").GetComponent<InputField> ().text;
		password = GameObject.Find ("PasswordInputField").GetComponent<InputField> ().text;
		repeatPassword = GameObject.Find ("RepeatPasswordField").GetComponent<InputField> ().text;


			if (username != null && username != "" && password != null && password != "" ) {
			if (repeatPassword == password && repeatPassword != null && repeatPassword != "") {

				new GameSparks.Api.Requests.RegistrationRequest().SetDisplayName(username).SetPassword(password).SetUserName(username).Send((response) => {
					if (!response.HasErrors)
					{
						errorTitle.text = "User Registered";
						errorDesc.text = "Welcome ";
						messagePanel.GetComponent<Movement> ().Move ();

					}
					else
					{
						Debug.Log("Error Registering Player");
						errorTitle.text = "user not registered";
						errorDesc.text = response.Errors.GetString("USERNAME");
						messagePanel.GetComponent<Movement> ().Move ();
					}
				});

			}else {

					if (repeatPassword == "" || repeatPassword == null) {


						errorTitle.text = "password Repeat";
						errorDesc.text = "Plz Repeat Password. ";
						messagePanel.GetComponent<Movement> ().Move ();
						Debug.Log ("Plz Repeat Password.");
					} else {

						errorTitle.text = "password Repeat";
						errorDesc.text = "Password entered is not the same as repeat password";
						messagePanel.GetComponent<Movement> ().Move ();

						Debug.Log ("Password entered is not the same as repeat password");
					}

				}
			//	UserManager.Instance.signUpRequest (username, password, RegisterDone, RegisterFailed);

			} else {

				if (username == "" || username == null) {
					errorTitle.text = "Username Field empty";
					errorDesc.text = "Plz Enter Username.";
					messagePanel.GetComponent<Movement> ().Move ();
					Debug.Log ("Plz Enter Username.");
				} else if (password == "" || password == null) {
					errorTitle.text = "Password Field empty";
					errorDesc.text = "Plz Enter Password.";
					messagePanel.GetComponent<Movement> ().Move ();
					Debug.Log ("Plz Enter Password.");
				}else if(repeatPassword == "" || repeatPassword == null){
					errorTitle.text = "Reapet Password Field empty";
					errorDesc.text = "Plz Enter Repeat Password. ";
					messagePanel.GetComponent<Movement> ().Move ();
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
