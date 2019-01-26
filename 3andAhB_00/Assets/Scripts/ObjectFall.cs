using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
	private float fallTime;
	public float startFallTime;
	public bool isMoving = false;
    private Rigidbody2D rb;

    private void Start()
    {
        fallTime = startFallTime;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
	{
		if (fallTime <= 0 && isMoving)
		{
            fall();
            isMoving = false;
            fallTime = startFallTime;
            //Start Fall Enumerator

        }
		else
		{
            
            fallTime -= Time.deltaTime;
		}

        
	}

    void fall()
    {
        rb.gravityScale = 2;
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

    }


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "cat")
		{
            // start moving anim
            
            isMoving = true;
            // start fall timer
            fallTime = startFallTime;
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
