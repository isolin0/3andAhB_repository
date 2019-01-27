using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{


	private void Start()
	{
		Cursor.visible = false;
	}

	public void Load( int sceneNumber)
	{
		SceneManager.LoadScene(sceneNumber,LoadSceneMode.Single);
	}


}

