using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_pt : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {   //if is touching the player
        if (colisor.gameObject.tag == "Player")
        {   //Add a force, to jump the player

            colisor.gameObject.GetComponent<Isayah>().check_point = "check_1";
            GetComponent<Animator>().SetTrigger("use");        

        }
    }
}
