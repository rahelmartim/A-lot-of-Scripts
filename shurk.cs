using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shurk : MonoBehaviour {
    public float force;
    private GameObject player;
    
    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 2f);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponentInChildren<SpriteRenderer>().flipX == false) GetComponent<Rigidbody2D>().AddForce(Vector2.right * this.force);
        else GetComponent<Rigidbody2D>().AddForce(Vector2.left * this.force);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
