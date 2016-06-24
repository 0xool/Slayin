using UnityEngine;
using System.Collections;

public class PlayerManager  {

	private static PlayerManager _playerManager;

	public static PlayerManager playerManager{

		get{
			if (_playerManager == null)
				_playerManager = new PlayerManager ();

			return _playerManager;
		}

	}

	private Armor armor;

	public Armor _armor{

		set{
			armor = value;
		}get{
			return armor;
		}

	}

	private Player _player;

	public Player player{

		get{
			return _player;
		}set{
			_player = value;
		}
	}

	public string getUsername(){

		return _player.user.Name;

	}

	public int getHighScore(){

		return _player.user.HighScore;

	}

	public int getLevel(){

		return _player.user.Level;

	}

	public void setLevel(int level){

		_player.user.Level = level;

	}

	public void setHighScore(int highScore){

		_player.user.HighScore = highScore;

	}

	public void setScore(int score){

		_player.user.Score = score;

	}

	public void setUsername(string username){

		_player.user.Name = username;

	}

	public void setUserIamge(){



	}


}
