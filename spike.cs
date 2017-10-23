using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    private GameObject player;
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (player.GetComponent<Isayah>().state == false)   transform.eulerAngles = new Vector2(0, 0);
        else                                                transform.eulerAngles = new Vector2(0, 180);
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {   //Add a force, to jump the player
            colisor.GetComponentInChildren<hp>().lose_life();
        }
    }
}
