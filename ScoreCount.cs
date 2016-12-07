using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreCount : MonoBehaviour {

	[SerializeField]
	TextMesh countTxt, totalTxt, scoreTxt, bonusTxt;

	GameObject player;

	int score, bonus, count;

	float contador;

	int enemiesDestroyed;

	bool trocar, win;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("MainTank");
		enemiesDestroyed = player.GetComponent<MainTank> ().GetEnemiesDestroyed ();
		score = player.GetComponent<MainTank> ().GetScore ();
		win = player.GetComponent<MainTank> ().GetWin ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		countTxt.text = count.ToString ();
		scoreTxt.text = score.ToString ();
		bonusTxt.text = bonus.ToString ();
		contador += Time.deltaTime;
		
		if (contador > 0.3f) 
		{
			if (count < enemiesDestroyed) 
			{
				count ++;
				bonus += 100;
				contador = 0;
			} 

			else 
			{
				totalTxt.text = enemiesDestroyed.ToString ();
				trocar = true;
			}

			if (trocar == true) 
			{
				if(win == false)
				{
				Invoke ("ChangeScene", 4f);
				}

				if(win == true)
				{
					Invoke("GoToMenu",4f);
				}
			}
		}
	}

	void ChangeScene()
	{
		player.GetComponent<MainTank> ().setChangeScene ();
	}

	void GoToMenu()
	{
		SceneManager.LoadScene("Menu");
	}
		
}
