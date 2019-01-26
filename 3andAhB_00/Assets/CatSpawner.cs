using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
	public Transform[] startPosition;
	public GameObject catPrefab;

	private GameObject catCopy;
	private float timeBtwMove;
	public float startTimeBtwMove = 0.25f;
	public bool stopCatMove;
	void Start()
	{
		int randStartPosition = Random.Range(0, startPosition.Length);
		transform.position = startPosition[randStartPosition].position;
		catCopy = GameObject.Instantiate(catPrefab, transform.position, Quaternion.identity) as GameObject;

		
	}

	void Update()
	{
		if (timeBtwMove <= 0 && stopCatMove == false)
		{
			Move();
			timeBtwMove = startTimeBtwMove;
		}
		else
		{
			timeBtwMove -= Time.deltaTime;
		}
	}

	private void Move()
	{
		Debug.Log("entro");
		int randPosition = Random.Range(0, startPosition.Length);
		catCopy.transform.position = startPosition[randPosition].position;

	}
	


}
