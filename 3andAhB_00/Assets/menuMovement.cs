using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMovement : MonoBehaviour
{
    public GameObject arrow2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        arrow2 = GameObject.Find("arrowPos2");

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -50, 0), Space.World);
        }
    }
}
