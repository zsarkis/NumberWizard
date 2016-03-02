using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	int max, min;
	int guess;
	bool hasWon;
	int guessesAllowed;
	public Text text;
//	public Text text2;
	string guessesAl;

	void Start ()
	{
		StartGame();
	}

	void StartGame ()
	{
		guessesAllowed = 11;
		hasWon = false;
		max = 1001;//add one because int division rounds down
		min = 1;
		NextGuess();
	}

	public void GuessHigher ()
	{
		min = guess;
		NextGuess ();
	}

	public void GuessLower ()
	{
		max = guess;
		NextGuess ();
	}
	void NextGuess ()
	{
//		guess = ((min + max) / 2);	//int division is safe
		guess = Random.Range(min,max);
		guessesAllowed = guessesAllowed - 1;
		text.text = guess.ToString();
		if (guessesAllowed <= 0) {
			Application.LoadLevel("Win");
		}

	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {		//so user has both the arrow keys and the buttons.
			GuessHigher();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {	//so user has both the arrow keys and the buttons.
			GuessHigher();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {	//so user has both the arrow keys and the buttons.
			GuessLower();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {	//so user has both the arrow keys and the buttons.
			GuessLower();
		} else if (Input.GetKeyDown (KeyCode.Return)) {	//so user has return and button
			Application.LoadLevel("Lose");
		}
		guessesAl = "remaining guesses: " + guessesAllowed.ToString();

	}
}
