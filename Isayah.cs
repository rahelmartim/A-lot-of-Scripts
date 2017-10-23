using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isayah : MonoBehaviour {
    public string check_point;
    public const bool LEFT = true;
    public const bool RIGHT = false;
    //variables
    //Determines the velocity that the o character walks
    public float speed;
    //Determines the height of the character's jump
    public float jumpForce;
    //check if the character is touching the floor
    private bool canJump;
    //Checker, if the character is touching the floor
    public Transform floorVerify;
    //Counter, to check if the character has jumped, used for double jump
    private int jumpCounter;
    //Game Object to control the anims
    public Animator anim_control;
    //Account the time the player stood
    public float time_stoped;
    //Total time to stay puto
    public float time_puto;
    // Use this for initialization
    public Transform fire_point;
    public Transform fire_point2;
    public GameObject fireball_prefab;
    public bool state;
    private float elapsed_time_attack;
    public float total_time_attack;
    private bool can_attack;

    public GameObject camera, camera2;
    public float up_limit;

    void Start ()
    {
        this.state = RIGHT;
        this.time_stoped = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        move();
        jump();
        update_time();
        fire();
        resetgame();
        changecamera();

    }
    //Make the move
    void move()
    {
        //Check if the player is touching the key's for moviment to right (D and righ arrow)
        if (Input.GetAxisRaw("Horizontal") > 0)
        {   //Move the character while the player pressing the key
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //Adjusts the position of the character
            transform.eulerAngles = new Vector2(0, 0);
            this.state = RIGHT;
            //Reset the time stoped
            this.time_stoped = 0;
        }
        //Check if the player is touching the key's for moviment to left (A and left arrow)
        if (Input.GetAxisRaw("Horizontal") < 0)
        {   //Move the character while the player pressing the key
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //Adjusts the position of the character (flip) 
            transform.eulerAngles = new Vector2(0, 180);
            this.state = LEFT;
            //Reset the time stoped
            this.time_stoped = 0;
        }
        //Sets the parameter move, for the walk animation
        anim_control.SetFloat("move", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
    }
    //Update the time
    void update_time()
    {
        this.time_stoped += Time.deltaTime;
        //Checks if the player stay the time puto stopped
        if (this.time_stoped >= this.time_puto) anim_control.SetBool("puto", true);
        else anim_control.SetBool("puto", false);
    }
    void jump()
    {
        //Define if the character can jump, if the character is touching the floor
        canJump = Physics2D.Linecast(transform.position, floorVerify.position, 1 << LayerMask.NameToLayer("Floor"));
        //Send a bool to animator, referents at if character is touching the floor, for the jump animation
        anim_control.SetBool("canJump", canJump);
        //Reset the jump counter
        if (canJump) jumpCounter = 0;
        //Check if the player pressed the jump button (Space) and (is touching the floor OR has 1 jump only)
        if (Input.GetButtonDown("Jump") && jumpCounter < 2)
        {   //Make the jump
           
            GetComponent<Rigidbody2D>().Sleep();
            GetComponent<Rigidbody2D>().WakeUp();
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            anim_control.SetTrigger("jump");
            //Upgrade the jump counter
            jumpCounter++;
            //Reset the time stoped
            this.time_stoped = 0;
        }
        
        
    }
    void fire()
    {
        this.elapsed_time_attack += Time.deltaTime;
        if (this.elapsed_time_attack >= this.total_time_attack)     this.can_attack = true;
        
        if (Input.GetButtonDown("Fire1") && this.can_attack)
        {
            this.can_attack = false;
            this.elapsed_time_attack = 0;
            anim_control.SetTrigger("atck");
            //Reset the time stoped
            this.time_stoped = 0;
            if (GetComponent<Transform>().rotation.y == 180) Instantiate(this.fireball_prefab, this.fire_point2.position, this.fire_point2.rotation);
            else                                            Instantiate(this.fireball_prefab, this.fire_point.position, this.fire_point.rotation);
        }
    }

    void resetgame()
    {
        if (Input.GetButtonDown("reset"))
        {
            if (this.check_point == "no_check")
            {
                Application.LoadLevel("one");
            }else if (this.check_point == "check_1")
            {
                Application.LoadLevel("one_2");
            }
            
        }
        
    }
    void changecamera()
    {
        if (transform.position.y >= this.up_limit)      set_camera_2();
        else                                            set_camera_1();
        
    }
    private void set_camera_1()
    {
        camera.GetComponent<Camera>().targetDisplay = 0;
        camera2.GetComponent<Camera>().targetDisplay = 1;
        camera.GetComponent<AudioListener>().enabled = true;
        camera2.GetComponent<AudioListener>().enabled = false;
        
    }
    private void set_camera_2()
    {
        camera2.GetComponent<Camera>().targetDisplay = 0;
        camera.GetComponent<Camera>().targetDisplay = 1;
        camera2.GetComponent<AudioListener>().enabled = true;
        camera.GetComponent<AudioListener>().enabled = false;

    }
    public void die()
    {
       
        this.speed = 0;
        this.jumpForce = 0;
        Invoke("Chama", 2.2f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    void Chama()
    {

        if (this.check_point == "no_check")             Application.LoadLevel("one");
        else if (this.check_point == "check_1")         Application.LoadLevel("one_2");
            
    }
}
