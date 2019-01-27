using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    
    


    public void Load( int sceneNumber)
	{
		SceneManager.LoadScene(sceneNumber,LoadSceneMode.Single);
	}


}

