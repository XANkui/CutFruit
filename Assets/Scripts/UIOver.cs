
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOver : MonoBehaviour {

	public void PlayAgain(){
	
		SceneManager.LoadScene ("Main");
	}

	public void BackMenu(){

		SceneManager.LoadScene ("Menu");
	}
}
