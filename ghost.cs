using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour {
    //Is the time it will take between one attack and another (attack cooldown).
    public float atkInterval;
    //check the count.
    private float intervalCounter;
    //check if the enemy atacked
    private bool atk;
    //maximum distance of atack
    public float atkRange;
    //atack projetile
    public GameObject atkPrefab;
    private GameObject player;
    //control the animations
    private Animator anim_control;
    public Transform fire_point;
    public float force;
    private bool in_range;
    // Use this for initialization
    void Start ()
    {
        anim_control = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        var distancia = (player.transform.position.x - transform.position.x);
        adjust_euller_angles(distancia);
        atk_control(this.in_range);
        update_time();
    }
    void adjust_euller_angles(float distancia)
    {
        //if distancia > 0 the character is on right side
        //if distancia <= 0 the character is on left side
        if (distancia < 0) transform.eulerAngles = new Vector2(0, 0);
        else               transform.eulerAngles = new Vector2(0, 180); 
    }
    void atk_control(bool range)
    {
        //if the enemy not atacked and the player is on the atack range
        if (range && !atk)
        {
            //Take the player rotation
            var pos = transform.position;
            var dir = player.transform.position - pos;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            anim_control.SetTrigger("atk");
            Instantiate(atkPrefab, fire_point.position, Quaternion.AngleAxis(angle, Vector3.forward));
            atk = true;
        }
    }
    void update_time()
    {
        //reset the atack time
        if (atk)
        {
            intervalCounter += Time.deltaTime;
            if (intervalCounter >= atkInterval)
            {
                atk = false;
                intervalCounter = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "fireball")
        {
            Destroy(gameObject);
        }
        if (colisor.gameObject.tag == "Player")
        {
            //var player = colisor.gameObject.transform.GetComponentInChildren<hp>();
            //player.lose_life();
            colisor.gameObject.GetComponent<Rigidbody2D>().Sleep();
            colisor.gameObject.GetComponent<Rigidbody2D>().WakeUp();
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * this.force);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") this.in_range = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") this.in_range = false;
    }
}
