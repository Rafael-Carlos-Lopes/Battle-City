using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	bool canChange;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			if (canChange == false) {
				transform.position = new Vector2 (transform.position.x, 0);
				canChange = true;
			} else
				SceneManager.LoadScene ("Fase1");
		}

		if (transform.position.y <= 0) {
			transform.Translate (0, 2 * Time.deltaTime, 0);
		} else
			canChange = true;
	}

}
