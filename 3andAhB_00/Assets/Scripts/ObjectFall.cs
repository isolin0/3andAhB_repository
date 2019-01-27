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
            StartCoroutine("GatoToca");
            
        }

		if(col.tag == "floor")
        {
            rb.gravityScale = 0;
            anim.SetBool("seRompe", true);
            FindObjectOfType<AudioManager>().Play("crash1");
            GameM.hpMax-=1;
        }


	}

    IEnumerator GatoToca()
    {
        yield return new WaitForSeconds(0.7f);
		FindObjectOfType<AudioManager>().Play("empujar");
		anim.SetBool("seMueve", true);
        isMoving = true;
        // start fall timer
        fallTime = startFallTime;
        StopAllCoroutines();
        yield return null;
    }

    void OnTriggerStay2D(Collider2D col)
    {
       

        if (col.tag == "dog" && Input.GetKeyDown(KeyCode.X))
        {
			FindObjectOfType<PlayerController>().Arregla();
			FindObjectOfType<AudioManager>().Play("acomodar");
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


