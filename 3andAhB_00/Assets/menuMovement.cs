using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMovement : MonoBehaviour
{
	public GameObject playArrow;
	public GameObject creditArrow;

	public GameObject creditos;

	private int moveAmount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if(moveAmount == 0)
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				moveAmount++;
				creditArrow.SetActive(true);
				playArrow.SetActive(false);
			}

			if (Input.GetKeyDown(KeyCode.Return))
				SceneManager.LoadScene(1, LoadSceneMode.Single);
		}

		if (moveAmount == 1)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				moveAmount--;
				playArrow.SetActive(true);
				creditArrow.SetActive(false);
			}

			if (Input.GetKeyDown(KeyCode.Return))
				creditos.SetActive(true);
		}

		if (Input.GetKeyDown(KeyCode.Escape))
			creditos.SetActive(false);

	}
}
