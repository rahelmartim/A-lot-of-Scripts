using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour {
    public GameObject buff_w, player;
    public float force;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Rigidbody2D>().AddForce((Vector2.left + Vector2.up) * force);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<ninja>().shuriken = buff_w;
            Destroy(gameObject);
        }
        
    }
}
