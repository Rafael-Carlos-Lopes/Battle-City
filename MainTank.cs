using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainTank: MonoBehaviour {

	Rigidbody2D rgb;

	[SerializeField]
	GameObject bullet, symbol;

	[SerializeField]
	GameObject[] enemyCount;

	int enemiesDestroyed;
	int score;

	[SerializeField]
	Transform gameOverT;

	bool gameOver;

	int count = 16;

	bool win;

	[SerializeField]
	TextMesh lifeTXT;

	int life = 2;

	bool Up,Down,Left,Right;

	Animator anim;

	bool canShoot = true;
	bool Shot;

	float delay;

	Vector3 startPosition;

	[SerializeField]
	GameObject game, scoreCount, invincibleAnimation, gameOverScreen;

	bool invincible = true;

	bool trocar;

	[SerializeField]
	AudioSource shootAudio, stopAudio, walkingAudio;

	// Use this for initialization
	void Start () {
		stopAudio.volume = 0;
		walkingAudio.volume = 0;
		stopAudio.Play ();
		Invoke ("IncreaseVolume", 5f);
		Invoke ("StopInvincible", 4f);

		startPosition = transform.position;
		anim = GetComponent<Animator> ();
		rgb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}

		if (invincible == false)
			invincibleAnimation.SetActive (false);
		else
			invincibleAnimation.SetActive (true);

		if (gameOver == true) 
		{
			stopAudio.Stop ();
			walkingAudio.Stop ();
			rgb.velocity = new Vector2(0,0);

			if(win == false)
			{
			if(gameOverT.position.y < 0)
			{
				gameOverT.Translate(0,1 * Time.deltaTime,0);
			}
			}

			if (trocar == false) 
			{
				Invoke ("ChangeScene", 5f);
				trocar = true;
			}
		}

		lifeTXT.text = life.ToString ();

		if (life < 0) 
		{
			life = 0;
			gameOver = true;
		}

		if(gameOver == false)
		Movimento ();
		

		if (canShoot == true) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				//Shot = true;
				shootAudio.Play ();
				canShoot = false;
				Instantiate (bullet, transform.position, transform.rotation);
			}
		}
	
	}

	void Movimento()
	{
		if (rgb.velocity.x != 0 || rgb.velocity.y != 0) {
			anim.SetBool ("Walking", true);
		} else {
			anim.SetBool ("Walking", false);
		}

		if (gameOver == false) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow)) {
				walkingAudio.Play ();
				stopAudio.Stop ();
			}

			if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
				walkingAudio.Stop ();
				stopAudio.Play ();
			}
		}

		if (Up == true) 
		{
			Left = false;
			Right = false;
			Down = false;
		}
		
		if (Down == true) 
		{
			Up = false;
			Left = false;
			Right = false;
		}
		
		if (Left == true) 
		{
			Up = false;
			Right = false;
			Down = false;
		}
		
		if (Right == true) 
		{
			Up = false;
			Left = false;
			Down = false;
		}
		
		//rgb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		
		if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			Up = false;
			rgb.velocity = new Vector2(0,0);
		}
		
		if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			Down = false;
			rgb.velocity = new Vector2(0,0);
		}
		
		if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			Right = false;
			rgb.velocity = new Vector2(0,0);
		}
		
		if (Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			Left = false;
			rgb.velocity = new Vector2(0,0);
		}
		
		if (Down == false && Right == false && Left == false) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				Up = true;
				rgb.velocity = new Vector2 (0, 0.5f);
				transform.eulerAngles = new Vector3 (0, 0, 0);
			}
		}
		
		if(Up == false && Left == false && Right == false)
		{
			if (Input.GetKey (KeyCode.DownArrow)) 
			{
				Down = true;
				rgb.velocity = new Vector2(0,-0.5f);
				transform.eulerAngles = new Vector3(0,0,180);
			}
		}
		
		if(Down == false && Left == false && Up == false)
		{
			if (Input.GetKey (KeyCode.RightArrow)) 
			{
				rgb.velocity = new Vector2(0.5f,0);
				transform.eulerAngles = new Vector3(0,0,270);
			}
		}
		
		if (Down == false && Up == false && Right == false) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rgb.velocity = new Vector2 (-0.5f, 0);
				transform.eulerAngles = new Vector3 (0, 0, 90);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (invincible == false) {
			if (col.tag.Equals ("EnemyBullet")) {
				Destroy (col.gameObject);
				life--;
				transform.position = startPosition;
				Invoke ("StopInvincible", 4f);
				invincible = true;
			}
		}
	}

	public void setCanShoot(bool valor)
	{
		canShoot = valor;
	}

	public void DecreaseEnemyCount()
	{
		if (count > 0) {
			enemyCount [count].SetActive (false);
			count--;
		}

		if (count == 0) 
		{
			win = true;
			gameOver = true;
		}
	}

	public void SetGameOver(bool valor)
	{
		gameOver = valor;
	}

	void ChangeScene()
	{
		if (scoreCount.activeInHierarchy == false) {
			game.SetActive (false);
			scoreCount.SetActive (true);
		} 

		else 
		{
			scoreCount.SetActive (false);
			gameOverScreen.SetActive (true);
		}
	}

	public bool GetGameOver()
	{
		return gameOver;
	}

	public void IncreaseEnemiesDestroyed()
	{
		enemiesDestroyed++;
	}

	public void IncreaseScore()
	{
		score += 100;
	}

	public int GetEnemiesDestroyed()
	{
		return enemiesDestroyed;
	}

	public int GetScore()
	{
		return score;
	}

	void StopInvincible()
	{
		invincible = false;
	}

	public void setChangeScene()
	{
		ChangeScene ();
	}

	public bool GetWin()
	{
		return win;
	}

	void IncreaseVolume()
	{
		stopAudio.volume = 0.8f;
		walkingAudio.volume = 0.8f;
	}
}
