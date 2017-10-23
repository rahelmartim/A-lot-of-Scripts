using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    //Character
    private int lastPressed;
    public Transform spritePlayer;
    public Transform spritePlayer2;
    //Control the animations of the character
    private Animator animator;
    //life of character
    public GameObject initHP;
    public GameObject hp;
    //max vida of character
    public int maxHp;
    // atual life of character
    private int hpAtual;
    //special atck
    public GameObject ataqueEspecial;
    public GameObject ataqueEspecial2;
    //total time of special atck
    public float duracaoAtaque;
    //active time of special atck
    private float countAtk;
    //check if the character have the picareta
    public bool givePicareta = false;
    //prefab of normal atack
    public GameObject atk2;
    public GameObject atk2p2;
    //clip of normal atack
    public AudioClip normalatckaudio;
    public AudioClip specialatkaudio;
    public AudioClip jumpsound;
    //diamonds
    public GameObject initDiamonds;
    public GameObject diamonds;
    public int diamondsCollec;
    // Use this for initialization
    void Start ()
    {
        lastPressed = 1;
        diamondsCollec = 0;
        //Start the jumpCounter
        jumpCounter = 0;
        //Getting the animator
        animator = spritePlayer.GetComponent<Animator>();
        //Hp
        Instantiate(initHP);
        Instantiate(initDiamonds);
        hp = GameObject.FindGameObjectWithTag("life");
        diamonds = GameObject.FindGameObjectWithTag("diamond");
        hpAtual = maxHp;
        hp.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        hp.GetComponent<GUIText>().text = "HP: " + hpAtual + "/" + maxHp;
        diamonds.GetComponentInChildren<GUIText>().text = " " +diamondsCollec+" / 10 ";


    }
	
	// Update is called once per frame
	void Update ()
    {
        changeCharacter();
        //Used to moviment actions, walk and jump
        move();
        atk();
        diamonds.GetComponentInChildren<GUIText>().text ="" +diamondsCollec + " / 10 ";
    }

    void move()
    {   //to final scene
        if (GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
        {
            //Check if the player is touching the key's for moviment to right (D and righ arrow)
            if (Input.GetAxisRaw("Horizontal") > 0)
            {   //Move the character while the player pressing the key
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                //Adjusts the position of the character
                transform.eulerAngles = new Vector2(0, 0);
            }
            //Check if the player is touching the key's for moviment to left (A and left arrow)
            if (Input.GetAxisRaw("Horizontal") < 0)
            {   //Move the character while the player pressing the key
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                //Adjusts the position of the character (flip) 
                transform.eulerAngles = new Vector2(0, 180);
            }
            //Sets the parameter move, for the walk animation
            animator.SetFloat("move", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        }
       
        
        //Define if the character can jump, if the character is touching the floor
        canJump = Physics2D.Linecast(transform.position, floorVerify.position, 1 << LayerMask.NameToLayer("Floor"));
        //Send a bool to animator, referents at if character is touching the floor, for the jump animation
        animator.SetBool("inFloor", canJump);
        //Reset the jump counter
        if (canJump) jumpCounter = 0;
        //Check if the player pressed the jump button (Space) and (is touching the floor OR has 1 jump only)
        if (Input.GetButtonDown("Jump") && ( canJump || jumpCounter < 2 ) )
        {   //Make the jump
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            gameObject.GetComponent<AudioSource>().clip = jumpsound;
            gameObject.GetComponent<AudioSource>().Play();
            //Upgrade the jump counter
            jumpCounter++;
        }
    }
    //Used to lose life
    public void loseLife(int damage)
    {   //Take the damage
        hpAtual -= damage;
        //check if the character is die
        if (hpAtual <= 0)
        {
            //reestart level
            Application.LoadLevel(Application.loadedLevel);
        }
        //change color, if the character in danger status
        if ((hpAtual * 100 / maxHp) < 30)
        {   //Make the color red
            hp.GetComponent<GUIText>().color = Color.red;
        }
        //reload the text life
        hp.GetComponent<GUIText>().text = "HP: " + hpAtual + "/" + maxHp;
    }
    //Used to gain Life
    public void gainLife(int regen)
    {   //Regen the life
        hpAtual += regen;
        //Can't pass the limit
        if (hpAtual > maxHp)
        {
            hpAtual = maxHp;
        }
        //Check if the character in normal status
        if ((hpAtual * 100 / maxHp) >= 30)
        {
            hp.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        }
        //reload the text life
        hp.GetComponent<GUIText>().text = "HP: " + hpAtual + "/" + maxHp;
    }
    //used to atack
    //check if the player press the button of fire or the animations time over
    void atk()
    {   //start the animation
        if (Input.GetButtonDown("Fire1"))
        {
            if (lastPressed == 1)
            {
                ataqueEspecial.SetActive(true);
            }
            if (lastPressed == 2)
            {
                ataqueEspecial2.SetActive(true);
            }
           
            gameObject.GetComponent<AudioSource>().clip = specialatkaudio;
            gameObject.GetComponent<AudioSource>().Play();
            countAtk = 0f;
            //coust of atck
            loseLife(30);
        }
        //while pressed continue atk
        if (Input.GetButton("Fire1"))
        {
            countAtk += Time.deltaTime;
            //if the time over, cancel the atck
            if (countAtk >= duracaoAtaque)
            {
                if (lastPressed == 1)
                {
                    ataqueEspecial.SetActive(false);
                }
                if (lastPressed == 2)
                {
                    ataqueEspecial2.SetActive(false);
                }
                gameObject.GetComponent<AudioSource>().Stop();
            }
        }
        //if the player press up the button, cancel the atk
        if (Input.GetButtonUp("Fire1"))
        {
            if (lastPressed == 1)
            {
                ataqueEspecial.SetActive(false);
            }
            if (lastPressed == 2)
            {
                ataqueEspecial2.SetActive(false);
            }
            gameObject.GetComponent<AudioSource>().Stop();
        }
        //normal atack
        if (Input.GetButtonDown("Fire2"))
        {
            if (lastPressed == 1)
            {
                Instantiate(atk2, transform.position, transform.rotation);
            }
            if (lastPressed == 2)
            {
                Instantiate(atk2p2, transform.position, transform.rotation);
            }
           
            gameObject.GetComponent<AudioSource>().clip = normalatckaudio;
            gameObject.GetComponent<AudioSource>().Play();
            loseLife(5);
        }

    }

    void changeCharacter()
    {
        if (Input.GetKeyDown("1"))
        {
            lastPressed = 1;
            spritePlayer.gameObject.SetActive(true);
            spritePlayer2.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            lastPressed = 2;
            spritePlayer.gameObject.SetActive(false);
            spritePlayer2.gameObject.SetActive(true);
        }
        if (lastPressed == 1)
        {
            animator = spritePlayer.GetComponent<Animator>();
        }
        if (lastPressed == 2)
        {
            animator = spritePlayer2.GetComponent<Animator>();
        }
    
    }
}
