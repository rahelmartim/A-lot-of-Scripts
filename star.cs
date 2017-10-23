using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {
    public float force;
    public GameObject clone;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().AddForce((Vector2.left + Vector2.up) * force);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(clone, collision.gameObject.transform.position, collision.gameObject.GetComponent<Transform>().rotation);
            Destroy(gameObject);
        }

    }
}
