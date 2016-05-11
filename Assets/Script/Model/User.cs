using UnityEngine;
using System.Collections;

public class User{

	private int level;

	public int Level{

		get{
			return level;
		}set{
			level = value;
		}
	}

	private string name;

	public string Name{
		set{
			name = value;
		}get{
			return name;
		}
	}

	private int id;

	public int ID {
		set{
			id = value;
		}get{
			return id;
		}
	}

	private int score;

	public int Score{
		set{
			score = value;
		}get{
			return score;
		}
	}

	private int highScore;

	public int HighScore{

		set{
			highScore = value;
		}get{
			return highScore;
		}

	}

}
