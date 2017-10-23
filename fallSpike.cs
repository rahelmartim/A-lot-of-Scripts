using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallSpike : MonoBehaviour {
    //check if the trap was used
    private bool used = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            if (!used)
            {
                gameObject.AddComponent<Rigidbody2D>();
                gameObject.GetComponent<AudioSource>().Play();
                used = true;
            }
           
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {   
            var player = colisor.gameObject.GetComponent<Player>();
            player.loseLife(30);
        }
        if (colisor.gameObject.tag == "enemy")
        {
            Destroy(colisor.gameObject);
        }
        Destroy(gameObject, 0.1f);

    }
}
