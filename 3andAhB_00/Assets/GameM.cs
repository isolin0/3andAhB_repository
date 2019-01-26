using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameM : MonoBehaviour
{

    public static int hpMax = 3;
    public static float timerMax = 60;
    public int startHP = 3;
    public float startTimer = 60;

    // Start is called before the first frame update
    void Start()
    {
        hpMax = startHP;
        timerMax = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
                                
    }
}
