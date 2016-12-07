using UnityEngine;
using System.Collections;

public class EnemyBullet: MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 1 * Time.deltaTime, 0);
	}

}
