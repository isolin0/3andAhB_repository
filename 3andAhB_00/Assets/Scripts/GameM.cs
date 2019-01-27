using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameM : MonoBehaviour
{

    public static int hpMax = 3;
    public static float timerMax = 60;
    public int startHP = 3;
    public float startTimer = 60;
    public Transform corazon1;
    public Transform corazon2;
    public Transform corazon3;

	public Text countDownText;

	public int level;

	public static GameM instance;
	/*
	void Awake()
	{

		if (instance == null)
			instance = this;
		else
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);

		

	}
	*/
	// Start is called before the first frame update
	void Start()
    {
        hpMax = startHP;
        timerMax = startTimer;
		FindObjectOfType<AudioManager>().Stop("intro");
		FindObjectOfType<AudioManager>().Play("music");
		
	}

    // Update is called once per frame
    void Update()
    {
		Debug.Log("level : " + level);
        startHP = hpMax;
        startTimer -= Time.deltaTime;
        timerMax -= Time.deltaTime;

		if(countDownText!=null)
		countDownText.text = startTimer.ToString("0");
        
        switch (hpMax){
            case 2:
                Destroy(corazon3.gameObject);
                break;
            case 1:
                Destroy(corazon2.gameObject);
                break;
            case 0:
                Destroy(corazon1.gameObject);
	
				SceneManager.LoadScene(5, LoadSceneMode.Single);
				break;
        }

		if (startTimer <= 0 && hpMax >=1)
		{
			if (level == 1)
			{
				
				SceneManager.LoadScene(2, LoadSceneMode.Single);
			}
			if (level == 2)
			{
				
				SceneManager.LoadScene(3, LoadSceneMode.Single);
			}

			if (level == 3)
			{
				
				SceneManager.LoadScene(4, LoadSceneMode.Single);
			}
			/*
			level+=1;
			//Debug.Log("ganaste");
			
			SceneManager.LoadScene(level, LoadSceneMode.Single);
			/*
			

			

			*/

		}



	}
}
