using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuMovement : MonoBehaviour
{
	public GameObject playArrow;
	public GameObject creditArrow;

	public GameObject creditos;

	public bool winMenu;
	public bool gameOver;

	private int moveAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
		//FindObjectOfType<AudioManager>().Play("intro");
		if(winMenu)
			FindObjectOfType<AudioManager>().Play("win");
		
		if(gameOver)
			FindObjectOfType<AudioManager>().Play("lose");

	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
		{
			creditos.SetActive(false);
		}
			

		if (moveAmount == 0)
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

		

		if (winMenu)
		{
			if (Input.GetKeyDown(KeyCode.Return))
				SceneManager.LoadScene(0, LoadSceneMode.Single);

		}

		if (gameOver)
		{
			if (Input.GetKeyDown(KeyCode.Return))
				SceneManager.LoadScene(0, LoadSceneMode.Single);

		}

	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}
