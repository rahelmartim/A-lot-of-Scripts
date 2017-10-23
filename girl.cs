using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girl : MonoBehaviour
{
    private bool no_alcance = false;
    public Transform player;
    public float speed;
	// Use this for initialization
	void Start ()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (no_alcance) move();  
   
	}
    
    void move()
    {
        if (transform.position.x - player.position.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<SpriteRenderer>().flipY = false;

            var pos = transform.position;
            var dir = player.transform.position - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            //GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().flipY = true;

            var pos = transform.position;
            var dir = player.transform.position - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") Application.LoadLevel("lose");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") no_alcance = true;     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") no_alcance = false; 
    }

    public void stop_force()
    {

        Invoke("stoped", 2f);
    }
    
    void stoped()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Rigidbody2D>().WakeUp();
    }
}
