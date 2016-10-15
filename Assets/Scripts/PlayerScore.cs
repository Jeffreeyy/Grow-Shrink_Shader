using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour 
{
	private int _playerScore = 0;
    public int playerScore
    {
        get { return _playerScore; }
    }
	[SerializeField]private Text _scoreText;

	void Start()
	{
		_scoreText.GetComponent<Text> ();
	}


	public void AddScore(int amount)
	{
		_playerScore += amount;
		UpdateScore ();

	}

	private void UpdateScore()
	{
		_scoreText.text = "Score: " + _playerScore;
	}
}
