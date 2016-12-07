using UnityEngine;
using System.Collections;

public class Bullet: MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("MainTank");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 1 * Time.deltaTime, 0);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag.Equals ("EnemyBullet")) 
		{
				player.GetComponent<MainTank> ().setCanShoot (true);
				Destroy (col.gameObject);
				Destroy (gameObject);
		}
	}
}
