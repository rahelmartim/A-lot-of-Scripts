using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFloor : MonoBehaviour {
   //Speed of plattaform move
    public float speed;
    //Time of the plattaform stay moving
    public float totalTime;
    //Time elapsed
    public float timeE;
    //True = right, False = left
    public bool position;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //increase the time in the current position
        timeE += Time.deltaTime;
        //check the time
        if (timeE >= totalTime)
        {
            //Reset count
            timeE = 0;
            //Invert the position
            if (position)
            {
                position = false;
            }
            else
            {
                position = true;
            }
        }
        //Move
        if (position)
        {   //Move right
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }else
        {   //Move left
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
	}
    //to the character move with the plattaform
    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            colisor.gameObject.transform.parent = transform;
        }
    }
    //If the player exit the plattaform
    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            colisor.gameObject.transform.parent = null;
        }
    }

}
