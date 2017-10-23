using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninja : MonoBehaviour
{
    public float speed, jumpForce, total_time_attack;
    private float elapsed_time_attack;
    //private Animator anim_control;
    private bool canJump, can_attack;
    public Transform floorVerify, floorVerify2, floorVerify3;
    private int jumpCounter, chao_state;
    public GameObject shuriken;
    public Transform point1, point2;
    
    private float tik_time_elapsed;
    private bool canTik;
    
    public float invunerable_time;
    private float invunerable_elapsed;
    public bool invunerable;
    
    public bool color_inv;
    private float time_color_inv_elapsed;
    private GameObject Clone_prefab, Clone;
    public bool clone;

    public GameObject camera;

    //life
   
    // Use this for initialization
    void Start ()
    {
        //anim_control = GetComponentInChildren<Animator>();
        camera = GameObject.FindGameObjectWithTag("MainCamera");

    
        invunerable = false;
        chao_state = 1;
        clone = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Animator>().SetInteger("jump", jumpCounter);
        GetComponent<Animator>().SetInteger("chao", chao_state);
        move();
        jump();
        atk();
        
        if (!canTik)
        {
            tik_time_elapsed += Time.deltaTime;
            if (tik_time_elapsed >= 1f)
            {
                canTik = true;
            }
        }

        if (invunerable)
        {
            invunerable_elapsed += Time.deltaTime;
            if(invunerable_elapsed >= invunerable_time)
            {
                invunerable = false;
                invunerable_elapsed = 0;
            }

            if (color_inv) GetComponent<SpriteRenderer>().color = Color.grey;
            else GetComponent<SpriteRenderer>().color = Color.white;
            time_color_inv_elapsed += Time.deltaTime;
            if (this.time_color_inv_elapsed >= 0.1)
            {
                color_inv = !color_inv;
                this.time_color_inv_elapsed = 0;
            }
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        

    }

    void createClone()
    {
        if (!clone)
        {
            clone = true;
            Instantiate(Clone_prefab, transform.position, transform.rotation);
            Clone = GameObject.FindGameObjectWithTag("Clonezeira");
        }
    }


    void move()
    {
        //Check if the player is touching the key's for moviment to right (D and righ arrow)
        if (Input.GetAxisRaw("Horizontal") > 0)
        {   //Move the character while the player pressing the key
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //Adjusts the position of the character
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        //Check if the player is touching the key's for moviment to left (A and left arrow)
        if (Input.GetAxisRaw("Horizontal") < 0)
        {   //Move the character while the player pressing the key
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //Adjusts the position of the character (flip) 
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        //Sets the parameter move, for the walk animation
        //anim_control.SetFloat("move", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        GetComponent<Animator>().SetFloat("move", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

    }
    void jump()
    {
        //Define if the character can jump, if the character is touching the floor
        canJump = Physics2D.Linecast(transform.position, floorVerify.position, 1 << LayerMask.NameToLayer("Floor"));
        chao_state = 1;
        if (!canJump)
        {
            canJump = Physics2D.Linecast(transform.position, floorVerify2.position, 1 << LayerMask.NameToLayer("jackchan"));
            if(canJump) chao_state = 2;
        }

        if (!canJump)
        {
            canJump = Physics2D.Linecast(transform.position, floorVerify3.position, 1 << LayerMask.NameToLayer("jackchan"));
            if (canJump) chao_state = 2;
        }

            
        
        //Send a bool to animator, referents at if character is touching the floor, for the jump animation
        //print(canJump);
        //anim_control.SetBool("canJump", canJump);
        //Reset the jump counter
        if (canJump) jumpCounter = 0;
        //Check if the player pressed the jump button (Space) and (is touching the floor OR has 1 jump only)
        if (Input.GetButtonDown("Jump") && jumpCounter < 1)
        {   //Make the jump

            //GetComponent<Rigidbody2D>().Sleep();
            //GetComponent<Rigidbody2D>().WakeUp();
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            //anim_control.SetTrigger("Jump");
            //Upgrade the jump counter
            jumpCounter++;
            //Reset the time stoped
        }
    }
    void atk()
    {
        this.elapsed_time_attack += Time.deltaTime;
        if (this.elapsed_time_attack >= this.total_time_attack) this.can_attack = true;

        if (Input.GetButtonDown("Fire1") && this.can_attack)
        {
            this.can_attack = false;
            this.elapsed_time_attack = 0;
            //anim_control.SetTrigger("atk");
            //Reset the time stoped
            if(!GetComponentInChildren<SpriteRenderer>().flipX) Instantiate(this.shuriken, this.point1.position, this.point1.rotation);
            else Instantiate(this.shuriken, this.point2.position, this.point2.rotation);
        }
    }

    public void gainTIK()
    {
        if (canTik)
        {
            camera.GetComponent<camera>().gainTicket();
            canTik = false;
            tik_time_elapsed = 0;
        }
    }
	
    public void takeDamage()
    {
        if (!invunerable)
        {
            camera.GetComponent<camera>().takeDam();
            invunerable = true;
            invunerable_elapsed = 0;
        }
       
    }

    public void gainLife()
    {
        camera.GetComponent<camera>().gainlife();
    }
}
