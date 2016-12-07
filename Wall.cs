using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	GameObject player;

	[SerializeField]
	AudioSource wall;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainTank");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("Bullet")) 
		{
			player.GetComponent<MainTank> ().setCanShoot (true);
			wall.Play ();
			Destroy(col.gameObject);
		}

		if (col.tag.Equals ("EnemyBullet")) 
		{
			Destroy (col.gameObject);
		}
	}
}
