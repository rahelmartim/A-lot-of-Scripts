using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emy : MonoBehaviour
{
    private const bool LEFT = true, RIGHT = false;
    private bool visible;
    public float total_time;
    public float speed;
    private float time_elapsed;
    public bool state;
    
    public float total_time_attack;
    private float elapsed_time_attack;
    private bool can_attack;
    public GameObject shuriken,shurikenleft;
    public Transform point1;

    private float life = 5;
    // Use this for initialization
    void Start ()
    {
        visible = false;
        int rand = Random.Range(0, 2);
        if (rand == 1) state = true;
        else state = false;
        
        this.time_elapsed = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        lifecounter();
        if (visible) atk();
        else
        {
            this.time_elapsed += Time.deltaTime;
            if (this.time_elapsed >= this.total_time)
            {
                this.state = !this.state;
                this.time_elapsed = 0;
            }
            if (this.state == LEFT)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
    }

    void atk()
    {
        this.elapsed_time_attack += Time.deltaTime;
        if (this.elapsed_time_attack >= this.total_time_attack) this.can_attack = true;

        if (this.can_attack)
        {
            this.can_attack = false;
            this.elapsed_time_attack = 0;
            //anim_control.SetTrigger("atk");
            //Reset the time stoped
            if (state)
            {
                Instantiate(this.shuriken, this.point1.position, this.point1.rotation);
            }
            else
            {
                Instantiate(this.shurikenleft, this.point1.position, this.point1.rotation);
            }
            
        }
    }

    void lifecounter()
    {
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            visible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            visible = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player_su")
        {
            life -= 1;
            Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "player_su_put")
        {
            life -= 0.5f;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "player_su_mat")
        {
            life = 0;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "player_su_resi")
        {
            life -= 1;

        }
        else if (collision.gameObject.tag == "player_su_life")
        {
            life -= 1;
            Destroy(collision.gameObject);
            print("dropa life");
        }

    }

}
