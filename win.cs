using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win : MonoBehaviour {
    public Transform playerPoint;
    public Transform winnerpoint;
    public Transform flagver;
    public GameObject object1;
    private bool winner= false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (!winner)
        {
            if (colisor.gameObject.tag == "Player")
            {
                gameObject.GetComponent<AudioSource>().Play();
                colisor.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                colisor.GetComponent<Transform>().position = playerPoint.position;
                colisor.GetComponent<Transform>().position = new Vector3(colisor.GetComponent<Transform>().position.x, colisor.GetComponent<Transform>().position.y, 0);
                Instantiate(object1, winnerpoint.position, winnerpoint.rotation);
                winner = true;
                GetComponent<Transform>().position = flagver.position;
                GetComponent<Transform>().rotation = flagver.rotation;
            }
        }
       
    }
   public bool getWinner()
    {
        return winner;
    }
}
