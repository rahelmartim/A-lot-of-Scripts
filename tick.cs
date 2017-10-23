using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tick : MonoBehaviour {
    public float force;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce((Vector2.left + Vector2.up) * force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ninja>().gainTIK();
            Destroy(gameObject);
        }
    }
}
