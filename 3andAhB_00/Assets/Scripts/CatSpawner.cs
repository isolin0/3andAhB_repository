using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{
	public Transform[] startPosition; // esta es para las que el gato esta de frente
	public Transform[] startPosition2; // caundo el gato esta de derecha
	public Transform[] startPosition3; // y de izquierda

	public GameObject catPrefab; // frente
	public GameObject catPrefab2; // derecha
	public GameObject catPrefab3; // izquierda


	private GameObject catCopy;

    private float timeBtwMove;
	public float startTimeBtwMove = 3f;
	//private float timeOff;
	//public float startTimeOff = 3f;
	public bool stopCatSpawn;

    private bool startSpawner = true;

    
	private void Start()
	{
        StartCoroutine("StartSpawner");
       
	}

    IEnumerator StartSpawner()
    {
       
        yield return new WaitForSeconds(3);
        Debug.Log("pasa que entra el rutina");
        startSpawner = false;
        StopAllCoroutines();
        yield return null;
        
    }
    
	void Update()
	{
		if (timeBtwMove <= 0 && stopCatSpawn == false && startSpawner == false)
		{
			
			SpawnCat();
			timeBtwMove = startTimeBtwMove;
			stopCatSpawn = true;
		}
		else
		{
			timeBtwMove -= Time.deltaTime;
		}

    
	}

	

	private void SpawnCat()
	{
		int rand = Random.Range(0,3);
        
		switch (rand)
		{
			case 0:
				int randStartPosition = Random.Range(0, startPosition.Length);
				if (startPosition[randStartPosition].position != null)
				{

					transform.position = startPosition[randStartPosition].position;

					catCopy = GameObject.Instantiate(catPrefab, transform.position, Quaternion.identity) as GameObject;
					StartCoroutine("CatAnimation");
				}
				else
					SpawnCat();
				break;

			case 1:
				int randStartPosition2 = Random.Range(0, startPosition2.Length);
				if (startPosition2[randStartPosition2].position != null)
				{

					transform.position = startPosition2[randStartPosition2].position;

					catCopy = GameObject.Instantiate(catPrefab2, transform.position, Quaternion.identity) as GameObject;
					StartCoroutine("CatAnimation");
				}
				else
					SpawnCat();
				break;

			case 2:
				int randStartPosition3 = Random.Range(0, startPosition3.Length);
				if (startPosition3[randStartPosition3].position != null)
				{

					transform.position = startPosition3[randStartPosition3].position;

					catCopy = GameObject.Instantiate(catPrefab3, transform.position, Quaternion.identity) as GameObject;
					StartCoroutine("CatAnimation");
				}
				else
					SpawnCat();
				break;
		}
		
		
            

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
