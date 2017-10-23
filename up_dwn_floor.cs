using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up_dwn_floor : MonoBehaviour
{
    public float speed;
    //Time of the plattaform stay moving
    public float totalTime;
    //Time elapsed
    private float timeE;
    private const bool DOWN = true, UP = false;
    public bool position;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //increase the time in the current position
        timeE += Time.deltaTime;
        //check the time
        if (timeE >= totalTime)
        {
            //Reset count
            timeE = 0;
            //Invert the position
            position = !position;
        }
        //Move
        if (position) transform.Translate(Vector2.up * speed * Time.deltaTime);
        else transform.Translate(-Vector2.up * speed * Time.deltaTime);
    }
    //to the character move with the plattaform
    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player") colisor.gameObject.transform.parent = transform;
    }
    //If the player exit the plattaform
    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player") colisor.gameObject.transform.parent = null;

    }
}
