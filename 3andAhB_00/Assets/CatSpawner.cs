using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
	public Transform[] startPosition;
	public GameObject catPrefab;

	private GameObject catCopy;
	private float timeBtwMove;
	public float startTimeBtwMove = 3f;
	private float timeOff;
	public float startTimeOff = 3f;
	public bool stopCatSpawn;
	void Start()
	{
		
	}

	void Update()
	{
		if (timeBtwMove <= 0 && stopCatSpawn == false)
		{
			//Move();
			SpawnCat();
			timeBtwMove = startTimeBtwMove;
			stopCatSpawn = true;
		}
		else
		{
			timeBtwMove -= Time.deltaTime;
		}


	}

	private void Move()
	{
		SpawnCat();
		//Debug.Log("entro");
		int randPosition = Random.Range(0, startPosition.Length);
		catCopy.transform.position = startPosition[randPosition].position;

	}

	private void SpawnCat()
	{
		int randStartPosition = Random.Range(0, startPosition.Length);
		transform.position = startPosition[randStartPosition].position;
		catCopy = GameObject.Instantiate(catPrefab, transform.position, Quaternion.identity) as GameObject;
		StartCoroutine("CatAnimation");

	}

	IEnumerator CatAnimation()
	{
		yield return new WaitForSeconds(2);
		Destroy(catCopy);
		yield return new WaitForSeconds(3);
		stopCatSpawn = false;
		StopAllCoroutines();
		yield return null;
			
	}



}
