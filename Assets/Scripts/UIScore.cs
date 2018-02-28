using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour {

	/// <summary>
	/// 单例类
	/// </summary>
	public static UIScore Instance;

	/// <summary>
	/// 获得记分Text
	/// </summary>
	public Text scoreText;

	/// <summary>
	/// 显示的总分
	/// </summary>
	private int totalScore = 0;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake() {

		Instance = this;
	}

	/// <summary>
	/// Adds the score.
	/// </summary>
	/// <param name="score">Score.</param>
	public void AddScore(int score) {

		totalScore += score;
		scoreText.text = totalScore.ToString ();
	}

	/// <summary>
	/// Removes the score.
	/// </summary>
	/// <param name="score">Score.</param>
	public void RemoveScore(int score) {

		totalScore -= score;
		scoreText.text = totalScore.ToString ();

		if(totalScore < 0){

			SceneManager.LoadScene ("GameOver");
		}
	}
}
