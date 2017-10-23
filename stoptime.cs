using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoptime : MonoBehaviour {
    //force to break the jump
    public float forceUP;
    //To no make a inifine cicle
    private bool used = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (!used)
        {
            if (colisor.gameObject.tag == "Player")
            {
                colisor.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceUP);
                used = true;
            }
        }
        
    }
}
