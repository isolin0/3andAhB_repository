using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFall : MonoBehaviour
{
	private float fallTime;
	public float startFallTime;
	public bool isMoving = false;
    private Rigidbody2D rb;

	public Animator anim;
	//anim.SetBool("nombre del parametro",true);

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

        //asd
	}

    void fall()
    {
		FindObjectOfType<PlayerController>().SeAsusta();
        rb.gravityScale = 1;
        anim.SetBool("seCae", true);

        //Destroy object's spawner
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
            anim.SetBool("seMueve", true);
            isMoving = true;
            // start fall timer
            fallTime = startFallTime;
        }

		if(col.tag == "floor")
        {
            rb.gravityScale = 0;
            anim.SetBool("seRompe", true);
            // FindObjectOfType<AudioManager>().Play("objetoRompe");
            GameM.hpMax--;
        }


	}

    void OnTriggerStay2D(Collider2D col)
    {
       

        if (col.tag == "dog" && Input.GetKeyDown(KeyCode.X))
        {
			FindObjectOfType<PlayerController>().Arregla();
			isMoving = false;
            anim.SetBool("seMueve", false);
            anim.SetBool("arregla", false);
        }

        if(col.tag == "floor")
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
           
        }


    }







}


