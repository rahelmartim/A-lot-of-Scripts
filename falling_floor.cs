using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_floor : MonoBehaviour
{
    public float trapTime;
    //Time elapsed
    private float timeE;
    //Check if the character touchted the plattaform
    private bool tPlayer, warned;
    // Use this for initialization
    void Start ()
    {
        this.warned = false;
        this.tPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if the character touchted the plattaform
        if (tPlayer)
        {   //Increase the counter
            timeE += Time.deltaTime;
            //If time over
            if (timeE >= trapTime)
            {
                //Destroy the plattaform, after 2 seconds
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<Animator>().SetTrigger("fall");
                Destroy(gameObject, 1.6f);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (!this.warned)
        {
            GetComponent<Animator>().SetTrigger("warn");
            this.warned = true;
        }
        if (colisor.gameObject.tag == "Player")
        {
            tPlayer = true;
        }
    }
}
