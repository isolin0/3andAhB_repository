using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
	private float fallTime;
	public float startFallTime;
	public bool isMoving =false;



	void Update()
	{
		if (fallTime <= 0 && isMoving)
		{
			fallTime = startFallTime;
			//Start Fall Enumerator
		}
		else
		{
			fallTime -= Time.deltaTime;
		}
	}

    
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "cat")
		{
			// start moving anim
			isMoving = true;
		}

		
	}

    void OnTriggerStay2D(Collider2D col)
    {
       

        if (col.tag == "dog")
        {
            //stop moving anim
            isMoving = false;
        }
    }
}
