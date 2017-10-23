using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour {
    //Force of jump
    public float jumpForce = 500f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {   //Add a force, to jump the player
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            gameObject.GetComponent<AudioSource>().Play();
            //And destroy the buff, unique use
            Destroy(gameObject, 0.5f);
        }
    }
    
    
}
