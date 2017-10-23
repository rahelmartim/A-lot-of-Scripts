using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikefall : MonoBehaviour {
    private bool actived;
	// Use this for initialization
	void Start () {
        this.actived = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {   //Add a force, to jump the player
            if(!this.actived)
            {
                gameObject.AddComponent<Rigidbody2D>();
                this.actived = true;
                GetComponent<Rigidbody2D>().mass = 100;
                GetComponent<Rigidbody2D>().gravityScale = 33.53f;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
       
        if (colisor.gameObject.layer == 8)
        {
            GetComponent<Rigidbody2D>().freezeRotation = true;
            GetComponent<Rigidbody2D>().mass = 10000000000000000;
        }
        

    }
}
