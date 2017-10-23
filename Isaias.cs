using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isaias : MonoBehaviour
{
    public float speed;
    public bool armed_on;
    public bool armed;
    public Animator anim_control;
    public float jumpForce;
    public bool canJump;
    public Transform floorVerify;
    private int jumpCounter;
    public GameObject bullet;
    public Transform bullet_point;
    void Start ()
    {
        this.armed = true;
        this.armed_on = false;
        this.jumpCounter = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim_control.SetBool("armed", this.armed);
        move();
        jump();
        fire();

	}
    void move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {   
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {   
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        anim_control.SetFloat("moving", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }
    void jump()
    {
        canJump = Physics2D.Linecast(transform.position, floorVerify.position, 1 << LayerMask.NameToLayer("Floor"));
        //Send a bool to animator, referents at if character is touching the floor, for the jump animation
        //anim_control.SetBool("inFloor", canJump);
        //Reset the jump counter
        if (canJump) jumpCounter = 0;
        //Check if the player pressed the jump button (Space) and (is touching the floor OR has 1 jump only)
        if (Input.GetButtonDown("Jump") && (canJump && jumpCounter < 3))
        {   //Make the jump
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            jumpCounter++;
            anim_control.SetTrigger("jump");
        }
    }
    void fire()
    {
        anim_control.SetBool("armed_on", this.armed_on);
        if (Input.GetButtonDown("Fire1") && this.armed)
        {
            if (!this.armed_on) this.armed_on = true;
            anim_control.SetBool("armed_on", this.armed_on);
            anim_control.SetTrigger("fire");
            Instantiate(bullet, bullet_point.position, bullet_point.rotation);
        }
    }

}
