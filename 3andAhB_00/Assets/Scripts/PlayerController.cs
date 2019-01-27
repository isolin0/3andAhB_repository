using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public float jumpForce;
	private float moveInput;

	public Rigidbody2D rb;
	public Animator anim;

	private bool facingRight = true;

	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask whatIsGround;

	private int extraJump;
	public int extraJumpValue;
    // Start is called before the first frame update
    void Start()
    {
		extraJump = extraJumpValue;
    }
	private void Update()
	{
		if (isGrounded == true)
		{
			
			extraJump = extraJumpValue;
			
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)&& extraJump > 0)
		{
			anim.SetBool("isJumping", true);
			isGrounded = false;
			rb.velocity = Vector2.up * jumpForce;
			
			extraJump--;
		}else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJump == 0 && isGrounded==true)
		{
			anim.SetBool("isJumping", true);
			isGrounded = false;
			rb.velocity = Vector2.up * jumpForce;
			
		}
	}


	// Update is called once per frame
	void FixedUpdate()
    {

		//isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

		moveInput = Input.GetAxis("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(moveInput * speed));
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

		if(facingRight== false && moveInput > 0)
		{
			Flip();
		}else if (facingRight== true && moveInput < 0)
		{
			Flip();
		}
    }

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 Scaler = transform.localScale;
		Scaler.x *= -1;
		transform.localScale = Scaler;
	
	}
	

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			
			anim.SetBool("isJumping", false);
			isGrounded = true;
		}
			
		
	}
}
