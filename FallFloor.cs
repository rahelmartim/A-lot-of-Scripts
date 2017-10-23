using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour {
    //Time to plattarform fall
    public float trapTime;
    //Time elapsed
    private float timeE;
    //Check if the character touchted the plattaform
    private bool tPlayer;
    // Use this for initialization
    void Start () {
		
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
                //The plattarform fall
                gameObject.AddComponent<Rigidbody2D>();
                gameObject.GetComponent<AudioSource>().Play();
                //Destroy the plattaform, after 2 seconds
                Destroy(gameObject, 2f);
            }
        }
    }
    //Check if the player touchted the plattaform
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            tPlayer = true;
        }
    }
}
