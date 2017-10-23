using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour {

    private bool damaged;
    private float total_time;
    private float time_elapsed;
	// Use this for initialization
	void Start () {
        this.damaged = false;
        this.total_time = 0.1f;
        this.time_elapsed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.damaged)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
        this.time_elapsed += Time.deltaTime;
        if((this.time_elapsed >= this.total_time) && this.damaged)
        {
            damaged = false;
            this.time_elapsed = 0;
        }
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {   //if the player
        //take damage
        if (colisor.gameObject.tag == "Bullet_player")
        {
            this.damaged = true;
            this.time_elapsed = 0;
        }

    }
}
