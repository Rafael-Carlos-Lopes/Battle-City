using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	GameObject player;

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
			Destroy(col.gameObject);
			Destroy(gameObject);
		}

		if (col.tag.Equals ("EnemyBullet")) 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
