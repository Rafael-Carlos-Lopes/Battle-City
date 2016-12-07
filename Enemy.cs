using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	Animator anim;
	int direcao;
	
	Rigidbody2D rb2d;

	GameObject instantiator, player;

	[SerializeField]
	GameObject bullet;

	bool gameOver;

	bool destroyed;

	[SerializeField]
	AudioSource exploding;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		instantiator = GameObject.FindGameObjectWithTag ("Instantiator");
		player = GameObject.FindGameObjectWithTag ("MainTank");
		InvokeRepeating ("SortearDirecao", 2f, 2f);
		InvokeRepeating ("Shoot", 1.5f, 1.5f);
		
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (destroyed == true) 
		{
			rb2d.velocity = new Vector2 (0, 0);
		}

		if (gameOver == false) {
			gameOver = player.GetComponent<MainTank> ().GetGameOver ();

			if (instantiator == null) {
				instantiator = GameObject.FindGameObjectWithTag ("Instantiator");
			}

			if (player == null) {
				player = GameObject.FindGameObjectWithTag ("MainTank");
			}

			if (destroyed == false) {
				if (direcao == 0) {
					transform.eulerAngles = new Vector3 (0, 0, 0);
					rb2d.velocity = new Vector2 (0, 0.5f);
				}
		
				if (direcao == 1) {
					transform.eulerAngles = new Vector3 (0, 0, 180);
					rb2d.velocity = new Vector2 (0, -0.5f);
				}
		
				if (direcao == 2) {
					transform.eulerAngles = new Vector3 (0, 0, 270);
					rb2d.velocity = new Vector2 (0.5f, 0);
				}
		
				if (direcao == 3) {
					transform.eulerAngles = new Vector3 (0, 0, 90);
					rb2d.velocity = new Vector2 (-0.5f, 0);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (destroyed == false) {
			if (gameOver == false) {
				if (col.tag.Equals ("Bullet")) {
					if (gameObject.tag.Equals ("EnemyTank")) {
						instantiator.GetComponent<EnemyInstantiator> ().setEspacos (0, 0);
					} else if (gameObject.tag.Equals ("EnemyTank2")) {
						instantiator.GetComponent<EnemyInstantiator> ().setEspacos (1, 0);
					} else if (gameObject.tag.Equals ("EnemyTank3")) {
						instantiator.GetComponent<EnemyInstantiator> ().setEspacos (2, 0);
					} else if (gameObject.tag.Equals ("EnemyTank4")) {
						instantiator.GetComponent<EnemyInstantiator> ().setEspacos (3, 0);
					}

					Destroy (col.gameObject);
					exploding.Play ();
					destroyed = true;
					player.GetComponent<MainTank> ().IncreaseScore ();
					player.GetComponent<MainTank> ().IncreaseEnemiesDestroyed ();
					player.GetComponent<MainTank> ().setCanShoot (true);
					player.GetComponent<MainTank> ().DecreaseEnemyCount ();
					anim.SetBool ("Exploding", true);
					Invoke ("Destruir", 0.8f);

				}
			}
		}
	}

	void SortearDirecao()
	{
		if (destroyed == false) {
			if (gameOver == false) {
				direcao = Random.Range (0, 4);
		
				rb2d.velocity = new Vector2 (0, 0);
			}
		}
	}

	void Shoot()
	{
		if (destroyed == false) {
			if (gameOver == false) {
				Instantiate (bullet, transform.position, transform.rotation);
			}
		}
	}

	void Destruir()
	{
		Destroy (gameObject);
	}
		
}
