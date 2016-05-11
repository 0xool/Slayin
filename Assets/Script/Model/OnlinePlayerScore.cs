using UnityEngine;
using System.Collections;

public class OnlinePlayerScore {



	private  int id;

	public  int ID{
		set{
			id = value;
		}get{
			return id;
		}

	}

	private  string name;

	public string Name{

		set{
			name = value;
		}get{
			return name;
		}
	}

	private int rank;

	public int Rank{

		set{
			rank = value;
		}get{
			return rank;
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

}
