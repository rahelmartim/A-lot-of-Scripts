using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    private GameObject player;
    public float force;
    public GameObject end_expl;
    public Vector3 adjust;
    public Vector3 adjust2;
    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 1f);
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Isayah>().state == false)        GetComponent<Rigidbody2D>().AddForce(Vector2.right * this.force);
        else                                                     GetComponent<Rigidbody2D>().AddForce(Vector2.left * this.force);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D colisor)
    {
        Destroy(gameObject);
        if (player.GetComponent<Isayah>().state)
        {
            print("case 1");
            Instantiate(end_expl, transform.position + adjust, transform.rotation);
        }
        else
        {
            print("case 2");
            Instantiate(end_expl, transform.position + adjust2, transform.rotation);
        }

    }

 }

