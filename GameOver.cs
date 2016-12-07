using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("BackToMenu", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void BackToMenu()
	{
		SceneManager.LoadScene ("Menu");
	}

}
