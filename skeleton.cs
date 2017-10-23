using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour {
    private const bool LEFT = true, RIGHT = false;
    private GameObject player;
    public float total_time;
    public float speed;
    private float time_elapsed;
    public bool state;
    public Animator anim_control;
    public float force;
    public GameObject skeleton_dead;
    public Vector3 adjust;
    public bool dead;

    // Use this for initialization
    void Start ()
    {
        this.time_elapsed = 0;
        this.dead = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.GetComponent<Isayah>().state == false  && GetComponent<Transform>().position.z > 0)
        {
            GetComponent<Transform>().Translate(0, 0, -9);
        }
        else if (player.GetComponent<Isayah>().state == true && GetComponent<Transform>().position.z < 9)
        {
            GetComponent<Transform>().Translate(0, 0, 9);
        }


        this.time_elapsed += Time.deltaTime;
        if (this.time_elapsed >= this.total_time)
        {
            this.state = !this.state;
            this.time_elapsed = 0;
        }
        if(this.state == LEFT)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            anim_control.SetTrigger("atck");
            colisor.gameObject.GetComponentInChildren<hp>().lose_life();
            if (player.GetComponent<Transform>().position.x < transform.position.x) { 
                
                if (player.GetComponent<Isayah>().state == false)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                }
                else if (player.GetComponent<Isayah>().state == true)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);
                }
            }
            else
            {
                if (player.GetComponent<Isayah>().state == false)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
                }
                else if (player.GetComponent<Isayah>().state == true)
                {
                    player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
                }
            }
        }else if (colisor.gameObject.tag  == "fireball" || colisor.gameObject.tag == "ghostball")
        {
            if (!dead)
            {
                var distancia = (colisor.transform.position.x - transform.position.x);
                // if (colisor.gameObject.GetComponent<Transform>().position.x < transform.position.x)
                if (distancia < 0)
                {
                    Destroy(gameObject);
                    Instantiate(skeleton_dead, transform.position + adjust, transform.rotation);
                }
                else
                {
   
                    Destroy(gameObject);
                    Instantiate(skeleton_dead, transform.position + adjust, new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w));
                }
            }
        }

    }

    public void dead_h()
    {
        
        Destroy(gameObject);
    }
}
