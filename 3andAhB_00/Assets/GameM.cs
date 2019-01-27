using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{

    public static int hpMax = 3;
    public static float timerMax = 60;
    public int startHP = 3;
    public float startTimer = 60;
    public Transform corazon1;
    public Transform corazon2;
    public Transform corazon3;




    // Start is called before the first frame update
    void Start()
    {
        hpMax = startHP;
        timerMax = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        startHP = hpMax;
        startTimer -= Time.deltaTime;
        timerMax -= Time.deltaTime; 
        
        switch (hpMax){
            case 2:
                Destroy(corazon3.gameObject);
                break;
            case 1:
                Destroy(corazon2.gameObject);
                break;
            case 0:
                Destroy(corazon1.gameObject);

                break;
        }


    }
}
