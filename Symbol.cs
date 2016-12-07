using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Symbol : MonoBehaviour {

	Animator anim;

	[SerializeField]
	GameObject player;

	[SerializeField]
	AudioSource exploding;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("Bullet")) 
		{
			exploding.Play ();
			Destroy(col.gameObject);
			//Destroy(gameObject);
			anim.speed = 1;
			player.GetComponent<MainTank> ().SetGameOver (true);
		}
	}




		
}
