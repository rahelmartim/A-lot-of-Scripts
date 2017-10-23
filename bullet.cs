using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float bullet_force;
    public int damage;
    public float time_to_live;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, time_to_live);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * bullet_force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D colisor)
    {   //if the player
        //take damage
        if (colisor.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
