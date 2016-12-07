using UnityEngine;
using System.Collections;

public class EnemyInstantiator : MonoBehaviour {

	[SerializeField]
	Transform[] PosInst;

	[SerializeField]
	GameObject[] enemy;

	int sort;

	[SerializeField]
	int [] espaco;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateEnemy", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CreateEnemy()
	{
		sort = Random.Range (0, 4);

		if (espaco [sort] == 0) 
		{
			Instantiate (enemy [sort], PosInst [sort].transform.position, Quaternion.identity);
			espaco [sort] = 1;
		}
	}

	public void setEspacos(int valor, int valor2)
	{
		espaco [valor] = valor2;
	}
}
